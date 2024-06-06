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
    public partial class frmTelaFuncionario : Form
    {
        public String operacao;
        Funcionario f = new Funcionario();
        public frmTelaFuncionario()
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
         
            txtNome.Enabled = false;
            mktTelefone.Enabled = false;
            btnExcluirFuncionario.Enabled = false;
            lstTelefones.Enabled = false;
            mktCpf.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirme.Enabled = false;

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
               
                txtConfirme.Enabled = true;
                btnExcluirFuncionario.Enabled = true;
                
               
                mktCpf.Enabled = true;
                txtLogin.Enabled = true;
                txtSenha.Enabled = true;
                txtConfirme.Enabled = true;
            }

            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluirFuncionario.Enabled = true;

            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            
            this.operacao = "btnCadastrar";
            this.alteraBotoes(2);
        }

        private void frmTelaFuncionario_Load(object sender, EventArgs e)
        {
            alteraBotoes(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstTelefones.Items.Add(mktTelefone.Text);
            f.Telefone.Add(mktTelefone.Text);
            mktTelefone.Clear();
            mktTelefone.Focus();
        }


        public void PreencherTabela()
        {

            MostrarFuncionario.DataSource = new EntidadeFuncionario().TodosFuncionarios();
            MostrarFuncionario.AllowUserToResizeRows = true;
            MostrarFuncionario.Columns[0].HeaderText = "Nome";
            MostrarFuncionario.Columns[1].HeaderText = "CPF";
            MostrarFuncionario.Columns[2].HeaderText = "Login";
            MostrarFuncionario.Columns[3].HeaderText = "Telefone";

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            
            if (txtSenha.Text.Equals(txtConfirme.Text))
            {
            
                f.NomeFuncionario=txtNome.Text;
                f.CpfFuncionario=mktCpf.Text;
                f.LoginFuncionario = txtLogin.Text;
                f.setSenha(txtSenha.Text);

                if (EntidadeFuncionario.cadastroFuncionario(f) == 1)
                {
                    MessageBox.Show("Cadastro realizado com sucesso");
                    txtNome.Clear();
                    txtLogin.Clear();
                    txtConfirme.Clear();
                    txtSenha.Clear();
                    mktCpf.Clear();
                    txtNome.Focus();
                    PreencherTabela();
                    alteraBotoes(3);
                }
            }  
            else
            {
                MessageBox.Show("Erro", "Digite a senha corretamente!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirme.Clear();
                txtSenha.Clear();
            }
           
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "btnAlterar";
            this.alteraBotoes(3);
        }
        
    }
}
