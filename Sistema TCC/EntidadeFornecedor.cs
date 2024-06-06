using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_TCC
{
   public  class EntidadeFornecedor
    {
      
        public int cadastroFornecedor(Fornecedor f)
        {
            ConectaBanco bb = new ConectaBanco();
            int retorno = 0;
            
            bb.Conectar();
            String sql = "INSERT INTO tbFornecedor( nomeFornecedor) values(@nome)";
            SqlCommand Query = new SqlCommand(sql, bb.getConexao());
            
            Query.Parameters.AddWithValue("@nome", f.Nome);
           
            retorno = Query.ExecuteNonQuery();
            EntidadeFornecedor ef = new EntidadeFornecedor();
            Fornecedor fornecedor = ef.getUsuarioByFornecedor(f);

            if(fornecedor.Telefone.Count>0)
                foreach (String tel in fornecedor.Telefone)
                {
                    TelefoneFornecedor t = new TelefoneFornecedor();
                    t.Telefone = tel;
                    t.CodFornecedor = f.Codigo;
                    EntidadeTelefoneFornecedor.add(t);
                }
            return retorno;
        }



        public DataTable TodosFornecedores()
        {
            ConectaBanco bb = new ConectaBanco();
            bb.Conectar();
            String sql = "SELECT nomeFornecedor,descricaoTelefoneFornecedor from tbFornecedor inner join tbTelefoneFornecedor on tbFornecedor.codFornecedor=tbTelefoneFornecedor.codFornecedor";
            SqlCommand cmd = new SqlCommand(sql, bb.getConexao());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable fornecedores = new DataTable();
            sda.Fill(fornecedores);
            bb.Desconecta();
            return fornecedores;
        }

       

        public Fornecedor getUsuarioByFornecedor(Fornecedor fornecedor)
        {

            ConectaBanco bb = new ConectaBanco();
            if (bb.Conectar())
            {
                String sql = "SELECT * from tbFornecedor where nomeFornecedor='" + fornecedor.Nome +  "'";
                SqlDataReader sdr;
                SqlCommand sc = new SqlCommand(sql, bb.getConexao());
                sdr = sc.ExecuteReader();
                if (sdr.Read())
                {
                    fornecedor.Codigo = Convert.ToInt32(sdr["codFornecedor"].ToString());
                    fornecedor.Nome = sdr["nomeFornecedor"].ToString();
                    bb.Desconecta();

                }

            }
            return fornecedor;
        }
    
   }
}

