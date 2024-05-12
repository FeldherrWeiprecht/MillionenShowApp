using Microsoft.Data.Sqlite;
using System;
using System.Windows;

namespace MillionenShowApp
{
	internal class Question
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public string AnswerA { get; set; }
		public string AnswerB { get; set; }
		public string AnswerC { get; set; }
		public string AnswerD { get; set; }
		public string CorrectAnswer { get; set; }
		public int CountSolvedCorrect { get; set; }
		public int CountSolvedWrong { get; set; }

		public Question() { }
	}
}