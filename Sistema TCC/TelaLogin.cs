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
    public partial class frmTelaLogin : Form
    {
        public frmTelaLogin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.LoginFuncionario = txtLogin.Text;
            funcionario.setSenha(txtSenha.Text);
            EntidadeFuncionario ef = new EntidadeFuncionario();
            if (ef.getUsuarioByFuncionario(funcionario).NomeFuncionario != null)
            {
                this.Visible = false;
                new frmTelaInicial(funcionario).ShowDialog();
            }
            else
            {
                MessageBox.Show("Das duas uma, ou Você digitou errado ou não existe esse Usuario.");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTelaFuncionario tf = new frmTelaFuncionario();
            tf.ShowDialog();
        }
    }
}
