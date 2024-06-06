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
    public partial class frmTelaFornecedor : Form
    {
        int codigo = 0;
        public String operacao;
        Fornecedor f = new Fornecedor();
        public frmTelaFornecedor()
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
            btnAdicionar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Enabled = false;
            mktTelefone.Enabled = false;
            btnExcluirProuto.Enabled = false;
            lstTelefones.Enabled = false;
         

            if (op == 1)
            {
                btnNovo.Enabled = true;

            }

            if (op == 2)
            {

                btnCadastrar.Enabled = true;
                txtNome.Enabled = true;
                mktTelefone.Enabled = true;
                btnAdicionar.Enabled = true;
                btnExcluir.Enabled = true;
                lstTelefones.Enabled = true;
              
            }

            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluirProuto.Enabled = true;

            }

        }

        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            alteraBotoes(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void PreencherTabela()
        {

            MostrarFornecedor.DataSource = new EntidadeFornecedor().TodosFornecedores();
            MostrarFornecedor.AllowUserToResizeRows = true;
          
            MostrarFornecedor.Columns[0].HeaderText = "Nome";
            MostrarFornecedor.Columns[1].HeaderText = "Telefone";
         
            
            
        }



        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           
            
            f.Nome = txtNome.Text;
            
            MessageBox.Show("Fornecedor cadastrado com sucesso");

            EntidadeFornecedor ef = new EntidadeFornecedor();
            ef.cadastroFornecedor(f);
            PreencherTabela();
            alteraBotoes(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            
            lstTelefones.Items.Add(mktTelefone.Text);
            f.Telefone.Add(mktTelefone.Text);
            mktTelefone.Clear();
            mktTelefone.Focus();
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "btnAlterar";
            this.alteraBotoes(3);
            txtNome.Enabled = true;
            btnCadastrar.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.operacao = "btnCadastrar";
            this.alteraBotoes(2);
        }

        private void MostrarFornecedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(MostrarFornecedor.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
