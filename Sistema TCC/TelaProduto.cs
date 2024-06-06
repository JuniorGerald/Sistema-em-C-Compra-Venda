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
    public partial class frmTelaProduto : Form
    {
        int codigo = 0;
        
        Produto p = new Produto();
        public String operacao;
        public frmTelaProduto()
        {
            InitializeComponent();
            PreencherTabela();
            
        }


        public void alteraBotoes(int op)
        {

            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            cmbFornecedor.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Enabled = false;
            cmbTipoProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValorUnitario.Enabled = false;
            btnEntradaProduto.Enabled = false;
            btnTipoProduto.Enabled = false;


            if (op == 1)
            {
                btnNovo.Enabled = true;

            }

            if (op == 2)
            {

                btnCadastrar.Enabled = true;
                txtNome.Enabled = true;
                cmbFornecedor.Enabled = true;
                btnTipoProduto.Enabled = true;
                btnEntradaProduto.Enabled = true;
                cmbTipoProduto.Enabled = true;
                txtQuantidade.Enabled = true;
                txtValorUnitario.Enabled = true;
               
               
          

            }

            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;

            }

        }

        public void PreencherTabela()
        {

            mostrarProdutos.DataSource = new EntidadeProduto().TodosProdutos();
            mostrarProdutos.AllowUserToResizeRows = true;
            mostrarProdutos.Columns[0].HeaderText = "Nome";
            mostrarProdutos.Columns[1].HeaderText = "Codigo Tipo Produto";
            mostrarProdutos.Columns[2].HeaderText = "Quantidade";
            mostrarProdutos.Columns[3].HeaderText = "Valor";
            mostrarProdutos.Columns[4].HeaderText = "Codigo Fornecedor";



        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }

        private void frmTelaProduto_Load(object sender, EventArgs e)
        {
            alteraBotoes(1);
            ConectaBanco cb = new ConectaBanco();

            EntidadeFornecedor ef = new EntidadeFornecedor();
            cmbFornecedor.DataSource = ef.TodosFornecedores();
            cmbFornecedor.DisplayMember = "nomeFornecedor";
            

            EntidadeTipoProduto et = new EntidadeTipoProduto();
            cmbTipoProduto.DataSource = et.TodosTiposProdutos();
            cmbTipoProduto.DisplayMember = "descricao";
           // cmbTipoProduto.ValueMember = "codTipoProduto";

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            p.Nome = txtNome.Text;
            p.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            p.Valor = Convert.ToInt32(txtValorUnitario.Text);


            MessageBox.Show("Produto cadastrado com sucesso");

            EntidadeProduto ep = new EntidadeProduto();
            ep.cadastroProduto(p);
            PreencherTabela();
            alteraBotoes(3);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "btnAlterar";
            this.alteraBotoes(3);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.operacao = "btnCadastrar";
            this.alteraBotoes(2);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btnTipoProduto_Click(object sender, EventArgs e)
        {
            TelaEntradaProduto tep = new TelaEntradaProduto();
            tep.ShowDialog();
        }

        private void btnTipoProduto_Click_1(object sender, EventArgs e)
        {
            TelaTipoProduto ttp = new TelaTipoProduto();
            ttp.ShowDialog();
        }

        private void mostrarProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(mostrarProdutos.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
