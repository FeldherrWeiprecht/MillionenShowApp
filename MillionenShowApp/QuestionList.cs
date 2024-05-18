using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MillionenShowApp
{
	public class QuestionList
	{
		public List<Question> questions = new List<Question>();

		public void Load()
		{
			using (SqliteConnection connection = new SqliteConnection("Data Source=src/quiz.db"))
			{
				connection.Open();

				string query = @"SELECT * FROM tblQuestions;";
				using (SqliteCommand command = new SqliteCommand(query, connection))
				{
					using (SqliteDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Question question = new Question();

							question.Id = reader.GetInt32(0);
							question.Content = reader.GetString(1);
							question.AnswerA = reader.GetString(2);
							question.AnswerB = reader.GetString(3);
							question.AnswerC = reader.GetString(4);
							question.AnswerD = reader.GetString(5);
							question.CorrectAnswer = reader.GetString(6);
							question.CountSolvedCorrect = reader.GetInt32(7);
							question.CountSolvedWrong = reader.GetInt32(8);
							this.questions.Add(question);
						}
					}
				}
			}
		}


		public void Save()
		{
			using (SqliteConnection connection = new SqliteConnection("Data Source=src/quiz.db"))
			{
				connection.Open();

				string updateQuery = "UPDATE tblQuestions SET countSolvedCorrect = @CountSolvedCorrect, countSolvedWrong = @CountSolvedWrong WHERE id = @Id";

				using (SqliteCommand command = new SqliteCommand(updateQuery, connection))
				{
					command.Parameters.Add("@Id", SqliteType.Integer);
					command.Parameters.Add("@CountSolvedCorrect", SqliteType.Integer);
					command.Parameters.Add("@CountSolvedWrong", SqliteType.Integer);

					foreach (Question question in this.questions)
					{
						command.Parameters["@Id"].Value = question.Id;
						command.Parameters["@CountSolvedCorrect"].Value = question.CountSolvedCorrect;
						command.Parameters["@CountSolvedWrong"].Value = question.CountSolvedWrong;

						command.ExecuteNonQuery();
					}
				}
			}
		}

		public Question GetRandomQuestion()
		{
			Random rand = new Random();
			Question question = this.questions[rand.Next(questions.Count)];
			return question;
		}

		public void CheckQuestion(Question question)
		{
			foreach(Question actualQuestion in  this.questions) 
			{ 
				if(actualQuestion.Id == question.Id)
				{
					actualQuestion.CountSolvedCorrect = question.CountSolvedCorrect;
					actualQuestion.CountSolvedWrong = question.CountSolvedWrong;
				}
			}

		}

	}
}
