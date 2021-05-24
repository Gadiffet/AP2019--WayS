using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class QuestionRepository : BaseRepository, IRepository<Question>
    {
        public void Create(Question element)
        {
            request = "INSERT INTO Question (questionText, reponsesQuestion) OUTPUT inserted.idQuestion values (@questionText, @reponsesQuestion)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            connection.Open();
            element.IdQuestion = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }

        public void Delete(Question element)
        {
            request = "DELETE FROM Question where idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public void Update(Question element)
        {
            request = "UPDATE Question SET questionText=@questionText, reponsesQuestion=@reponsesQuestion WHERE idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public List<Question> Listing()
        {
            List<Question> question = new List<Question>();
            request = "SELECT idQuestion, questionText, position from question";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Question c = new Question()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Position = reader.GetInt32(2)
                };
                question.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return question;
        }

        public Question FindById(int idQuestion)
        {
            Question question = null;
            request = "SELECT idQuestion, questionText, position from question where idQuestion = @idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                question = new Question()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return question;
        }
    }
}
