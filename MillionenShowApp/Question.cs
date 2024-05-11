using Microsoft.Data.Sqlite;
using System;
using System.Windows;

namespace MillionenShowApp
{
	internal class Question
	{
		public int id;
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

				SqliteCommand command = connection.CreateCommand();
				command.CommandText = @"SELECT * FROM tblQuestions ORDER BY RANDOM() LIMIT 1;";

				using (SqliteDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						id = reader.GetInt32(0);
						Content = reader.GetString(1);
						AnswerA = reader.GetString(2);
						AnswerB = reader.GetString(3);
						AnswerC = reader.GetString(4);
						AnswerD = reader.GetString(5);
						CorrectAnswer = reader.GetString(6);
						CountSolvedCorrect = reader.GetInt32(7);
						CountSolvedWrong = reader.GetInt32(8);
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