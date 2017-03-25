using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Xamarin.Forms;

namespace XamarinFacialDetection
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public MainPageViewModel()
        {
            RegisterFaceCommand = new Command(RegisterFace);
            DetectFaceCommand = new Command(DetectFace);
        }

        private void DetectFace()
        {
            // Go to face detection page
            //MessagingCenter.Send(this, "DetectFaceAlert", "Go to detect page");
            throw new NotImplementedException();
        }

        private void RegisterFace()
        {
            // Go to face registration page
            //MessagingCenter.Send(this, "RegisterFaceAlert", "Go to register page");
            throw new NotImplementedException();
        }

        public ICommand RegisterFaceCommand { get; }

        public ICommand DetectFaceCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
