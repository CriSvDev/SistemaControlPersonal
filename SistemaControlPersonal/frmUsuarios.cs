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
    public partial class frmUsuarios : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAddUsuario frmAddUsuario = new frmAddUsuario();
            frmAddUsuario.ShowDialog();

        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) || !string.IsNullOrEmpty(txtUsuario.Text) || !string.IsNullOrEmpty(txtEstado.Text))
            {
                dgvUsuarios.DataSource = bd.SelectDataTable("select * from USUARIO where ID_USUARIO = '" + txtID.Text + "' OR USUARIO = '" + txtUsuario.Text + "' OR ESTADO = '" + txtEstado.Text + "'");
            }
            else
            {
                MessageBox.Show("Ingrese criterios de busqueda");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModifUsuario frmModiUsuario = new frmModifUsuario();
            frmModiUsuario.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarUsuarios");
        }
    }
}
