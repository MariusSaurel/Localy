using Localy.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace Localy.DAO
{
    public static class SqlUtils
    {
        public const int INACTIVITY_TIMEOUT = 600;

        public class SqlConnectInfo
        {
            public SqlConnection Connection
            {
                get;
                internal set;
            }

            public DateTime LastAccess
            {
                get;
                internal set;
            }
        }

        //public static Dictionary<string, SqlConnectInfo> userConnections { get; private set; } = new Dictionary<string, SqlConnectInfo>();

        public static SqlConnection FetchConnection()
        {
            //string login = "$ANONYMOUS*";
            //if (CompteModel.SessionCompte != null && !string.IsNullOrWhiteSpace(CompteModel.SessionCompte.Login))
            //    login = CompteModel.SessionCompte.Login;

            //// Remove all users which have been inactive for INACTIVITY_TIMEOUT seconds or more.
            //int diffCount = userConnections.Count;
            //userConnections = userConnections.Where(o => (DateTime.UtcNow - o.Value.LastAccess).TotalSeconds < INACTIVITY_TIMEOUT).ToDictionary(o => o.Key, o => o.Value);
            //diffCount = diffCount - userConnections.Count;
            //if (diffCount > 0)
            //    Logger.info("Purged " + diffCount + " SQL connection instances.");

            //SqlConnectInfo connectInfo;

            //if (userConnections.ContainsKey(login))
            //{
            //    connectInfo = userConnections[login];
            //    if (connectInfo.Connection.State == ConnectionState.Open)
            //    {
            //        connectInfo.LastAccess = DateTime.UtcNow;
            //        return connectInfo.Connection;
            //    }
            //    userConnections.Remove(login);
            //}

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HOTLINEContext"].ConnectionString);
            connection.Open();
            //userConnections.Add(login, new SqlConnectInfo()
            //{
            //    Connection = connection,
            //    LastAccess = DateTime.UtcNow
            //});

            return connection;
        }
    }
}