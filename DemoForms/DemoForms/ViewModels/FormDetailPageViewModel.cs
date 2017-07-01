using System;
using System.Collections.Generic;
using DemoForms.Models;
using DemoForms.CustomControls;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoForms.ViewModels
{
    public class FormDetailPageViewModel : BaseViewModel
    {
        private List<Country> countryList;

        private List<CustomRadioButton> genderList;

        private List<CustomRadioButton> maritialList;

        public Command<CustomRadioButton> CheckCommand { get; set; }

        public List<Country> CountryList
        {
            get { return countryList; }
            set { SetProperty(ref countryList, value); }
        }

        public List<CustomRadioButton> GenderList
        {
            get { return genderList; }
            set { SetProperty(ref genderList, value); }
        }

        public List<CustomRadioButton> MaritialList
        {
            get { return maritialList; }
            set { SetProperty(ref maritialList, value); }
        }

        public FormDetailPageViewModel()
        {
            Initializeform();
        }

        private async void Initializeform()
        {
            countryList = await GetCountryList();
            genderList = await GetGenderList();
            maritialList = await GetMaritialList();
            CheckCommand = new Command<CustomRadioButton>(OnCheckChanged);
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

        private async Task<List<CustomRadioButton>> GetMaritialList()
        {
            return new List<CustomRadioButton>
                       {
                           new CustomRadioButton { Text = "Married" },
                           new CustomRadioButton { Text = "Single" }
                       };
        }

        private void OnCheckChanged(CustomRadioButton item)
        {
            
        }
    }
}
