using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MillionenShowApp
{
	public partial class StatisticWindow : Window
	{
		// Bug: bei manchen Fragen wird vor dem Balken der Content nicht angezeigt!

		public SeriesCollection SeriesCollection { get; set; }
		public List<string> Labels { get; set; }
		public Func<double, string> Formatter { get; set; }

		public StatisticWindow(Window window, QuestionList questionList)
		{
			InitializeComponent();

			Labels = new List<string>();
			List<int> correctCounts = new List<int>();
			List<int> wrongCounts = new List<int>();

			var sortedQuestions = questionList.questions.OrderByDescending(q => q.CountSolvedCorrect);

			foreach (Question question in sortedQuestions)
			{
				Labels.Add(question.Content);
				correctCounts.Add(question.CountSolvedCorrect);
				wrongCounts.Add(question.CountSolvedWrong);
			}

			SeriesCollection = new SeriesCollection
			{
				new StackedRowSeries
				{
					Title = "Correct",
					Values = new ChartValues<int>(correctCounts),
					Fill = System.Windows.Media.Brushes.Green
				},
				new StackedRowSeries
				{
					Title = "Wrong",
					Values = new ChartValues<int>(wrongCounts),
					Fill = System.Windows.Media.Brushes.Red
				}
			};

			Formatter = value => value.ToString();
			DataContext = this;
		}
	}
}