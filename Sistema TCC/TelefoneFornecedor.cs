using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_TCC
{
   public  class TelefoneFornecedor
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private int codFornecedor;

        public int CodFornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
        }
        private String telefone;

        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
    }
}
