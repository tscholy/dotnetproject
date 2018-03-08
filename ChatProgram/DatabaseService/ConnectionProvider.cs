using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseService
{
    public class ConnectionProvider
    {
        string mysqlConString = "Server=dbsrv.infeo.at;Database=fhv_chat;Uid=fhv_chat_user;Pwd=test;Ssl Mode=None;";


        public IDbConnection GetConnection()
        {
            IDbConnection c = new MySqlConnection(mysqlConString);
            c.Open();
            return c;
        }

    }
}
