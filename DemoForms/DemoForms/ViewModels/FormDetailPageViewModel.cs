using System;
using System.Collections.Generic;
using DemoForms.Models;
using DemoForms.CustomControls;
using System.Threading.Tasks;
using Xamarin.Forms;
using DemoForms.Services;
using System.IO;
using DemoForms.Helpers;

namespace DemoForms.ViewModels
{
    public class FormDetailPageViewModel : BaseViewModel
    {
        private Form form;

        private List<Country> countryList;

        private List<CustomRadioButton> genderList;

        private List<CustomRadioButton> maritalList;

        private ImageSource imgSource;

        public Command<DateChangedEventArgs> DateCommand { get; set; }

        public Command<Picker> CountryCommand { get; set; }

        public Command<RadioButtonEventArg> CheckCommand { get; set; }

        public Command ImageCommand { get; set; }

        public Command SubmitCommand { get; set; }

        public Form Form
        {
            get => form;
            set => SetProperty(ref form, value);
        }

        public List<Country> CountryList
        {
            get => countryList;
            set => SetProperty(ref countryList, value);
        }

        public List<CustomRadioButton> GenderList
        {
            get => genderList;
            set => SetProperty(ref genderList, value);
        }

        public List<CustomRadioButton> MaritalList
        {
            get => maritalList;
            set => SetProperty(ref maritalList, value);
        }

        public ImageSource ImgSource
        {
            get => imgSource;
            set => SetProperty(ref imgSource, value);
        }

        public FormDetailPageViewModel()
        {
            Initializeform();
        }

        private async void Initializeform()
        {
            countryList = await GetCountryList();
            genderList = await GetGenderList();
            maritalList = await GetMaritalList();
            DateCommand = new Command<DateChangedEventArgs>(OnDateSelected);
            CountryCommand = new Command<Picker>(OnCountrySelected); 
            CheckCommand = new Command<RadioButtonEventArg>(OnCheckChanged);
            ImageCommand = new Command(OnImageUpload);
            OkCommand = new Command(OnOkay);
            SubmitCommand = new Command(OnSubmit);
            form = new Form();
        }

        private async Task<List<Country>> GetCountryList()
        {
            return Country.GetCountryList();
        }

        private async Task<List<CustomRadioButton>> GetGenderList()
        {
            return new List<CustomRadioButton>
                       {
                           new CustomRadioButton { Text = "Male" },
                           new CustomRadioButton { Text = "Female" }
                       };
        }

        private async Task<List<CustomRadioButton>> GetMaritalList()
        {
            return new List<CustomRadioButton>
                       {
                           new CustomRadioButton { Text = "Married" },
                           new CustomRadioButton { Text = "Single" }
                       };
        }

        protected void OnDateSelected(DateChangedEventArgs date)
        {
            Form.DateOfBirth=date.NewDate;
        }

        protected void OnCountrySelected(Picker obj)
        {
            Form.Nationality=((Country)obj.SelectedItem).Name;
        }
        protected void OnCheckChanged(RadioButtonEventArg sender)
        {
            if (sender.GroupIndex == 0)
            {
                Form.Gender = sender.RadioButton.Text;
            }
            else
            {
                Form.MaritalStatus = sender.RadioButton.Text;
            }
        }

        protected async void OnImageUpload()
        {
            try
            {
                Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
                SetImage(stream);
                ImgSource = ImageSource.FromStream(() => ImageHelper.ByteToStream(Form.Image));
                if(ImgSource!=null)
                IsModalVisible = true;
            }
            catch (Exception e)
            {
                IsModalVisible = true;
                AnyMessage = true;
                Message = "Oops!!!";
            }
        }
        protected void OnOkay()
        {
            ImgSource = null;
            AnyMessage = false;
            IsModalVisible = false;
        }

        protected async void OnSubmit()
        {
            var msg = Validate(Form);
            if (msg == null)
            {
                try
                {
                    var json = await JsonHelper.ConvertToJson(form);
                    new RestService().SendData(json);
                }
                catch(Exception e)
                { }
            }
            else
            {
                IsModalVisible = true;
                AnyMessage = true;
                Message = msg;
            }
        }

        private void SetImage(Stream stream)
        {
            form.Image = ImageHelper.StreamToByte(stream);
        }

        private string Validate(Form form)
        {
            if (string.IsNullOrEmpty(form.FirstName)) return "please enter first name";
            if (string.IsNullOrEmpty(form.MiddleName)) return "please enter middle name";
            if (string.IsNullOrEmpty(form.LastName)) return "please enter last name";
            if (form.Nationality == null) return "please select your nationality";
            if (string.IsNullOrEmpty(form.Gender)) return "please enter your gender";
            if (string.IsNullOrEmpty(form.MaritalStatus)) return "please enter your marital status";
            if (form.Image == null) return "please upload your image";
            return null;
        }
    }
}

