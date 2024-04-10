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
    public partial class CRUD : Form
    {
        ConexionSQL sql = new ConexionSQL();
        int existe = 2;
        public CRUD()
        {
            InitializeComponent();
        }


        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                CrudLoad();
                Existe(Convert.ToInt16(txtID.Text));
                if (existe == 1)
                {
                    sql.ValidarDatos(txtID.Text, txtNombre.Text, txtDescripcion.Text);
                    MessageBox.Show("Se agrego correctamente", "Confirmacion");
                    existe = 2;
                }
                if (existe == 0) 
                {
                    MessageBox.Show("Este esta id ya esta registrada, use otra");
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

        public void Existe(int id)
        {
            foreach ( DataGridViewRow data in datos1.Rows)
            {
                if (data.Cells[0].Value != null && data.Cells[0].Value.ToString() == id.ToString()) {
                    existe = 0;
                    break;
                }
                else
                {
                   existe = 1;
                }
            }
            
        }
        public void CrudLoad()
        {
            datos1.DataSource = sql.MostrarRegistros();
        }
    }
}