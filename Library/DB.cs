using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library;



namespace Library
{
    /// <summary>
    /// <c>DB</c> class that helps to get the info from MySQL database
    /// </summary>
    /// <remarks>That class can open, close and return the state of connection with local database</remarks>
    public class DB
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=uroborosmenu;password=admin");
        /// <summary>
        /// Open connection with database
        /// </summary>
        public void OpenConnection()
        {
            //if the connection is closed, then open it
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        /// <summary>
        /// Close connection with database
        /// </summary>
        public void CloseConnection()
        {
            //if the connection was opened, then close it
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        /// <summary>
        /// State of connection with database
        /// </summary>
        /// <returns>connection</returns>
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
