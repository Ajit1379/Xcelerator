using Xamarin.Forms;
using DemoForms.Models;
using DemoForms.Services;

namespace DemoForms.ViewModels
{
    public class ConfirmationPageViewModel : BaseViewModel
    {
        private INavigation navigation;
        private bool isRunning;

        public Form Form { get; set; }
        public Command ConfirmCommand { get; set; }
        public Command CancelCommand { get; set; }

        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }

        public ConfirmationPageViewModel(INavigation nav,Form form)
        {
            navigation = nav;
            Form = form;
            ConfirmCommand = new Command(OnConfirm);
            CancelCommand = new Command(OnCancel);
            OkCommand = new Command(OnOkay);
        }

        protected async void OnConfirm()
        {
            IsRunning = true;
            var status = await DependencyService.Get<IFirebaseService>().SendData(Form);
            IsRunning = false;
            IsModalVisible = true;
            AnyMessage = true;
            if (status)
            {
                Message = "Successfully Sent";
            }
            else
            {
                Message = "Try Again";
            }
        }

        protected async void OnCancel()
        {
            await navigation.PopModalAsync();
        }

        protected async void OnOkay()
        {
            IsModalVisible = false;
            AnyMessage = false;
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
