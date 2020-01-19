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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        Socket server;
        IPAddress direc;
        IPEndPoint ipep;
        Thread atender;
        byte[] msg2;
        bool res_partida;
        string mi_nom;
        string[] usua_invitados = new string[4];
        int cont_invi = 0;
        string invitado;

        InterficieGrafica ig;
        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
            direc = IPAddress.Parse("192.168.56.101");//IP.Text);
            ipep = new IPEndPoint(direc, 9051);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Enabled = false;
            txtContraseña.Enabled = false;
            txtReContraseña.Enabled = false;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            Registrarse.Enabled = false;
            Loguearse.Enabled = false;
            Desconectar.Enabled = false;
            box_invi.Enabled = false;
            btn_Invitar.Enabled = false;
            txtUser.Text = "Juan";
            txtPassword.Text = "1A";
            //crearInvitadosVacio();
        }
        private void crearInvitadosVacio()
        {
            for (int i = 0; i < 4; i++ )
            {
                usua_invitados[i] = "";
            }
        }

        private void ponerEnMarchaJuego(string perso)
        {
            ig = new InterficieGrafica(Convert.ToInt32(perso), this.server);
            //ig.miPersonaje(Convert.ToInt32(mensaje[2]));
            ig.ShowDialog();
        }
        private void bntConectar_Click(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Creamos el socket 
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

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            txtReContraseña.Enabled = true;
            txtUser.Enabled = true;
            txtPassword.Enabled = true;
            Registrarse.Enabled = true;
            Loguearse.Enabled = true;
            Desconectar.Enabled = true;
            btnConectar.Enabled = false;
            box_invi.Enabled = true;
            btn_Invitar.Enabled = true;
        }

        

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            string mensaje = "20/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            txtUsuario.Enabled = false;
            txtContraseña.Enabled = false;
            txtReContraseña.Enabled = false;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            Registrarse.Enabled = false;
            Loguearse.Enabled = false;
            Desconectar.Enabled = false;
            btnConectar.Enabled = true;
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
        }
        
        delegate void mostrarLista(string[] lista);
        delegate void Invitar();
        delegate void desactivarBtn();
        delegate void desactivarBtn2();
        delegate void inviPrueba();
        delegate void ponerNombre();
        public void ponerNombreEtiqueta()
        {
            label1.Text = this.mi_nom; 
        }
        public void crearForm(string nombre)
        {
            Form2 n = new Form2();
            n.setNomInvitacion(nombre);
            n.ShowDialog();
            bool res = n.getRespuesta();
            if (res == true)
            {
                MessageBox.Show("Has aceptado");
                string mensaje = "14/" + nombre + "/" + this.mi_nom + "/true";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Has rechazado"); 
                string mensaje = "14/" + nombre + "/" + this.mi_nom + "/false";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            res = this.res_partida;
        }
        public void ListaConectados(string[] mensaje)
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
            //Separamos los conectados
            string[] ListaSeparada = mensaje;
            int i;
            //Colocamos info en la tabla
            for (i = 1; i < ListaSeparada.Length; i++)
            {
                row = tabla.NewRow();
                row["Usuario"] = ListaSeparada[i];
                tabla.Rows.Add(row);
            }
            //añadimos la tabla al grid
            dataGridView1.DataSource = tabla;
        }
        public void AtenderServidor()
        {
            string[] mensaje;
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).TrimEnd('\0').Split('/');

                int opcion = Convert.ToInt32(mensaje[0]);
                switch (opcion)
                {
                    case 2:
                        //Nos registramos con éxito
                        if (mensaje[1] == "SI")
                            MessageBox.Show("Te has registrado con ÉXITO!!!");
                        else
                            MessageBox.Show("ERROR AL REGISTRARSE, Usuario ya existente.");
                        break;
                    case 3:
                        //Nos logeamos con éxito
                        if (mensaje[1] == "SI")
                        {
                            this.mi_nom = txtUser.Text;
                            MessageBox.Show("Te has logeado con ÉXITO!!! " + this.mi_nom);
                            ponerNombre delegadoNom = new ponerNombre(ponerNombreEtiqueta);
                            label1.Invoke(delegadoNom, new object[]{});
                            //Form2 mostrar = new Form2();
                            //mostrar.setServer(this.server);
                            //mostrar.Show();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL LOGUEARSE, Usuario NO EXISTE.");
                        }
                        break;
                    case 4:
                        mostrarLista delegado = new mostrarLista(ListaConectados);
                        dataGridView1.Invoke(delegado, new object[] { mensaje });
                        break;
                    case 5:
                        //Confirmación del envio
                        if (mensaje[1] == "SI")
                        {
                            MessageBox.Show("Se ha enviado la invitación con ÉXITO!!!");
                            usua_invitados[cont_invi] = this.invitado;
                            cont_invi++;
                            //Form2 mostrar = new Form2();
                            //mostrar.setServer(this.server);
                            //mostrar.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario NO EXISTE.");

                            usua_invitados[cont_invi] = "";
                        }
                        break;
                    case 6:
                        string nombres = mensaje[2];
                        ThreadStart n = delegate { crearForm(nombres); };
                        Thread t = new Thread(n);
                        t.Start();
                        break;
                    case 7:
                        if (mensaje[1] == "SI")
                        {
                            //MessageBox.Show("Se juega la partida " + mensaje[2]);

                            string numero = mensaje[2];
                            ThreadStart juego = delegate { ponerEnMarchaJuego(numero); };
                            Thread tjuego = new Thread(juego);
                            tjuego.Start();
                            /*ig = new InterficieGrafica(Convert.ToInt32(mensaje[2]),this.server);
                            //ig.miPersonaje(Convert.ToInt32(mensaje[2]));
                            ig.ShowDialog();*/
                        }
                        else if (mensaje[1] == "NO")
                        {
                            MessageBox.Show("Alguien ha rechazado, no se juega");
                        }
                        break;
                    case 9:
                        ig.guardarPosicionOtroJugador(mensaje[1]);
                        break;
                    case 10:
                        ig.guardarPosicionBombaOtro(mensaje[1]);
                        break;
                    case 11:
                        ig.guardarFrase(mensaje[1]);
                        break;
                    default:
                        break;
                }
                opcion = 0;
                mensaje = null;
            }
        }

        private void btn_Invitar_Click(object sender, EventArgs e)
        {
            if (cont_invi == 2)
            {
                MessageBox.Show("Se ha superado el numero máximo de jugadores");
            }
            else
            {
                string jugador = box_invi.Text;
                invitado = jugador;
                bool encontrado = false;
                int i = 0;
                while (i < this.cont_invi && encontrado == false)
                {
                    if (usua_invitados[i] == jugador)
                    {
                        encontrado = true;
                    }
                    i++;
                }
                if (encontrado == false)
                {
                    //usua_invitados[cont_invi] = jugador;
                    string mensaje = "13/" + jugador;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Ya has invitado a esta persona");
                }
            }
        }

    }
}
