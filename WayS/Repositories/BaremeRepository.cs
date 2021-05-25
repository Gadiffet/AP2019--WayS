using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;
namespace WayS.Repositories
{
    class BaremeRepository : BaseRepository, IRepository<Bareme>
    {
        public Bareme Create(Bareme element)
        {
            request = "INSERT INTO Candidat (pseudo, score, age, niveau, experience, localisation, hobby) OUTPUT inserted.id values (@pseudo, @score, @age, @niveau, @experience, @localisation, @hobby)";
            request = "INSERT INTO Candidat (pseudo) OUTPUT inserted.idCandidat values (@pseudo)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element;
        }

        public Bareme Delete(Bareme element)
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

        public Bareme Update(Bareme element)
        {
            request = "UPDATE Candidat SET pseudo=@pseudo, score=@score WHERE id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.Dispose();
            connection.Close();
            return element;
        }

        public List<Bareme> Listing()
        {
            List<Bareme> bareme = new List<Bareme>();
            request = "SELECT id, pseudo, score from Candidat";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Bareme c = new Bareme()
                {
                    Id = reader.GetInt32(0),
                    BaremeTitle = reader.GetString(1),
                    Description = reader.GetString(2)
                };
                bareme.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return bareme;
        }

        public Bareme FindById(int id)
        {
            Bareme candidat = null;
            request = "SELECT id, pseudo, score, age, niveau, experience, localisation, hobby from Candidat where id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                candidat = new Bareme()
                {
                    Id = reader.GetInt32(0),
                };

            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return candidat;
        }

        public List<Bareme> FindByBareme(string baremeTitle)
        {
            List<Bareme> bareme = new List<Bareme>();
            request = "SELECT idBareme, bareme, formationTitle, description from bareme where bareme = @bareme";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@bareme", baremeTitle));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                Bareme c = new Bareme()
                {
                    Id = reader.GetInt32(0),
                    BaremeTitle = reader.GetString(1),
                    FormationTitle = reader.GetString(2),
                    Description = reader.GetString(3)
                };
                bareme.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return bareme;
        }
    }
}
