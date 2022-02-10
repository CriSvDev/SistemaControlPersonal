﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaControlPersonal
{
    public partial class frmAplicacion : Form
    {
        public frmAplicacion()
        {
            InitializeComponent();
        }

        private void btnAdmi_Click(object sender, EventArgs e)
        {
            frmLogeo logeo = new frmLogeo();
            this.Hide();
            logeo.ShowDialog();
            this.Show();

        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            frmAsistencia asi = new frmAsistencia();
            this.Hide();
            asi.ShowDialog();
            this.Show();
        }
    }
}