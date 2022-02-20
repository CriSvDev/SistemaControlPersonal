using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace SistemaControlPersonal
{

    public partial class frmUsuarios : Form
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        BaseDeDatos bd = new BaseDeDatos();
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_ADUSUARIOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USUARIO", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@CONTRASENA", txtContra.Text);
            cmd.Parameters.AddWithValue("@PERFIL", txtPerfil.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);
            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);

            cn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i.ToString() + " registro agregado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            dgvUsuarios.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarUsuarios");
        }

    private void btnModificar_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("USP_UPDUSUARIOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USUARIO", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@CONTRASENA", txtContra.Text);
            cmd.Parameters.AddWithValue("@PERFIL", txtPerfil.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);
            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);

            cn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i.ToString() + " registro actualizado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            dgvUsuarios.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarUsuarios");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarUsuarios");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_DELUSUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USUARIO", txtUsuario.Text);

            cn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i.ToString() + " registro eliminado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            dgvUsuarios.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarUsuarios");
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtContra.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPerfil.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            cboEstado.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtIdEmpleado.Text = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}

