using Xamarin.Forms;
using DemoForms.ViewModels;

namespace DemoForms.Views
{
    public partial class ListDetailPage : ContentPage
    {
        public ListDetailPage()
        {
            InitializeComponent();
            BindingContext = new ListDetailPageViewModel();
            ListView.ItemSelected += (s, e) => { ListView.SelectedItem = null; };
        }
    }
}