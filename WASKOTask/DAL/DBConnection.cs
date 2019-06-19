using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WASKOTask.DAL
{
    class DBConnection
    { 
        static DBConnection instance = null;
        public static DBConnection Instance
        {
            get { return instance ?? (instance = new DBConnection()); }
        }

        public MySqlConnection Connection { get; private set; }

        private DBConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();

            connectionString.Server = ConnectionParameters.server;
            connectionString.Database = ConnectionParameters.database;
            connectionString.UserID = ConnectionParameters.user;
            connectionString.Password = ConnectionParameters.password;

            Connection = new MySqlConnection(connectionString.ToString());
        }
    }
}
