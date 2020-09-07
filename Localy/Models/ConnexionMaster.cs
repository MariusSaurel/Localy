using Localy.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Localy.Models
{
    public abstract class ConnexionMaster<T>
    {
        protected SqlConnection connect = SqlUtils.FetchConnection();

        public ConnexionMaster()
        {
        }

        //public abstract bool Create(T obj);

        //public abstract bool Delete(T obj);

        //public abstract bool Update(T obj);

        //public abstract T find(T id);
    }
}