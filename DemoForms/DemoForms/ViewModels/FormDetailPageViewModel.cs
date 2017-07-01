using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoForms.Models;

namespace DemoForms.ViewModels
{
    public class FormDetailPageViewModel : BaseViewModel
    {
        private List<Country> countryList;

        public List<Country> CountryList
        {
            get { return countryList; }
            set { SetProperty(ref countryList, value); }
        }

        public FormDetailPageViewModel()
        {
            countryList = Country.GetCountryList();
        }
    }
}
