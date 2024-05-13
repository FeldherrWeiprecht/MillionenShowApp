using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MillionenShowApp
{
	public partial class StatisticWindow : Window
	{
		public SeriesCollection SeriesCollection { get; set; }
		public List<string> Labels { get; set; }

		public StatisticWindow(Window window, QuestionList questionList)
		{
			InitializeComponent();
			PrepareData(questionList);
			DataContext = this;
		}

		private void PrepareData(QuestionList questionList)
		{
			SeriesCollection = new SeriesCollection();
			Labels = new List<string>();

			foreach (Question question in questionList.questions)
			{
				Labels.Add(question.Content);

				// Erstellen Sie den roten Balken für die falsch beantworteten Fragen
				SeriesCollection.Add(new ColumnSeries
				{
					Title = $"{question.Content} (Falsch)",
					Values = new ChartValues<int> { question.CountSolvedWrong },
					Fill = Brushes.Red
				});

				// Erstellen Sie den grünen Balken für die richtig beantworteten Fragen
				SeriesCollection.Add(new ColumnSeries
				{
					Title = $"{question.Content} (Richtig)",
					Values = new ChartValues<int> { question.CountSolvedCorrect },
					Fill = Brushes.Green
				});
			}
		}

	}
}