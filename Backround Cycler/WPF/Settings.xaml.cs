using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Backround_Cycler.WPF
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : UserControl
    {
        public Settings ()
        {
            InitializeComponent ();
        }

        private void UserControl_IsVisibleChanged (object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void textBox1_Pasting (object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent (typeof (String)))
            {
                String text = (String)e.DataObject.GetData (typeof (String));
                if (!IsTextAllowed (text))
                {
                    e.CancelCommand ();
                }
            }
            else
            {
                e.CancelCommand ();
            }
        }

        private bool IsTextAllowed (string text)
        {
            Regex regex = new Regex ("[^0-9-]+"); //regex that matches disallowed text
            return !regex.IsMatch (text);
        }

        private void textBox1_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed (e.Text);
        }

        private void UserControl_Loaded (object sender, RoutedEventArgs e)
        {

        }

        private void ChangeTime_TextChanged (object sender, TextChangedEventArgs e)
        {
            decimal number;
            if (decimal.TryParse (ChangeTime.Text, out number))
            {
                if (number < 1)
                {
                    ChangeTime.Text = "1";
                }
                else if (number > 100000)
                {
                    ChangeTime.Text = "100000";
                }
            }
            else
            {
                return;
            }
        }
    }
}
