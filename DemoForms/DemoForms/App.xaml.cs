using Xamarin.Forms;
using DemoForms.Views;

namespace DemoForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MasterPage();
        }
    }
}
