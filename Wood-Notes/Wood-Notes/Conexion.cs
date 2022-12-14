using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Wood_Notes
{
    public class Conexion
    {
        static string conexionstring = "server= DESKTOP-DGI3QEQ\\SQLEXPRESS; database= WoodNotesDB; integrated security= true";
        SqlConnection conexion = new SqlConnection(conexionstring);

        public void AbrirConexion()
        {
            conexion.Open();
            //MessageBox.Show("se conecto con " + conexion.Database);
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }

        public void InsertarNotas(string Titulo, string Nota, string Fecha)
        {
            string cadena = "insert into UserNotes([Titulo],[Contenido],[Fecha]) values ('" + Titulo + "','" + Nota + "','" + Fecha + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
        }

        public DataTable ConsultaNotas()
        {
            string query = "Select * from UserNotes";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter dataInfo = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            dataInfo.Fill(tabla);
            return tabla;
        }
        public DataTable BusquedaNotas(string Titulo)
        {
            string query = "Select * from UserNotes where Titulo = '" + Titulo + "'";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter dataInfo = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            dataInfo.Fill(tabla);
            return tabla;
        }
    }
}
