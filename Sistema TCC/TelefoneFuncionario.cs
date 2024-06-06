using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_TCC
{
    public class TelefoneFuncionario
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private int codFuncionario;

        public int CodFuncionario
        {
            get { return codFuncionario; }
            set { codFuncionario = value; }
        }
        private String telefone;

        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

    }
}
