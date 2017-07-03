using System;
using Xamarin.Forms;
using DemoForms.ViewModels;

namespace DemoForms.Views
{
    public partial class FormDetailPage : ContentPage
    {
        public FormDetailPage()
        {
            InitializeComponent();
            BindingContext = new FormDetailPageViewModel(Navigation);
            DatePicker.MaximumDate = DateTime.Today;
        }
    }
}