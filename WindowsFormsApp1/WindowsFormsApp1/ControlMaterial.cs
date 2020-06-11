using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ControlMaterial:Conexion
    {
        RegistroMaterial _productos;
        
        

        public void insertar(RegistroMaterial informacion)
        {
           
            string sql = "INSERT INTO productos(nombre,apellido,descripcion,unidades)VALUES('" + informacion.nombre + "','"
            + informacion.apellido + "','" + informacion.descripcion + "','" + informacion.unidades + "')";

            try
            {
                MySqlConnection conexion = base.conexion();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message, ToString());

            }
           

        }
        public void actualizar(RegistroMaterial informacion)
        {
           
            string sql = "UPDATE productos SET nombre='" + informacion.nombre + "',apellido='" + informacion.apellido + "',descripcion='" + informacion.descripcion + "',unidades='" + informacion.unidades + "'WHERE id='"+informacion.id + "'";

            try
            {
                MySqlConnection conexion = base.conexion();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message, ToString());
              
            }
          

        }

        public void eliminar(int id)
        {
           
            string sql = "DELETE FROM productos WHERE id='" + id +  "'";

            try
            {
                MySqlConnection conexion = base.conexion();
                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
               
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message, ToString());
               
            }
           
        }
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<Object>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT id ,nombre,apellido,descripcion,unidades FROM productos";
            }
            else
            {
                sql = "SELECT id ,nombre,apellido,descripcion,unidades FROM productos WHERE nombre LIKE '%" + dato + "%'OR apellido LIKE'%" + dato + "%'OR descripcion LIKE'%" + dato + "%'OR unidades LIKE' %" + dato + "%'";




            }


            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    _productos = new RegistroMaterial();
                    _productos.id = int.Parse(reader.GetString(0));
                    _productos.nombre = reader.GetString(1);
                    _productos.apellido = reader.GetString(2);
                    _productos.descripcion = reader.GetString(3);
                    _productos.unidades = int.Parse(reader.GetString(4));


                    lista.Add(_productos);


                }



            }

            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }
    }
}
