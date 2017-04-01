using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFacialDetection
{
    public class FaceClient
    {
        FaceServiceClient client = new FaceServiceClient("key-here");

        public async Task InitAsync()
        {
            foreach (var personGroupId in Helper.PersonGroupId)
            {
                await CreatePersonGroupAsync(personGroupId);
            }
        }

        private async Task CreatePersonGroupAsync(string groupId)
        {
            await client?.CreatePersonGroupAsync(groupId, "Name: " + groupId);
        }

        public async Task RegisterPersonAsync(string groupId, string name, Stream imgStream)
        {
            var person = await client?.CreatePersonAsync(groupId, name);

            Helper.NameGuidDict.Add(person.PersonId, name);

            await client?.AddPersonFaceAsync(groupId, person.PersonId, imgStream);
        }

        public async Task TrainGroupAsync(string groupId)
        {
            await client?.TrainPersonGroupAsync(groupId);

            TrainingStatus status = null;

            while (true)
            {
                status = await client?.GetPersonGroupTrainingStatusAsync(groupId);

                if (status.Status != Status.Running)
                {
                    break;
                }
            }
        }

        public async Task<List<string>> DetectFaceAsync(Stream imgStream)
        {
            var faces = await client?.DetectAsync(imgStream);

            var faceIds = faces.Select(face => face.FaceId).ToArray();

            List<string> personNameList = new List<string>();

            foreach (Guid faceId in faceIds)
            {
                string name = "";

                Helper.NameGuidDict.TryGetValue(faceId, out name);

                if (!string.IsNullOrEmpty(name))
                {
                    personNameList.Add(name);
                }
            }

            return personNameList;
        }
    }
}
