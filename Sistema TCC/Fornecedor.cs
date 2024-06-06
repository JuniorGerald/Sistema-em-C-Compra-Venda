using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sistema_TCC
{
   public class Fornecedor
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
       private String nome;
       

        private ArrayList telefone = new ArrayList();

        public ArrayList Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
     

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    
    }
}
