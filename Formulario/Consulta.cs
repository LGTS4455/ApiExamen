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
    public partial class Consulta : Form
    {
        ConexionSQL conexionSQL;
        public Consulta()
        {
            conexionSQL = new ConexionSQL();
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            datos2.DataSource = conexionSQL.MostrarRegistros();
            datos2.AlternatingRowsDefaultCellStyle.BackColor = Color.Cyan;
            datos2.RowsDefaultCellStyle.BackColor = Color.Aquamarine;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
