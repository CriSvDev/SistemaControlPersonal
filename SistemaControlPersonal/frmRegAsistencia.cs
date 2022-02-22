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
using System.Data;

namespace SistemaControlPersonal
{
    public partial class frmRegAsistencia : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        public frmRegAsistencia()
        {
            InitializeComponent();
        }

    private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string idEmpleado = bd.selectstring("select ID_EMP from EMPLEADO where id_emp = " + txtIdEmpleado.Text + "");
            string dni = bd.selectstring("select DNI from EMPLEADO where dni = '" + txtDni.Text + "'");

            if (rbtIngreso.Checked == true)
                if (txtIdEmpleado.TextLength > 0 && txtDni.TextLength > 0)
                {
                    if (idEmpleado == txtIdEmpleado.Text && dni == txtDni.Text)
                    {
                        SqlCommand cmd = new SqlCommand("USP_ADRG_ASIEMPLEADO", cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);
                        cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@HORA_INGRESO", DateTime.Now.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@HORA_SALIDA", DBNull.Value.ToString());
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

            if (rbtSalida.Checked == true)
                if (txtIdEmpleado.TextLength > 0 && txtDni.TextLength > 0)
                {
                    if (idEmpleado == txtIdEmpleado.Text && dni == txtDni.Text)
                    {
                        SqlCommand cmd = new SqlCommand("USP_ADRG_ASIEMPLEADO", cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID_EMP", txtIdEmpleado.Text);
                        cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@HORA_INGRESO", DBNull.Value.ToString());
                        cmd.Parameters.AddWithValue("@HORA_SALIDA", DateTime.Now.ToString("HH:mm"));
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
    }
}