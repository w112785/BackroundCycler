/*
Copyright (c) 2006-2019, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Backround_Cycler.WPF.Controls
{
	/// <summary>
	/// Interaction logic for NumberUpDown.xaml
	/// </summary>
	public partial class NumberUpDown : UserControl
	{
		#region Properties and events

		/// <summary>
		/// Maximum value for the Numeric Up Down control
		/// </summary>
		public int Maximum
		{
			get { return (int)GetValue(MaximumProperty); }
			set { SetValue(MaximumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Maximum.  
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty.Register("Maximum", typeof(int),
			typeof(NumberUpDown), new UIPropertyMetadata(100000));

		/// <summary>
		/// Minimum value of the numeric up down control.
		/// </summary>
		public int Minimum
		{
			get { return (int)GetValue(MinimumProperty); }
			set { SetValue(MinimumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Minimum.  
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty.Register("Minimum", typeof(int),
			typeof(NumberUpDown), new UIPropertyMetadata(1));

		public int Value
		{
			get
			{
				return (int)GetValue(ValueProperty);
			}
			set
			{
				TextBoxValue.Text = value.ToString();
				SetValue(ValueProperty, value);
			}
		}

		// Using a DependencyProperty as the backing store for Value. 
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(int), typeof(NumberUpDown),
			new PropertyMetadata(0, new PropertyChangedCallback(OnSomeValuePropertyChanged)));

		private static void OnSomeValuePropertyChanged(
			DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			NumberUpDown numericBox = target as NumberUpDown;
			numericBox.TextBoxValue.Text = e.NewValue.ToString();
		}

		#endregion

		private Regex _numMatch;

		public NumberUpDown()
		{
			InitializeComponent();

			_numMatch = new Regex(@"^-?\d+$");
			Maximum = int.MaxValue;
			Minimum = 0;
			TextBoxValue.Text = "0";
		}

		private void TextBoxValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !_numMatch.IsMatch(((TextBox)sender).Text);
		}

		private void Increase_Click(object sender, RoutedEventArgs e)
		{
			if (Value < Maximum)
			{
				Value++;
				//RaiseEvent(new RoutedEventArgs(IncreaseClickedEvent));
			}
		}

		private void Decrease_Click(object sender, RoutedEventArgs e)
		{
			if (Value > Minimum)
			{
				Value--;
				//RaiseEvent(new RoutedEventArgs(DecreaseClickedEvent));
			}
		}
	}
}
