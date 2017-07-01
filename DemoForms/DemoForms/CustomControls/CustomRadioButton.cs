using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace DemoForms.CustomControls
{
    public class CustomRadioButton : View
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);

        public static readonly BindableProperty TextProperty = BindableProperty.Create<CustomRadioButton, string>(p => p.Text, string.Empty);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<CustomRadioButton, Color>(p => p.TextColor, Color.Black);

        public EventHandler<bool> CheckedChanged;

        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set
            {
                SetValue(CheckedProperty, value);
                var eventHandler = CheckedChanged;
                eventHandler?.Invoke(this, value);
            }
        }

        public int Id { get; set; }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
    }
}




