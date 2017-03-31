using Microsoft.ProjectOxford.Face;
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

        public void RegisterPersonAsync(string groupId, string name, Stream imgStream)
        {
            client?.CreatePersonAsync(groupId, name);
            //client?.AddPersonFaceAsync(groupId, name, imgStream);
        }
    }
}
