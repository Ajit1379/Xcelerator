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
        }

        public async void OnConfirm()
        {
            var json=await Helpers.JsonHelper.ConvertToJson(Form);
            var statusMessage = await new RestService().SendData(json);

        }

        public async void OnCancel()
        {
            await navigation.PopModalAsync();
        }
    }
}
