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
    public partial class frmLogeo : Form
    {
        BaseDeDatos bd = new BaseDeDatos(); 
        public frmLogeo()
        {
            InitializeComponent();
        }

        private void cboxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (cboxMostrar.Checked == true)
                {
                    if (txtContrasena.PasswordChar == '*')
                    {
                        txtContrasena.PasswordChar = '\0';
                    }
                }
                else
                {
                    txtContrasena.PasswordChar = '*';
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = bd.selectstring("select USUARIO from USUARIO where usuario = '" + txtUsuario.Text + "'");
            string contraseña = bd.selectstring("select CONTRASENA from USUARIO where contrasena = '" + txtContrasena.Text + "'");

            if (txtUsuario.TextLength > 0 && txtContrasena.TextLength > 0)
            {
                if (usuario == txtUsuario.Text && contraseña == txtContrasena.Text)
                {
                   // Datos.Ac = bd.selectstring("select PERFIL from usuarios where usuario = '" + txtUsuario.TextLength + "'");
                    frmPricipal principal = new frmPricipal();
                    principal.Show();
                    this.Close();
                    frmAplicacion aplicacion = new frmAplicacion();
                    aplicacion.Close();
                }
                else
                {
                    MessageBox.Show("Alguno de los datos es incorrecto");
                }
            }
            else
            {
                MessageBox.Show("Llene los campos correctamente");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {

            frmAplicacion apl = new frmAplicacion();
            this.Close();
            apl.ShowDialog();

        }
    }
}
