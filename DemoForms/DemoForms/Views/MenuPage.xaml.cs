using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoForms.Views
{
    public partial class MenuPage : ContentPage
    {
        private MasterPage masterPage;

        public MenuPage(MasterPage page)
        {
            InitializeComponent();
            masterPage = page;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Models.MenuItem)e.SelectedItem;
            Type page = item.TargetType;

            masterPage.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            masterPage.IsPresented = false;
        }
    }
}