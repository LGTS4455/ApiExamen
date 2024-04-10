using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using apiexamen;
using System.Data;
using System.Collections.ObjectModel;

namespace FormularioExamen.ConexionDB
{
    public class ConexionSQL
    {
        DataTable tabla = new DataTable();
        apiexamen.clsExamen DB = new clsExamen();
        public DataTable MostrarRegistros()
        {
            DataTable tabla = new DataTable();
            tabla = DB.Mostrar();
            return tabla;
        }
        public void ValidarDatos(string id, string nombre, string descripcion)
        {

            DB.Insertar(Convert.ToInt32(id), nombre, descripcion);
        }
        public void ActualizarValidacion(string id, string nombre, string descripcion)
        {

            DB.actualizar(Convert.ToInt32(id), nombre, descripcion);
        }
        public void ValidarEliminar(string id)
        {
            DB.Eliminar(Convert.ToInt32(id));
        }

    }
 }

