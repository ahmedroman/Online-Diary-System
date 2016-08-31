using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class CommonGateway
    {
        private string connectionString = 
            WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        protected SqlConnection conn;
        protected SqlCommand command;

        public CommonGateway()
        {
            conn = new SqlConnection(connectionString);
        }
    }
}