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

namespace FormularioExamen.Formulario
{
    public partial class Eliminar : Form
    {
        int existe = 2;
        ConexionSQL sql = new ConexionSQL();
        public Eliminar()
        {
            InitializeComponent();
            EliminarLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Existe(Convert.ToInt16(txtID.Text));
                if (existe == 0)
                {
                    sql.ValidarEliminar(txtID.Text);
                    MessageBox.Show("Se Elimino Correctamente", "Confirmacion");
                    existe = 2;
             
                }
                if (existe ==1)
                {
                    MessageBox.Show("Esta Id no existe");
                    existe = 2;
                
                }
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show("introduzca la ID \n Si desea ver detalles del error presione SI de lo contrario presione NO", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ex.ToString(), "Detalles");
                }
            }
        }
       public void EliminarLoad()
        {
           
            datos3.DataSource = sql.MostrarRegistros();
        }
        public void Existe(int id)
        {
            EliminarLoad();
            foreach (DataGridViewRow data in datos3.Rows)
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
