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
    public partial class frmPersonal : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
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

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            dgvPersonal.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarEmpleados");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
