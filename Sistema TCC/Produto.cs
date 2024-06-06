using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema_TCC
{
  public class Produto
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private int quantidade;

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private int codigoFornecedor;

        public int CodigoFornecedor
        {
            get { return codigoFornecedor; }
            set { codigoFornecedor = value; }
        }
        private int codigoTipoProduto;

        public int CodigoTipoProduto
        {
            get { return codigoTipoProduto; }
            set { codigoTipoProduto = value; }
        }



    }
}
