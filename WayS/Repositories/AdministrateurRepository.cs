using System.Collections.Generic;
using System.Data.SqlClient;
using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;

namespace WayS.Repositories
{
    class AdministrateurRepository : BaseRepository, IAdministrateur<Administrateur>
    {
        public List<Administrateur> FindByLogin(string login)
        {
            List<Administrateur> administrateur = new List<Administrateur>();
            request = "SELECT login, mdp from admin where login=@login";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@login", login));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                Administrateur c = new Administrateur()
                {
                    Login = reader.GetString(0),
                    Mdp = reader.GetString(1)
                };
                administrateur.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return administrateur;
        }
    }
}
