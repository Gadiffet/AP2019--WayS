using System.Data.SqlClient;

namespace WayS.Tools
{
    class Connection
    {
        private static string stringConnection = @"Server=localhost;Database=WayS;Trusted_Connection=True;";
        public static SqlConnection New { get => new SqlConnection(stringConnection); }

    }
}
