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
    public partial class frmAsistencia : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        BaseDeDatos bd = new BaseDeDatos();
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("USP_ADASISTENCIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);
            cmd.Parameters.AddWithValue("@FECHA", dtFecha.Text);
            cmd.Parameters.AddWithValue("@HORA_INGRESO", dtIngreso.Text);
            cmd.Parameters.AddWithValue("@HORA_SALIDA", dtSalida.Text);

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
            dgvAsistencia.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAsistencias");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("USP_UPDASISTENCIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_ASI", txtIdMarcacion.Text);
            cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);
            cmd.Parameters.AddWithValue("@FECHA", dtFecha.Text);
            cmd.Parameters.AddWithValue("@HORA_INGRESO", dtIngreso.Text);
            cmd.Parameters.AddWithValue("@HORA_SALIDA", dtSalida.Text);

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
            dgvAsistencia.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAsistencias");
        }


        private void frmAsistencia_Load(object sender, EventArgs e)
        {
            dgvAsistencia.DataSource = bd.SelectDataTableFromStoreProcedure("usp_MostrarAsistencias");
        }

        private void dgvAsistencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdMarcacion.Text = dgvAsistencia.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIdEmpleado.Text = dgvAsistencia.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtFecha.Text = dgvAsistencia.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtIngreso.Text = dgvAsistencia.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtSalida.Text = dgvAsistencia.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
