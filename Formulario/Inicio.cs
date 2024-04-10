using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using apiexamen;
using FormularioExamen.Formulario;

namespace FormularioExamen
{
    public partial class Inicio : Form
    {
        apiexamen.clsExamen con;
        public Inicio()
        {
            InitializeComponent();
            
            con = new apiexamen.clsExamen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          if (con.Test())
            {
                MessageBox.Show("conexion exitosa ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD mdi = new CRUD();
            mdi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consulta mdi = new Consulta();
            mdi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Editar mdi = new Editar();
            mdi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar mdi = new Eliminar();
            mdi.Show();
        }
    }
}
