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
		private Question actualQuestion;
		private int sleepingTime;

		public MainWindow()
		{
			InitializeComponent();
			SetUiElementsContent();
		}

		private void MakeNewQuestion()
		{
			this.actualQuestion = new Question();
		}

		private void SetUiElementsContent()
		{
			MakeNewQuestion();
			questionBlock.Text = this.actualQuestion.Content;
			answerButtonA.Content = this.actualQuestion.AnswerA;
			answerButtonB.Content = this.actualQuestion.AnswerB;
			answerButtonC.Content = this.actualQuestion.AnswerC;
			answerButtonD.Content = this.actualQuestion.AnswerD;
			correctAnswer = char.Parse(this.actualQuestion.CorrectAnswer.Trim());
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
				this.actualQuestion.CountSolvedCorrect += 1;
			}
			else
			{
				answerButtonA.Background = Brushes.Red;
				this.actualQuestion.CountSolvedWrong += 1;
			}

			this.actualQuestion.SaveSolvedState();

			await Task.Delay(TimeSpan.FromSeconds(sleepingTime));

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
				this.actualQuestion.CountSolvedCorrect += 1;
			}
			else
			{
				answerButtonB.Background = Brushes.Red;
				this.actualQuestion.CountSolvedWrong += 1;
			}

			this.actualQuestion.SaveSolvedState();

			await Task.Delay(TimeSpan.FromSeconds(sleepingTime));

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
				this.actualQuestion.CountSolvedCorrect += 1;
			}
			else
			{
				answerButtonC.Background = Brushes.Red;
				this.actualQuestion.CountSolvedWrong += 1;
			}

			this.actualQuestion.SaveSolvedState();

			await Task.Delay(TimeSpan.FromSeconds(sleepingTime));

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
				this.actualQuestion.CountSolvedCorrect += 1;
			}
			else
			{
				answerButtonD.Background = Brushes.Red;
				this.actualQuestion.CountSolvedWrong += 1;
			}

			this.actualQuestion.SaveSolvedState();

			await Task.Delay(TimeSpan.FromSeconds(sleepingTime));

			answerButtonD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
			EnableAnswerButtons();
			SetUiElementsContent();
		}

		private void statisticWindowConnection_Click(object sender, RoutedEventArgs e)
		{
			var statisticWindow = new StatisticWindow(this);
			statisticWindow.ShowDialog();
		}
	}
}