﻿using WayS.Interfaces;
using WayS.Models;
using WayS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WayS.Repositories
{
    class ReponsesRepository : BaseRepository, IRepository<Reponses>
    {
        public void Create(Reponses element)
        {
            request = "INSERT INTO Reponses (idQuestion, reponse, correct, nbrPoints) OUTPUT inserted.id values (@reponse, @correct, @nbrPoints)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idQuestion", element.IdQuestion));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }

        public void Delete(Reponses element)
        {
            request = "DELETE FROM Reponses where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public void Update(Reponses element)
        {
            request = "UPDATE Reponses SET reponse=@reponse, correct=@correct, nbrPoints=@nbrPoints WHERE id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@reponse", element.Reponse));
            command.Parameters.Add(new SqlParameter("@correct", element.Correct));
            command.Parameters.Add(new SqlParameter("@nbrPoints", element.NbrPoints));
            connection.Open();
            command.Dispose();
            connection.Close();
        }

        public List<Reponses> Listing()
        {
            List<Reponses> reponses = new List<Reponses>();
            request = "SELECT id, idQuestion, reponse, correct, nbrPoints from Reponses";
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
