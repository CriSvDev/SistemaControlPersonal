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
    public partial class frmAreas : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public frmAreas()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmAddAreas frmAddAreas = new frmAddAreas();
            frmAddAreas.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAddAreas frmAddAreas = new frmAddAreas();
            frmAddAreas.ShowDialog();
        }

        private void frmAreas_Load(object sender, EventArgs e)
        {
            dgvAreas.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarAreas");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
