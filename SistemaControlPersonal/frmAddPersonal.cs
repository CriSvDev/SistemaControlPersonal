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
    public partial class frmAddPersonal : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public frmAddPersonal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bd.executecommand("INSERT INTO EMPLEADO VALUES ('" + this.txtNombre.Text + "','" + this.txtApellido.Text + "','" + this.txtDni.Text + "','" + this.dtFecha.Text + "','" + this.cboDistrito.Text + "','" + this.txtDireccion.Text + "','" + this.cboEstado.Text + "','" + this.txtIdArea.Text + "')");

            MessageBox.Show("El colaborador: " + txtNombre.Text + " " + txtApellido.Text + " se ha agregado correctamente");
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtIdArea.Clear();
            txtNombre.Focus();
        }
    }
}
