using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class CompteMessagerieRepository : BaseRepository, IRepository<CompteMessagerie>
    {
        public void Create(CompteMessagerie element)
        {
            request = "INSERT INTO CompteMessagerie (adresseMail, message) OUTPUT inserted.id values (@adresseMail, @message)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@adresseMail", element.AdresseMail));
            command.Parameters.Add(new SqlParameter("@message", element.Message));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }

        public void Delete(CompteMessagerie element)
        {
            request = "DELETE FROM CompteMessagerie where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public void Update(CompteMessagerie element)
        {
            request = "UPDATE CompteMessagerie SET adresseMail=@adresseMail, message=@message WHERE id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@adresseMail", element.AdresseMail));
            command.Parameters.Add(new SqlParameter("@message", element.Message));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public List<CompteMessagerie> Listing()
        {
            List<CompteMessagerie> compteMessagerie = new List<CompteMessagerie>();
            request = "SELECT id, adresseMail, message from CompteMessagerie";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CompteMessagerie c = new CompteMessagerie()
                {
                    Id = reader.GetInt32(0),
                    AdresseMail = reader.GetString(1),
                    Message = reader.GetString(2)
                };
                compteMessagerie.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return compteMessagerie;
        }

        public CompteMessagerie FindById(int id)
        {
            CompteMessagerie compteMessagerie = null;
            request = "SELECT id, adresseMail, message from CompteMessagerie where id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                compteMessagerie = new CompteMessagerie()
                {
                    Id = reader.GetInt32(0),
                    AdresseMail = reader.GetString(1),
                    Message = reader.GetString(2)
                };

            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return compteMessagerie;
        }
    }
}
