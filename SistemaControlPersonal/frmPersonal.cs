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
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmAddPersonal frmAddPersonal = new frmAddPersonal();
            frmAddPersonal.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAddPersonal frmAddPersonal = new frmAddPersonal();
            frmAddPersonal.ShowDialog();
        }
    }
}
