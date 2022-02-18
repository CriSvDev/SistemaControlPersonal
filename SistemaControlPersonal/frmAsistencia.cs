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
    public partial class frmAsistencia : Form
    {
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmModRegAsistencia frmModRegAsis = new frmModRegAsistencia(); 
            frmModRegAsis.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModRegAsistencia frmModRegAsis = new frmModRegAsistencia();
            frmModRegAsis.ShowDialog();

        }
    }
}
