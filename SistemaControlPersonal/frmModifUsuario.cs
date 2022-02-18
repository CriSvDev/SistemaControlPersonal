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
    public partial class frmModifUsuario : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public frmModifUsuario()
        {
            InitializeComponent();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bd.executecommand("UPDATE USUARIO SET USUARIO = '" + txtUsuario.Text + "' WHERE ID = '");

            MessageBox.Show("El actualizo registro correctamente");
            txtUsuario.Clear();
            txtUsuario.Focus();
        }
    }
}
