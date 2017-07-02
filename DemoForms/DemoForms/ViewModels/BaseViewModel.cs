using DemoForms.Helpers;
using Xamarin.Forms;
namespace DemoForms.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private bool isBusy = false;
        private bool anyMessage;
        private string title = string.Empty;
        private string message;
        private bool isModalVisible;

        public Command OkCommand { get; set; }

        public bool IsModalVisible
        {
            get { return isModalVisible; }
            set { SetProperty(ref isModalVisible, value); }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public bool AnyMessage
        {
            get { return anyMessage; }
            set { SetProperty(ref anyMessage, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
    }
}

