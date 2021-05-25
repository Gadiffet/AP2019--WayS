using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class ClassementReposiory : BaseRepository, IRepository<Classement>
    {
        public Classement Create(Classement element)
        {
            throw new System.NotImplementedException();
        }

        public Classement Delete(Classement element)
        {
            throw new System.NotImplementedException();
        }

        public Classement FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Classement> Listing()
        {
            List<Classement> classement = new List<Classement>();
            request = "SELECT pseudo, score from classement";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classement c = new Classement()
                {
                    Pseudo = reader.GetString(0),
                    Score = reader.GetInt32(1)
                };
                classement.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return classement;
        }

        public Classement Update(Classement element)
        {
            throw new System.NotImplementedException();
        }
    }
}
