using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_TCC
{
    public partial class TelaTipoProduto : Form
    {
        TipoProduto tp = new TipoProduto();
        public TelaTipoProduto()
        {
            InitializeComponent();
        }

        public void PreencherTabela()
        {

            mostrarTiposProdutos.DataSource = new EntidadeTipoProduto().TodosTiposProdutos();
            mostrarTiposProdutos.AllowUserToResizeRows = true;
            mostrarTiposProdutos.Columns[0].HeaderText = "Descrição";
            



        }
        private void TelaTipoProduto_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            tp.TipoProduto1 = txtDescricao.Text;

            MessageBox.Show("Tipo de Produto cadastrado com sucesso");

            EntidadeTipoProduto etp = new EntidadeTipoProduto();
            etp.cadastroTipoProduto(tp);
            PreencherTabela();
            
        }
    }
}
