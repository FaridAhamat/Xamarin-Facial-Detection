using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace XamarinFacialDetection
{
    class FaceRegistrationPageViewModel : INotifyPropertyChanged
    {
        public FaceRegistrationPageViewModel()
        {
            TakePhotoCommand = new Command(TakePhotoAsync);
        }

        int tagIndex;
        public int TagsIndex
        {
            get
            {
                return tagIndex;
            }
            set
            {
                tagIndex = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get;
            set;
        }

        public ICommand TakePhotoCommand
        {
            get;
        }

        public List<string> Tags => Helper.PersonGroupId;

        async void TakePhotoAsync()
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Facial Detection",
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    Name = "FD" + Helper.PersonGroupId[tagIndex].ToString() + DateTime.UtcNow + ".jpg"
                };

                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
