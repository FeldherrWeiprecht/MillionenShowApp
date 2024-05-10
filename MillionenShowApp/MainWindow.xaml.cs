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
			SetUiElementsContent();
		}

		private Question MakeNewQuestion()
		{
			var actualQuestion = new Question();
			return actualQuestion;
		}

		private void SetUiElementsContent()
		{
			var actualQuestion =  MakeNewQuestion();

			questionBlock.Text = actualQuestion.Content;
			answerButtonA.Content = actualQuestion.AnswerA;
			answerButtonB.Content = actualQuestion.AnswerB;
			answerButtonC.Content = actualQuestion.AnswerC;
			answerButtonD.Content = actualQuestion.AnswerD;

		}

		private void DisableAnswerButtons()
		{
			answerButtonA.IsEnabled = false;
			answerButtonB.IsEnabled = false;
			answerButtonC.IsEnabled = false;
			answerButtonD.IsEnabled = false;
		}

		private void EnableAnswerButtons()
		{
			answerButtonA.IsEnabled = true;
			answerButtonB.IsEnabled = true;
			answerButtonC.IsEnabled = true;
			answerButtonD.IsEnabled = true;
		}

		private async void answerButtonA_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();

			answerButtonA.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonA.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			EnableAnswerButtons();

		}

		private async void answerButtonB_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();

			answerButtonB.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonB.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			EnableAnswerButtons();
		}

		private async void answerButtonC_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();

			answerButtonC.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonC.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			EnableAnswerButtons();
		}

		private async void answerButtonD_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();

			answerButtonD.Background = Brushes.Green;

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

			EnableAnswerButtons();
		}
	}
}