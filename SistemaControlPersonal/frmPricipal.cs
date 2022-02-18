using System;
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
    public partial class frmPricipal : Form
    {
        public frmPricipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AbrirFormInPanel(object FormHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }


        private void btnPersonal_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmPersonal());
        }
        private void btnMantenimiento_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmUsuarios());

        }

        private void btnAreas_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAreas());
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAsistencia());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmReportes());
        }
    }
}
