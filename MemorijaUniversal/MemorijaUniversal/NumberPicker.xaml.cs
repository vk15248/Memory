using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MemorijaUniversal
{
    public sealed partial class NumberPicker : UserControl
    {
        public NumberPicker()
        {
            this.InitializeComponent();
            if (MinValue != null || MinValue.Length > 0)
                MinValue = "0";
            if(Step != null || Step.Length > 0)
                Step = "1";
        }

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register
           (
                "MinValue",
                typeof(string),
                typeof(NumberPicker),
                new PropertyMetadata(string.Empty)
           );

        public string MinValue
        {
            get { return (string)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register
         (
              "MaxValue",
              typeof(string),
              typeof(NumberPicker),
              new PropertyMetadata(string.Empty)
         );

        public string MaxValue
        {
            get { return (string)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register
         (
              "Step",
              typeof(string),
              typeof(NumberPicker),
              new PropertyMetadata(string.Empty)
         );

        public string Step
        {
            get { return (string)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register(
            "CurrentValue",
            typeof(string),
            typeof(NumberPicker),
            new PropertyMetadata(string.Empty)
         );

        public string CurrentValue
        {
            get { return (string)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        private void Reduce_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentValue = int.Parse(content.Text);

            if (currentValue == int.Parse(MinValue))
            {
                return;
            }
            content.Text = (currentValue - int.Parse(Step)).ToString();
        }

        private void Increase_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentValue = int.Parse(content.Text);
            if (MaxValue!=null && MaxValue.Length>0 && currentValue == int.Parse(MaxValue))
            {
                return;
            }
            content.Text = (currentValue + int.Parse(Step)).ToString();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (((TextBox)sender).Text.Length == 0)
            { 
                ((TextBox)sender).Text = MinValue;
            }
            else if (regex.IsMatch(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = CurrentValue;
            }
            else if (int.Parse(((TextBox)sender).Text)% int.Parse(Step) != 0)
            {
                ((TextBox)sender).Text = CurrentValue;
            }
            else if (int.Parse(((TextBox)sender).Text) > int.Parse(MaxValue))
            {
                ((TextBox)sender).Text = MaxValue;
            }
            else if (int.Parse(((TextBox)sender).Text) < int.Parse(MinValue))
            {
                ((TextBox)sender).Text = MinValue;
            }
            else
                CurrentValue = ((TextBox)sender).Text;
        }
    }

}
