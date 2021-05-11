using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WayS.Tools
{
    class Connection
    {
        private static string stringConnection = @"Server=localhost;Database=master;Trusted_Connection=True;";
        public static SqlConnection New { get => new SqlConnection(stringConnection); }
    }
}
