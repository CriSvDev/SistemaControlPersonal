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
    public partial class frmPersonal : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        BaseDeDatos bd = new BaseDeDatos();
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_ADEMPLEADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
            cmd.Parameters.AddWithValue("@APELLIDO", txtApellido.Text);
            cmd.Parameters.AddWithValue("@DNI", txtDni.Text);
            cmd.Parameters.AddWithValue("@FECHA_NAC", dtFecha.Text);
            cmd.Parameters.AddWithValue("@DISTRITO", cboDistrito.Text);
            cmd.Parameters.AddWithValue("@DIR_DOM", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);
            cmd.Parameters.AddWithValue("@ID_AREA", txtIdArea.Text);

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
            dgvPersonal.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarEmpleados");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_UPDEMPLEADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmp.Text);
            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
            cmd.Parameters.AddWithValue("@APELLIDO", txtApellido.Text);
            cmd.Parameters.AddWithValue("@DNI", txtDni.Text);
            cmd.Parameters.AddWithValue("@FECHA_NAC", dtFecha.Text);
            cmd.Parameters.AddWithValue("@DISTRITO", cboDistrito.Text);
            cmd.Parameters.AddWithValue("@DIR_DOM", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);
            cmd.Parameters.AddWithValue("@ID_AREA", txtIdArea.Text);

            cn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i.ToString() + " registro Actualizado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            dgvPersonal.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarEmpleados");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_DELEMPLEADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmp.Text);

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
            dgvPersonal.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarEmpleados");
        }


        private void frmPersonal_Load(object sender, EventArgs e)
        {
            dgvPersonal.DataSource = bd.SelectDataTableFromStoreProcedure("sp_MostrarEmpleados");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdEmp.Text = dgvPersonal.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvPersonal.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtApellido.Text = dgvPersonal.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDni.Text = dgvPersonal.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtFecha.Text = dgvPersonal.Rows[e.RowIndex].Cells[4].Value.ToString();
            cboDistrito.Text = dgvPersonal.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDireccion.Text = dgvPersonal.Rows[e.RowIndex].Cells[6].Value.ToString();
            cboEstado.Text = dgvPersonal.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtIdArea.Text = dgvPersonal.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
    }
}
