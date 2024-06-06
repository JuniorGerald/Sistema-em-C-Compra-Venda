using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_TCC
{
    public class EntidadeProduto
    {
        public int cadastroProduto(Produto p)
        {
            ConectaBanco bb = new ConectaBanco();
            int retorno = 0;

            bb.Conectar();
            String sql = "INSERT INTO tbProduto(nomeProduto, codTipoProduto, quantidadeProduto, valorUnitario, codFornecedor) values(@nome, @codigotipoproduto, @quantidade, @valor, @codigofornecedor)";
            SqlCommand Query = new SqlCommand(sql, bb.getConexao());
            Query.Parameters.AddWithValue("@nome", p.Nome);
            Query.Parameters.AddWithValue("@codigotipoproduto", p.CodigoTipoProduto);
            Query.Parameters.AddWithValue("@quantidade", p.Quantidade);
            Query.Parameters.AddWithValue("@valor", p.Valor);
            Query.Parameters.AddWithValue("@codigofornecedor", p.CodigoFornecedor);




            retorno = Query.ExecuteNonQuery(); 

            return retorno;

        }
        public DataTable TodosProdutos()
        {
            ConectaBanco bb = new ConectaBanco();
            bb.Conectar();
            String sql = "SELECT nomeProduto,codTipoProduto,quantidadeProduto,valorUnitario,codFornecedor from tbProduto ";
            SqlCommand cmd = new SqlCommand(sql, bb.getConexao());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable produtos = new DataTable();
            sda.Fill(produtos);
            bb.Desconecta();
            return produtos;
        }
        public Produto getUsuarioByProduto(Produto produto)
        {

            ConectaBanco bb = new ConectaBanco();
            if (bb.Conectar())
            {
                String sql = "SELECT * from tbProduto where nomeProduto ='" + produto.Nome + "'";
                SqlDataReader sdr;
                SqlCommand sc = new SqlCommand(sql, bb.getConexao());
                sdr = sc.ExecuteReader();
                if (sdr.Read())
                {
                    produto.Codigo = Convert.ToInt32(sdr["codProduto"].ToString());
                    produto.Nome = sdr["nomeProduto"].ToString();
                    bb.Desconecta();

                }

            }
            return produto;
        }
    }
}
