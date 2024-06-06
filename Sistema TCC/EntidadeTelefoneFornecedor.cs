using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_TCC
{
  public class EntidadeTelefoneFornecedor
    {
      public static int add(TelefoneFornecedor telefone)
      {
          ConectaBanco cb = new ConectaBanco();
          cb.Conectar();
          String sql = "INSERT INTO tbTelefoneFornecedor (codFornecedor,descricaoTelefoneFornecedor) VALUES (@codFornecedor,@telefone)";
          SqlCommand query = new SqlCommand(sql, cb.getConexao());
          query.Parameters.AddWithValue("@codFornecedor", telefone.CodFornecedor);
          query.Parameters.AddWithValue("@telefone", telefone.Telefone);
          return query.ExecuteNonQuery();
      }

     
    }
}
