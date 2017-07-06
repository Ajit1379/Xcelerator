using System.Collections.ObjectModel;
using DemoForms.Models;
using DemoForms.Services;
using Xamarin.Forms;

namespace DemoForms.ViewModels
{
    public class ListDetailPageViewModel : BaseViewModel
    {
        private ObservableCollection<Form> userlist;

        public ObservableCollection<Form> UserList
        {
            get => userlist;
            set => SetProperty(ref userlist, value);
        }

        public ListDetailPageViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            IsRunning = true;
            UserList = new ObservableCollection<Form>(await DependencyService.Get<IFirebaseService>().LoadData());
            IsRunning = false;
        }
    }
}
