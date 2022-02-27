using SirenaTravel.ViewModels;

using Xamarin.Forms;

namespace SirenaTravel.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainVM();
        }
    }
}
