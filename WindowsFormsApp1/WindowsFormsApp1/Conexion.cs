using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Conexion
    {
        public  MySqlConnection conexion()
        {

            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "admin12345";
            string bd = "control";

            string query = "Database=" + bd + "; Data Source=" + servidor + "; Port=" + puerto + "; User Id=" + usuario + "; Password=" + password;





            try
            {

                MySqlConnection ConexionBD = new MySqlConnection(query);
                return ConexionBD;



            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



        }
    }
}
