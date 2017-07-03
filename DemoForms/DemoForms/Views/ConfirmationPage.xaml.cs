using DemoForms.Models;
using Xamarin.Forms;

namespace DemoForms.Views
{
    public partial class ConfirmationPage : ContentPage
    {
        public ConfirmationPage(Form form)
        {
            InitializeComponent();
            BindingContext = form;
        }
    }
}