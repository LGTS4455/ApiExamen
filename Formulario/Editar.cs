using FormularioExamen.ConexionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioExamen
{
    public partial class Editar : Form
    {
        int existe = 2;
        ConexionSQL sql = new ConexionSQL();
        public Editar()
        {
            InitializeComponent();
            EditarLoad();
        }


        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EditarLoad();
                Existe(Convert.ToInt16(TxtId.Text));
                if (existe == 1)
                {
                    MessageBox.Show("Esta ID no existe", "ERROR");
                }
                if (existe == 0)
                {
                    sql.ActualizarValidacion(TxtId.Text,TxtNombre.Text,TxtDescripcion.Text);
                    MessageBox.Show("Datos actualizados");
                    existe = 2;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show("introduzca el formato correcto\n Si desea ver detalles del error presione SI de lo contrario presione NO", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ex.ToString(), "Detalles");
                }
            }
        }

        public void EditarLoad()
        {
            datos2.DataSource = sql.MostrarRegistros();
        }




        public void Existe(int id)
        {
            foreach (DataGridViewRow data in datos2.Rows)
            {
                if (data.Cells[0].Value != null && data.Cells[0].Value.ToString() == id.ToString())
                {
                    existe = 0;
                    break;
                }
                else
                {
                    existe = 1;
                }
            }

        }

    }
}