using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFacialDetection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaceRegistrationPage : ContentPage
    {
        public FaceRegistrationPage()
        {
            InitializeComponent();
            BindingContext = new FaceRegistrationPageViewModel();
        }
    }
}
