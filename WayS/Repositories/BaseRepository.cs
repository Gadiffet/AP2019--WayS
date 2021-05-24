using System.Data.SqlClient;

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
