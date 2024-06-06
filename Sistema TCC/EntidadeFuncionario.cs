using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_TCC
{
   public class EntidadeFuncionario
    {
        public static int cadastroFuncionario(Funcionario f)
        {
            int retorno = 0;
            ConectaBanco bb = new ConectaBanco();
            bb.Conectar();
            String sql = "INSERT INTO tbFuncionario(nomeFuncionario, cpfFuncionario, loginFuncionario, senhaFuncionario) values(@nome,@cpf,@login,@senha)";
            SqlCommand Query = new SqlCommand(sql, bb.getConexao());
            Query.Parameters.AddWithValue("@nome", f.NomeFuncionario);
            Query.Parameters.AddWithValue("@cpf", f.CpfFuncionario);
            Query.Parameters.AddWithValue("@login", f.LoginFuncionario);
            Query.Parameters.AddWithValue("@senha", f.Senha);

            retorno = Query.ExecuteNonQuery();
            EntidadeFuncionario ef = new EntidadeFuncionario();
            Funcionario funcionario = ef.getUsuarioByFuncionario(f);

            if (funcionario.Telefone.Count > 0)
                foreach (String tel in funcionario.Telefone)
                {
                    TelefoneFuncionario t = new TelefoneFuncionario();
                    t.Telefone = tel;
                    t.CodFuncionario = f.CodFuncionario;
                    EntidadeTelefoneFuncionario.add(t);
                }
            return retorno;
        }



        public DataTable TodosFuncionarios()
        {
            ConectaBanco cb = new ConectaBanco();
            cb.Conectar();
            String sql = "SELECT nomeFuncionario,cpfFuncionario,loginFuncionario,descricaoTelefoneFuncionario from tbFuncionario inner join tbTelefoneFuncionario on tbFuncionario.codFuncionario=tbTelefoneFuncionario.codFuncionario";
            SqlCommand cmd = new SqlCommand(sql, cb.getConexao());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable fornecedores = new DataTable();
            sda.Fill(fornecedores);
            cb.Desconecta();
            return fornecedores;
        }

        public Funcionario getUsuarioByFuncionario(Funcionario funcionario)
        {

            ConectaBanco cb = new ConectaBanco();
            if (cb.Conectar())
            {
                String sql = "SELECT * from tbFuncionario where loginFuncionario='" + funcionario.LoginFuncionario + "' AND senhaFuncionario='" + funcionario.Senha + "'";
                SqlDataReader sdr;
                SqlCommand sc = new SqlCommand(sql, cb.getConexao());
                sdr = sc.ExecuteReader();
                if (sdr.Read())
                {
                    funcionario.CodFuncionario = Convert.ToInt32(sdr["codFuncionario"].ToString());
                    funcionario.NomeFuncionario = sdr["nomeFuncionario"].ToString();
                    funcionario.LoginFuncionario = sdr["loginFuncionario"].ToString();
                    cb.Desconecta();

                }

            }
            return funcionario;
        }
    }
}
