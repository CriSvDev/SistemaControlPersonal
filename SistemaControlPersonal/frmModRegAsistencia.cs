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
    public partial class frmModRegAsistencia : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public frmModRegAsistencia()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bd.executecommand("INSERT INTO ASISTENCIA VALUES ('" + this.txtIdEmpleado.Text + "','" + this.dtFecha.Text + "','" + this.dtIngreso.Text + "','" + this.dtSalida.Text + "')");

            MessageBox.Show("El colaborador: " + txtIdEmpleado.Text + " se ha agregado correctamente");
            txtIdEmpleado.Clear();
            txtIdEmpleado.Focus();
        }
    }
}
