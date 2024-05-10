using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MillionenShowApp
{
	internal class Question
	{
		public string Content { get; set; }
		public string AnswerA { get; set; }
		public string AnswerB { get; set; }
		public string AnswerC { get; set; }
		public string AnswerD { get; set; }
		public string CorrectAnswer { get; set; }

		public Question() 
		{
			using(SqliteConnection connection = new SqliteConnection("Data Source=src/quiz.db"))
			{
				connection.Open();

				SqliteCommand command= connection.CreateCommand();
				command.CommandText = @"SELECT * FROM tblQuestions ORDER BY RANDOM() LIMIT 1;";

				using (SqliteDataReader reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						this.Content = reader.GetString(1);
						this.AnswerA = reader.GetString(2);
						this.AnswerB = reader.GetString(3);
						this.AnswerC = reader.GetString(4);
						this.AnswerD = reader.GetString(5);
						this.CorrectAnswer = reader.GetString(5); 
					}
				}
					connection.Close();
			}
		}
	}
}
