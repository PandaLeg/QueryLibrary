using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    class Connection
    {
        public MySqlConnection connect;

        public void OpenConnection(string connectionString)
        {
            connect = new MySqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        /*
        public MySqlCommand UdpateD(string query)
        {
            MySqlCommand command = new MySqlCommand(query, this.connect);
            return command;
        }
        */

    }
}
