using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Actualizar evento = new Actualizar();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            evento.EventoActualizar += Evento_EventoActualizar;
            evento.otroEvento += Evento_otroEvento;
        }

        private void Evento_otroEvento()
        {
            
            cargartable(null);
        }

        private void Evento_EventoActualizar()
        {

            
            txtid.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdescripcion.Text = "";
            txtunidades.Text = "";
            cargartable(null);          

        }

        private void button1_Click(object sender, EventArgs e)
        {

            RegistroMaterial material = new RegistroMaterial();
            material.nombre = txtnombre.Text;
            material.apellido = txtapellido.Text;
            material.descripcion = txtdescripcion.Text;
            material.unidades = int.Parse(txtunidades.Text);

            ControlMaterial control = new ControlMaterial();
            if (txtid.Text != "")
            {

                material.id = int.Parse(txtid.Text);
                control.actualizar(material);
             
            }
            else
            {
                control.insertar(material);
                MessageBox.Show("guardado con exito");
                                
            }

            Evento_EventoActualizar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cargartable(string dato)
        {
            List<RegistroMaterial> lista = new List<RegistroMaterial>();
            
            ControlMaterial material = new ControlMaterial();
            dataGridView1.DataSource = material.consulta(dato);

        }

      
        private void txtmodificar_Click(object sender, EventArgs e)
        {
            ControlMaterial control = new ControlMaterial();
           
            txtid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtnombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtapellido.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtunidades.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void txteliminar_Click(object sender, EventArgs e)
        {
            
                int id = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                ControlMaterial control = new ControlMaterial();

                control.eliminar(id);
                Evento_EventoActualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
    
           string dato = textBox1.Text;
            Evento_otroEvento();

            cargartable(dato);
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
