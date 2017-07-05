using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DemoForms.Models;
using DemoForms.Services;

namespace DemoForms.ViewModels
{
    public class ConfirmationPageViewModel : BaseViewModel
    {
        private INavigation navigation;

        public Form Form { get; set; }
        public Command ConfirmCommand { get; set; }
        public Command CancelCommand { get; set; }

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
            var json=await Helpers.JsonHelper.ConvertToJson(Form);
            var status = await new RestService().SendData(json);
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
            IsModalVisible = true;
            AnyMessage = true;
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
