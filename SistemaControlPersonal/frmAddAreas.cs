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
    public partial class frmAddAreas : Form
    {

        BaseDeDatos bd = new BaseDeDatos();
        public frmAddAreas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bd.executecommand("INSERT INTO AREA VALUES ('" + this.txtNombre.Text + "','" + this.txtOficina.Text + "','" + this.cboEstado.Text+ "')");

            MessageBox.Show("El area: " + txtNombre.Text + " se ha agregado correctamente");
            txtNombre.Clear();
            txtOficina.Clear();
            txtNombre.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
