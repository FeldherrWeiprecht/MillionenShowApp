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
		private char correctAnswer;

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
			correctAnswer = char.Parse(actualQuestion.CorrectAnswer.Trim());
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
			if(this.correctAnswer == 'A')
			{
				answerButtonA.Background = Brushes.Green;
			}
			else
			{
				answerButtonA.Background = Brushes.Red;
			}

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonA.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
			EnableAnswerButtons();
			SetUiElementsContent();

		}

		private async void answerButtonB_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();
			if (this.correctAnswer == 'B')
			{
				answerButtonB.Background = Brushes.Green;

			}
			else
			{
				answerButtonB.Background = Brushes.Red;
			}

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonB.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
			EnableAnswerButtons();
			SetUiElementsContent();
		}

		private async void answerButtonC_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();
			if (this.correctAnswer == 'C')
			{
				answerButtonC.Background = Brushes.Green;
			}
			else
			{
				answerButtonC.Background = Brushes.Red;
			}

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonC.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
			EnableAnswerButtons(); 
			SetUiElementsContent();
		}

		private async void answerButtonD_Click(object sender, RoutedEventArgs e)
		{
			DisableAnswerButtons();
			if (this.correctAnswer == 'D')
			{
				answerButtonD.Background = Brushes.Green;
			}
			else
			{
				answerButtonD.Background = Brushes.Red;
			}

			await Task.Delay(TimeSpan.FromSeconds(3));

			answerButtonD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
			EnableAnswerButtons();
			SetUiElementsContent();
		}

	}
}