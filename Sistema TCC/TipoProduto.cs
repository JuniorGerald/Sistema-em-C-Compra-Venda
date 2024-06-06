using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_TCC
{
    public class TipoProduto
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String tipoProduto;

        public String TipoProduto
        {
            get { return tipoProduto; }
            set { tipoProduto = value; }
        }
    }
}
