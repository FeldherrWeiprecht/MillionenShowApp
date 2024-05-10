using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MillionenShowApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void disableAnswerButtons()
		{
			answerButtonA.IsEnabled = false;
			answerButtonB.IsEnabled = false;
			answerButtonC.IsEnabled = false;
			answerButtonD.IsEnabled = false;
		}

		private void enableAnswerButtons()
		{
			answerButtonA.IsEnabled = true;
			answerButtonB.IsEnabled = true;
			answerButtonC.IsEnabled = true;
			answerButtonD.IsEnabled = true;
		}

		private async void answerButtonA_Click(object sender, RoutedEventArgs e)
		{
			disableAnswerButtons();

			answerButtonA.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonA.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			enableAnswerButtons();

		}

		private async void answerButtonB_Click(object sender, RoutedEventArgs e)
		{
			disableAnswerButtons();

			answerButtonB.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonB.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			enableAnswerButtons();
		}

		private async void answerButtonC_Click(object sender, RoutedEventArgs e)
		{
			disableAnswerButtons();

			answerButtonC.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonC.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			enableAnswerButtons();
		}

		private async void answerButtonD_Click(object sender, RoutedEventArgs e)
		{
			disableAnswerButtons();

			answerButtonD.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			enableAnswerButtons();
		}
	}
}