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
    public partial class frmAreas : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        BaseDeDatos bd = new BaseDeDatos();
        public frmAreas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_ADAREA", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
            cmd.Parameters.AddWithValue("@OFICINA", txtOficina.Text);
            cmd.Parameters.AddWithValue("@DIREC", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);

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
            dgvAreas.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAreas");
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_ADAREA", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_AREA", txtIdArea.Text);
            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
            cmd.Parameters.AddWithValue("@OFICINA", txtOficina.Text);
            cmd.Parameters.AddWithValue("@DIREC", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@ESTADO", cboEstado.Text);

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
            dgvAreas.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAreas");
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("USP_DELAREA", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_AREA", txtIdArea.Text);

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
            dgvAreas.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAreas");
        }


        private void frmAreas_Load(object sender, EventArgs e)
        {
            dgvAreas.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAreas");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdArea.Text = dgvAreas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvAreas.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOficina.Text = dgvAreas.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDireccion.Text = dgvAreas.Rows[e.RowIndex].Cells[3].Value.ToString();
            cboEstado.Text = dgvAreas.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void txtOficina_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
         else if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;

        }
    }
}
