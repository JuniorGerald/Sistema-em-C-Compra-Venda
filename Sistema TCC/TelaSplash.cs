﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_TCC
{
    public partial class frmTelaSplash : Form
    {
        public frmTelaSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbCarrega.Value < 100)
            {
                pbCarrega.Value += 4;
            }
            else
            {
                timer1.Enabled = false;
                this.Visible = false;
                frmTelaLogin tl = new frmTelaLogin();
                tl.ShowDialog();
            }
        }
    }
}
