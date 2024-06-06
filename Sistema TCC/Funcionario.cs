using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

namespace Sistema_TCC
{
    public class Funcionario
    {
       
        private int codFuncionario;
        public int CodFuncionario
        {
            get { return codFuncionario; }
            set { codFuncionario = value; }
        }

        private ArrayList telefone = new ArrayList();

        public ArrayList Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
       
        private String nomeFuncionario;
        public String NomeFuncionario
        {
            get { return nomeFuncionario; }
            set { nomeFuncionario = value; }
        }
       
        private String cpfFuncionario;
        public String CpfFuncionario
        {
            get { return cpfFuncionario; }
            set { cpfFuncionario = value; }
        }
       
        private String loginFuncionario;
        public String LoginFuncionario
        {
            get { return loginFuncionario; }
            set { loginFuncionario = value; }
        }
       
        private String senhaFuncionario;
        public void setSenha(String senhaFuncionario)
        {
            StringBuilder senhaCripto = new StringBuilder();
            MD5 md5 = MD5.Create();

            Byte[] entrada = Encoding.ASCII.GetBytes(senhaFuncionario);
            Byte[] hash = md5.ComputeHash(entrada);
            for (int i = 0; i < hash.Length; i++)
                senhaCripto.Append(hash[i].ToString("X2"));
            this.senhaFuncionario = senhaCripto.ToString();
        }

        public String Senha
        {
            get { return senhaFuncionario; }
        }
    }
}
