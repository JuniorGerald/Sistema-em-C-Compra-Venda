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
    public partial class frmTelaInicial : Form
    {
        private Funcionario funcionario;

        public frmTelaInicial()
        {
            InitializeComponent();
        }

        public frmTelaInicial(Funcionario funcionario)
        {
            this.funcionario = funcionario;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm;ss");
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblNome.Text = "Bem-Vindo " + funcionario.NomeFuncionario;
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmTelaFuncionario tf = new frmTelaFuncionario();
            tf.ShowDialog();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            frmTelaFornecedor tfn = new frmTelaFornecedor();
            tfn.ShowDialog();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            frmTelaProduto tp = new frmTelaProduto();
            tp.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {

        }

        private void frmTelaInicial_Load(object sender, EventArgs e)
        {
           
        }
    }
}
