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
        public frmAddUsuario()
        {
            InitializeComponent();
        }

        BaseDeDatos bd = new BaseDeDatos();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bd.executecommand("INSERT USUARIO ([USUARIO],[CONTRASENA],[PERFIL],[ESTADO],[ID_EMP])" + "VALUES ('" + this.txtUsuario.Text + "','" + this.txtContra.Text + "','" + this.txtPerfil.Text + "','" + this.txtEstado.Text + "'" + this.txtIdEmpleado.Text + "')");

            MessageBox.Show("El usuario: " + txtUsuario.Text + " se ha agregado correctamente");
            txtUsuario.Clear();
            txtContra.Clear();
            txtPerfil.Clear();
            txtEstado.Clear();
            txtIdEmpleado.Clear();
            txtUsuario.Focus();
        }
    }
}
