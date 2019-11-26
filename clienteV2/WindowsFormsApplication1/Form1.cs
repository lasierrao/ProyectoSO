using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IP.Text);
            IPEndPoint ipep = new IPEndPoint(direc, 9052);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string mensaje = "20/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //No necesitamos recibir respuesta
            //byte[] msg2 = new byte[80];
            //server.Receive(msg2);
            //mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }

        private void Registrarse_Click(object sender, EventArgs e)
        {
            //Enviamos 2 strings con la condició que la contraseña sea la misma en los dos txt box
            string Usuario = txtUsuario.Text;
            string Contraseña = txtContraseña.Text;
            string ReContraseña = txtReContraseña.Text;

            if (Contraseña != ReContraseña)
            {
                MessageBox.Show("La contraseña no coincide...");
            }

            else
            {
                //Asignamos el numero 11 para registrarnos
                string mensaje = "11/" + Usuario + "/" + Contraseña;
                MessageBox.Show(mensaje);
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

                //Nos registramos con éxito
                if (mensaje == "SI")
                    MessageBox.Show("Te has registrado con ÉXITO!!!");
                else
                    MessageBox.Show("ERROR AL REGISTRARSE, Usuario ya eixistente.");
            }

        }

        private void Loguearse_Click(object sender, EventArgs e)
        {
            //Enviamos 2 strings usuario y contraseña
            string Usuario = txtUser.Text;
            string Contraseña = txtPassword.Text;

            //Asignamos el numero 12 para loguearnos
            string mensaje = "12/" + Usuario + "/" + Contraseña;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

            //Nos registramos con éxito
            if (mensaje == "SI")
            {
                MessageBox.Show("Te has logeado con ÉXITO!!!");
                //Form2 mostrar = new Form2();
                //mostrar.setServer(this.server);
                //mostrar.Show();
            }
            else
            {
                MessageBox.Show("ERROR AL LOGUEARSE, Usuario NO EXISTE.");
            }
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            string mensaje = "13/entrar";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
            MessageBox.Show(mensaje);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            tabla = new DataTable();
            //crear columna y fila
            DataColumn column;
            DataRow row;
            //Crear la columna Usuario
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Usuario";
            column.ReadOnly = true;
            column.Unique = true;
            //añadir a la tabla
            this.tabla.Columns.Add(column);
           
            //Limpiamos info de la tabla
            tabla.Rows.Clear();

            //Asignamos el numero 19 pedir lista conectados
            string mensaje = "19/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
            //Separamos los conectados
            string[] ListaSeparada;
            ListaSeparada = mensaje.Split('/');
            int i;
            
            //tabla.Columns.Clear();
            //Colocamos info en la tabla
            for (i = 0; i < ListaSeparada.Length; i++)
            {
                row = tabla.NewRow();
                row["Usuario"] = ListaSeparada[i];
                tabla.Rows.Add(row);
                ListaSeparada = mensaje.Split('/');
            }
            //añadimos la tabla al grid
            dataGridView1.DataSource = tabla;
        }






    }
}
