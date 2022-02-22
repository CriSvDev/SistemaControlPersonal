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

        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            frmRegAsistencia asi = new frmRegAsistencia();
            this.Hide();
            asi.ShowDialog();
            this.Show();
        }

        private void frmAplicacion_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
