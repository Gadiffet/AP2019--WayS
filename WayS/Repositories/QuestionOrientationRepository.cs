using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class QuestionOrientationRepository : BaseRepository, IRepository<QuestionOrientation>
    {
        public void Create(QuestionOrientation element)
        {
            request = "INSERT INTO Question (questionText, reponsesQuestion, bareme) OUTPUT inserted.idQuestion values (@questionText, @reponsesQuestion)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            command.Parameters.Add(new SqlParameter("@bareme", element.Bareme));
            connection.Open();
            element.IdQuestion = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }

        public void Delete(QuestionOrientation element)
        {
            request = "DELETE FROM Question where idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public void Update(QuestionOrientation element)
        {
            request = "UPDATE Question SET questionText=@questionText, reponsesQuestion=@reponsesQuestion, bareme=@bareme WHERE idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            command.Parameters.Add(new SqlParameter("@bareme", element.Bareme));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public List<QuestionOrientation> Listing()
        {
            List<QuestionOrientation> questionOrientation = new List<QuestionOrientation>();
            request = "SELECT idQuestionOrientation, questionText, bareme, position from questionOrientation";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionOrientation c = new QuestionOrientation()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Bareme = reader.GetString(2),
                    Position = reader.GetInt32(3)
                };
                questionOrientation.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return questionOrientation;
        }

        public List<QuestionOrientation> FindByQuestionText(string questionText)
        {
            List<QuestionOrientation> questionOrientation = new List<QuestionOrientation>();
            request = "SELECT idQuestionOrientation, questionText, bareme, position from questionOrientation where questionText=@questionText";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@questionText", questionText));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionOrientation c = new QuestionOrientation()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Bareme = reader.GetString(2),
                    Position = reader.GetInt32(3)
                };
                questionOrientation.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return questionOrientation;
        }

        public QuestionOrientation FindById(int idQuestion)
        {
            QuestionOrientation questionOrientation = null;
            request = "SELECT a.idQuestion, a.questionText, b.reponse from Question a left join Reponse b where a.idQuestion = b.idQuestion = @idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                questionOrientation = new QuestionOrientation()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Bareme = reader.GetString(2)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return questionOrientation;
        }
    }
}
