using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;

namespace DemoForms.CustomControls
{
    using System.Windows.Input;

    public class BindableRadioGroup : StackLayout
    {
        private List<CustomRadioButton> rads;

        public BindableRadioGroup()
        {
            rads = new List<CustomRadioButton>();
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindableRadioGroup, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableRadioGroup, int>(o => o.SelectedIndex, default(int), BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        public static BindableProperty CheckCommandProperty = BindableProperty.Create<BindableRadioGroup, ICommand>(o => o.CheckCommand, null);

        public ICommand CheckCommand
        {
            get => (ICommand)GetValue(CheckCommandProperty);
            set => SetValue(CheckCommandProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public event EventHandler<int> CheckedChanged;

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var radButtons = bindable as BindableRadioGroup;

            radButtons.rads.Clear();
            radButtons.Children.Clear();
            if (newvalue != null)
            {
                int radIndex = 0;
                foreach (CustomRadioButton item in newvalue)
                {
                    var rad = new CustomRadioButton { Text = item.Text, Id = radIndex };
                    rad.CheckedChanged += radButtons.OnCheckedChanged;
                    radButtons.rads.Add(rad);
                    radButtons.Children.Add(rad);
                    radIndex++;
                }
            }
        }

        private void OnCheckedChanged(object sender, bool e)
        {
            if (e == false)
            {
                return;
            }

            var selectedRad = sender as CustomRadioButton;
            foreach (var rad in rads)
            {
                if (!selectedRad.Id.Equals(rad.Id))
                {
                    rad.Checked = false;
                }
                else
                {
                    //this.CheckedChanged?.Invoke(sender, rad.Id);
                    CheckCommand.Execute(sender);
                }
            }
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            if (newvalue == -1) return;
            var bindableRadioGroup = bindable as BindableRadioGroup;
            foreach (var rad in bindableRadioGroup.rads)
            {
                if (rad.Id == bindableRadioGroup.SelectedIndex)
                {
                    rad.Checked = true;
                }
            }
        }
    }
}
