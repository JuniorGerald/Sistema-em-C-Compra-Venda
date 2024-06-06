using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Sistema_TCC
{
   public class EntidadeTelefoneFuncionario
    {
       public static int add(TelefoneFuncionario telefone)
       {
           ConectaBanco cb = new ConectaBanco();
           cb.Conectar();
           String sql = "INSERT INTO tbTelefoneFuncionario (codFuncionario,descricaoTelefoneFuncionario) VALUES (@codFuncionario,@telefone)";
           SqlCommand query = new SqlCommand(sql, cb.getConexao());
           query.Parameters.AddWithValue("@codFuncionario", telefone.CodFuncionario);
           query.Parameters.AddWithValue("@telefone", telefone.Telefone);
           return query.ExecuteNonQuery();
       }

    }
}
