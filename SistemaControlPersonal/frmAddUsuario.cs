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
    public partial class frmAddUsuario : Form
    {

        BaseDeDatos bd = new BaseDeDatos();
        public frmAddUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bd.executecommand("INSERT INTO USUARIO VALUES ('"+ this.txtUsuario.Text + "','" + this.txtContra.Text + "','" + this.txtPerfil.Text + "','" + this.cboEstado.Text + "','" + this.txtIdEmpleado.Text + "')");

            MessageBox.Show("El usuario: " + txtUsuario.Text + " se ha agregado correctamente");
            txtUsuario.Clear();
            txtContra.Clear();
            txtPerfil.Clear();
            txtIdEmpleado.Clear();
            txtUsuario.Focus();
        }
    }
}
