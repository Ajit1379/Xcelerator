using DemoForms.Models;
using Xamarin.Forms;
using DemoForms.ViewModels;

namespace DemoForms.Views
{
    public partial class ConfirmationPage : ContentPage
    {
        public ConfirmationPage(Form form)
        {
            InitializeComponent();
            BindingContext = new ConfirmationPageViewModel(Navigation, form);
        }
    }
}