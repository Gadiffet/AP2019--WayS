using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WayS.Repositories
{
    class BaseRepository
    {
        protected SqlCommand command;
        protected SqlDataReader reader;
        protected string request;
        protected SqlConnection connection;
    }
}
