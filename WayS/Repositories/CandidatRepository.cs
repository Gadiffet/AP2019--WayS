using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class CandidatRepository : BaseRepository, IRepository<Candidat>
    {
        public Candidat Create(Candidat element)
        {
            request = "INSERT INTO candidat (pseudo, score, age, niveau, experience, localisation, hobby) VALUES (@pseudo, @score, @age, @niveau, @experience, @localisation, @hobby)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@pseudo", element.Pseudo));
            command.Parameters.Add(new SqlParameter("@score", element.Score));
            command.Parameters.Add(new SqlParameter("@age", element.Age));
            command.Parameters.Add(new SqlParameter("@niveau", element.Niveau));
            command.Parameters.Add(new SqlParameter("@experience", element.Experience));
            command.Parameters.Add(new SqlParameter("@localisation", element.Localisation));
            command.Parameters.Add(new SqlParameter("@hobby", element.Hobby));
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Candidat Delete(Candidat element)
        {
            request = "DELETE FROM Candidat where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Candidat Update(Candidat element)
        {
            request = "UPDATE Candidat SET pseudo=@pseudo, score=@score WHERE id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@pseudo", element.Pseudo));
            command.Parameters.Add(new SqlParameter("@score", element.Score));
            connection.Open();
            command.Dispose();
            connection.Close();
            return element;
        }

        public List<Candidat> Listing()
        {
            List<Candidat> candidat = new List<Candidat>();
            request = "SELECT id, pseudo, score from Candidat";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Candidat c = new Candidat()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Score = reader.GetInt32(2)
                };
                candidat.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return candidat;
        }

        public Candidat FindById(int id)
        {
            Candidat candidat = null;
            request = "SELECT id, pseudo, score, age, niveau, experience, localisation, hobby from Candidat where id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                candidat = new Candidat()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Score = reader.GetInt32(2),
                    Age = reader.GetInt32(3),
                    Niveau = reader.GetString(4),
                    Experience = reader.GetInt32(5),
                    Localisation = reader.GetString(6),
                    Hobby = reader.GetString(7)
                };

            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return candidat;
        }
    }
}

