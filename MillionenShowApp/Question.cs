using Microsoft.Data.Sqlite;
using System;
using System.Windows;

namespace MillionenShowApp
{
	internal class Question
	{
		private int id;
		public string Content { get; set; }
		public string AnswerA { get; set; }
		public string AnswerB { get; set; }
		public string AnswerC { get; set; }
		public string AnswerD { get; set; }
		public string CorrectAnswer { get; set; }
		public int CountSolvedCorrect { get; set; }
		public int CountSolvedWrong { get; set; }

		public Question()
		{
			using (SqliteConnection connection = new SqliteConnection("Data Source=src/quiz.db"))
			{
				connection.Open();

				string query = @"SELECT * FROM tblQuestions ORDER BY RANDOM() LIMIT 1;";
				using (SqliteCommand command = new SqliteCommand(query, connection))
				{
					using (SqliteDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							this.id = reader.GetInt32(0);
							this.Content = reader.GetString(1);
							this.AnswerA = reader.GetString(2);
							this.AnswerB = reader.GetString(3);
							this.AnswerC = reader.GetString(4);
							this.AnswerD = reader.GetString(5);
							this.CorrectAnswer = reader.GetString(6);
							this.CountSolvedCorrect = reader.GetInt32(7);
							this.CountSolvedWrong = reader.GetInt32(8);
						}
					}
				}
			}
		}


		public void SaveSolvedState()
		{
			using (SqliteConnection connection = new SqliteConnection("Data Source=src/quiz.db"))
			{
				connection.Open();

				string updateQuery = "UPDATE tblQuestions SET countSolvedCorrect = @CountSolvedCorrect, countSolvedWrong = @CountSolvedWrong WHERE id = @Id";

				using(SqliteCommand command = new SqliteCommand(updateQuery, connection))
				{
					command.Parameters.AddWithValue("@Id", this.id);
					command.Parameters.AddWithValue("@CountSolvedCorrect", this.CountSolvedCorrect);
					command.Parameters.AddWithValue("@CountSolvedWrong", this.CountSolvedWrong);

					command.ExecuteNonQuery();
				}
			}
		}
	}
}