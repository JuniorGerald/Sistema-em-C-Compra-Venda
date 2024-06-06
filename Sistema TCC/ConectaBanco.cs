using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_TCC
{
   public  class ConectaBanco
    {
        public static String con = @"Data Source=DJW; initial catalog=bdPadariaTCC; Integrated security =true";

        SqlConnection objcon = null;

        public SqlConnection Objcon
        {
            get { return objcon; }
            set { objcon = value; }
        }

        public bool Conectar()
        {
            objcon = new SqlConnection(con);
            try
            {
                objcon.Open();
                return true;
            }
            catch { }
            return false;
        }
        public SqlConnection getConexao()
        {
            return objcon;
        }

        public bool Desconecta()
        {
            if (objcon.State != ConnectionState.Closed)
            {
                objcon.Close();
                objcon.Dispose();
                return true;
            }
            else
            {
                objcon.Dispose();
                return false;
            }
        }
    }
}
