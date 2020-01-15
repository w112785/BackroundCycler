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
		public decimal Maximum
		{
			get { return (decimal)GetValue(MaximumProperty); }
			set { SetValue(MaximumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Maximum.  
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty.Register("Maximum", typeof(decimal),
			typeof(NumberUpDown), new UIPropertyMetadata(100000.0M));

		/// <summary>
		/// Minimum value of the numeric up down control.
		/// </summary>
		public decimal Minimum
		{
			get { return (decimal)GetValue(MinimumProperty); }
			set { SetValue(MinimumProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Minimum.  
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty.Register("Minimum", typeof(decimal),
			typeof(NumberUpDown), new UIPropertyMetadata(1M));

		public decimal NumValue
		{
			get
			{
				return (decimal)GetValue(NumValueProperty);
			}
			set
			{
				TextBoxValue.Text = value.ToString();
				SetValue(NumValueProperty, value);
			}
		}

		// Using a DependencyProperty as the backing store for Value. 
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NumValueProperty =
			DependencyProperty.Register("NumValue", typeof(decimal), typeof(NumberUpDown),
			new PropertyMetadata(1M, 
				new PropertyChangedCallback(OnSomeValuePropertyChanged)));

		private static void OnSomeValuePropertyChanged(
			DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			NumberUpDown numericBox = target as NumberUpDown;
			numericBox.TextBoxValue.Text = e.NewValue.ToString();
		}

		#endregion

		public NumberUpDown()
		{
			InitializeComponent();
		}

		private void TextBoxValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9-]+"); //regex that matches allowed text
			e.Handled = regex.IsMatch(e.Text);
		}
		private void TextBoxValue_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Increase_Click(object sender, RoutedEventArgs e)
		{
			if (NumValue < Maximum)
			{
				NumValue++;
				//RaiseEvent(new RoutedEventArgs(IncreaseClickedEvent));
			}
		}

		private void Decrease_Click(object sender, RoutedEventArgs e)
		{
			if (NumValue > Minimum)
			{
				NumValue--;
				//RaiseEvent(new RoutedEventArgs(DecreaseClickedEvent));
			}
		}
	}
}
