using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class AdministrateurRepository : BaseRepository, IAdministrateur<Administrateur>
    {
        public Administrateur FindByLogin(string login)
        {
            Administrateur administrateur = null;
            request = "SELECT login, mdp from administrateur where login = @login";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@login", login));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                administrateur = new Administrateur()
                {
                    Login = reader.GetString(1),
                    Mdp = reader.GetString(2)
                };

            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return administrateur;
        }
    }
}
