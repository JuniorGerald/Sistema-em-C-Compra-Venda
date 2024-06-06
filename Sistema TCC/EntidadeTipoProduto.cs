using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_TCC
{
   public class EntidadeTipoProduto
    {

        public int cadastroTipoProduto(TipoProduto tp)
        {
            ConectaBanco bb = new ConectaBanco();
            int retorno = 0;

            bb.Conectar();
            String sql = "INSERT INTO tbTipoProduto(descricao) values(@descricao)";
            SqlCommand Query = new SqlCommand(sql, bb.getConexao());
            Query.Parameters.AddWithValue("@descricao", tp.TipoProduto1);

            retorno = Query.ExecuteNonQuery();
            return retorno;
        }



        public DataTable TodosTiposProdutos()
        {
            ConectaBanco bb = new ConectaBanco();
            bb.Conectar();
            String sql = "SELECT descricao  from tbTipoProduto";
            SqlCommand cmd = new SqlCommand(sql, bb.getConexao());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tipoproduto = new DataTable();
            sda.Fill(tipoproduto);
            bb.Desconecta();
            return tipoproduto;
        }

       
        
    
    }
}
