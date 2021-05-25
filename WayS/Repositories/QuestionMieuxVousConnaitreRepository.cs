using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class QuestionMieuxVousConnaitreRepository : BaseRepository, IRepository<QuestionMieuxVousConnaitre>
    {
        public QuestionMieuxVousConnaitre Create(QuestionMieuxVousConnaitre element)
        {
            request = "INSERT INTO QuestionMieuxVousConnaitre (questionText, reponsesQuestion) OUTPUT inserted.idQuestion values (@questionText, @reponsesQuestion)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            connection.Open();
            element.IdQuestion = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element;
        }

        public QuestionMieuxVousConnaitre Delete(QuestionMieuxVousConnaitre element)
        {
            request = "DELETE FROM QuestionMieuxVousConnaitre where idQuestionMieuxVousConnaitre=@idQuestionMieuxVousConnaitre";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            connection.Open();
            command.Dispose();
            connection.Close();
            return element;
        }

        public QuestionMieuxVousConnaitre Update(QuestionMieuxVousConnaitre element)
        {
            request = "UPDATE questionMieuxVousConnaitre SET questionText=@questionText WHERE idQuestionMieuxVousConnaitre=@idQuestionMieuxVousConnaitre";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestionMieuxVousConnaitre", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@questionText", element.QuestionText));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public List<QuestionMieuxVousConnaitre> Listing()
        {
            List<QuestionMieuxVousConnaitre> mieuxVousConnaitre = new List<QuestionMieuxVousConnaitre>();
            request = "SELECT idQuestionMieuxVousConnaitre, questionText, position from questionMieuxVousConnaitre";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionMieuxVousConnaitre c = new QuestionMieuxVousConnaitre()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Position = reader.GetInt32(2)
                };
                mieuxVousConnaitre.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return mieuxVousConnaitre;
        }

        public QuestionMieuxVousConnaitre FindById(int idQuestion)
        {
            QuestionMieuxVousConnaitre question = null;
            request = "SELECT idQuestion, questionText, position from question where idQuestion = @idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                question = new QuestionMieuxVousConnaitre()
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

        public List<QuestionMieuxVousConnaitre> FindByQuestionText(string questionText)
        {
            List<QuestionMieuxVousConnaitre> questionMieuxVousConnaitre = new List<QuestionMieuxVousConnaitre>();
            request = "SELECT idQuestionMieuxVousConnaitre, questionText, position from questionMieuxVousConnaitre where questionText=@questionText";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@questionText", questionText));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuestionMieuxVousConnaitre c = new QuestionMieuxVousConnaitre()
                {
                    IdQuestion = reader.GetInt32(0),
                    QuestionText = reader.GetString(1),
                    Position = reader.GetInt32(2)
                };
                questionMieuxVousConnaitre.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return questionMieuxVousConnaitre;
        }

    }
}