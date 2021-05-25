using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class ReponsesRepository : BaseRepository, IRepository<Reponses>
    {
        public Reponses Create(Reponses element)
        {
            request = "INSERT INTO reponse (idQuestion, reponse, correct, nbrPoints) VALUES (@idQuestion, @reponse, @correct, @nbrPoints)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses CreateOrientation(Reponses element)
        {
            request = "INSERT INTO reponseOrientation (idQuestionOrientation, reponse, correct, nbrPoints) VALUES (@idQuestion, @reponse, @correct, @nbrPoints)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses CreateMieuxVousConnaitre(Reponses element)
        {
            request = "INSERT INTO reponseMieuxVousConnaitre (idQuestionMieuxVousConnaitre, reponse, correct, nbrPoints) VALUES (@idQuestion, @reponse, @correct, @nbrPoints)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses Delete(Reponses element)
        {
            request = "DELETE FROM reponse where idReponse=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses DeleteOrientation(Reponses element)
        {
            request = "DELETE FROM reponseOrientation where idReponseOrientation=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses DeleteMieuxVousConnaitre(Reponses element)
        {
            request = "DELETE FROM reponseMieuxVousConnaitre where idReponseMieuxVousConnaitre=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses Update(Reponses element)
        {
            request = "UPDATE reponse SET reponse=@reponse, correct=@correct, nbrPoints=@nbrPoints WHERE idReponse=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses UpdateOrientation(Reponses element)
        {
            MessageBox.Show(element.Id + element.Reponse + element.Correct + element.NbrPoints, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            request = "UPDATE reponseOrientation SET reponse=@reponse, correct=@correct, nbrPoints=@nbrPoints WHERE idReponseOrientation=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Reponses UpdateMieuxVousConnaitre(Reponses element)
        {
            MessageBox.Show(element.Id + element.Reponse + element.Correct + element.NbrPoints, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            request = "UPDATE reponseMieuxVousConnaitre SET reponse=@reponse, correct=@correct, nbrPoints=@nbrPoints WHERE idReponseMieuxVousConnaitre=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public List<Reponses> Listing()
        {
            List<Reponses> reponses = new List<Reponses>();
            request = "SELECT idReponse, idQuestion, reponse, correct, nbrPoints from reponse where idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reponses c = new Reponses()
                {
                    Id = reader.GetInt32(0),
                    IdQuestion = reader.GetInt32(1),
                    Reponse = reader.GetString(2),
                    Correct = reader.GetBoolean(3),
                    NbrPoints = reader.GetInt32(4)
                };
                reponses.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return reponses;
        }

        public List<Reponses> Listing(int idQuestion)
        {
            List<Reponses> reponses = new List<Reponses>();
            request = "SELECT idReponse, idQuestion, reponse, correct, nbrPoints from reponse where idQuestion=@idQuestion";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reponses c = new Reponses()
                {
                    Id = reader.GetInt32(0),
                    IdQuestion = reader.GetInt32(1),
                    Reponse = reader.GetString(2),
                    Correct = reader.GetBoolean(3),
                    NbrPoints = reader.GetInt32(4)
                };
                reponses.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return reponses;
        }

        public List<Reponses> ListingOrientation(int idQuestion)
        {
            List<Reponses> reponses = new List<Reponses>();
            request = "SELECT idReponseOrientation, idQuestionOrientation, reponse, correct, nbrPoints from reponseOrientation where idQuestionOrientation=@idQuestionOrientation";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestionOrientation", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reponses c = new Reponses()
                {
                    Id = reader.GetInt32(0),
                    IdQuestion = reader.GetInt32(1),
                    Reponse = reader.GetString(2),
                    Correct = reader.GetBoolean(3),
                    NbrPoints = reader.GetInt32(4)
                };
                reponses.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return reponses;
        }

        public List<Reponses> ListingMieuxVousConnaitre(int idQuestion)
        {
            List<Reponses> reponses = new List<Reponses>();
            request = "SELECT idReponseMieuxVousConnaitre, idQuestionOrientation, reponse, correct, nbrPoints from reponseMieuxVousConnaitre where idQuestionMieuxVousConnaitre=@idQuestionMieuxVousConnaitre";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestionMieuxVousConnaitre", idQuestion));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reponses c = new Reponses()
                {
                    Id = reader.GetInt32(0),
                    IdQuestion = reader.GetInt32(1),
                    Reponse = reader.GetString(2),
                    Correct = reader.GetBoolean(3),
                    NbrPoints = reader.GetInt32(4)
                };
                reponses.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return reponses;
        }

        public Reponses FindById(int id)
        {
            Reponses reponses = null;
            request = "SELECT id, idQuestion, reponse, correct, nbrPoints from Reponses where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reponses = new Reponses()
                {
                    Id = reader.GetInt32(0),
                    IdQuestion = reader.GetInt32(1),
                    Reponse = reader.GetString(2),
                    Correct = reader.GetBoolean(3),
                    NbrPoints = reader.GetInt32(4)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return reponses;
        }
    }
}

