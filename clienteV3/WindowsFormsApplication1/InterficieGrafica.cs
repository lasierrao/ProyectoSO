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
    public partial class InterficieGrafica : Form
    {
        int numero_personaje;
        Socket server;

        PictureBox[] jugador = new PictureBox[2];
        PictureBox[] bomba = new PictureBox[2];
        PictureBox[] explosion = new PictureBox[5];
        PictureBox[,] bloques = new PictureBox[4, 6];
        PictureBox[,] suelo = new PictureBox[9, 13];
        //en ubicacion se escogera la imagen que se usará para los bloques
        Bitmap ubicacion = new Bitmap("bloque.png");
        Bitmap ubicacion_jugador = new Bitmap("bomberman.png");
        Bitmap ubicacion_jugador2 = new Bitmap("bomberman_negro.png");
        Bitmap ubicacion_bomba = new Bitmap("bomba.jpg");
        Bitmap ubicacion_suelo = new Bitmap("fondo-verde.png");

        Bitmap ubicacion_expl_centro = new Bitmap("explosion_central.jpg");
        Bitmap ubicacion_expl_up = new Bitmap("explosion_up1.jpg");
        Bitmap ubicacion_expl_down = new Bitmap("explosion_down1.jpg");
        Bitmap ubicacion_expl_left = new Bitmap("explosion_left1.jpg");
        Bitmap ubicacion_expl_right = new Bitmap("explosion_right1.jpg");

        Label label_cont = new Label();

        //Timer[] timers = Array();//new Array[2] ;
        //Timer t1 = new Timer();
        int tecla_up = 0;
        int tecla_down = 0;
        int tecla_left = 0;
        int tecla_right = 0;

        int cont = 4;
        int cont2 = 4;
        int cont_muertes = 0;
        int cont_bombas = 0;

        public InterficieGrafica(int personaje, Socket server)
        {
            InitializeComponent();
            this.numero_personaje = personaje;
            this.server = server;
            IniciarSueloImagen();
            IniciarJugadorImagen();
            IniciarBloquesImagen();

            //Timer timer = new Timer();
            timer1.Interval = 1000;
            timer1.Enabled = false;

            timer2.Interval = 1000;
            timer2.Enabled = false;
        }
        public void IniciarSueloImagen()
        {
            int posX = 0;
            int posY = 0;

            for (int i = 0; i < 9; i++)
            {
                posX = 0;
                for (int j = 0; j < 13; j++)
                {
                    suelo[i, j] = new PictureBox();
                    //
                    suelo[i, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                    //punto en donde se encontrará la imagen
                    suelo[i, j].Location = new Point(posX, posY);
                    suelo[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    suelo[i, j].Image = (Image)ubicacion_suelo;
                    //ponemos una etiqueta a cada imagen
                    /*img_vec[i].Tag = i;
                    img_vec[i].Click += new System.EventHandler(this.evento);*/
                    suelo[i, j].Visible = false;
                    suelo[i, j].SendToBack();

                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(suelo[i, j]);
                    posX += 50;
                }
                posY += 50;
            }
        }
        public void IniciarJugadorImagen()
        {
            jugador[0] = new PictureBox();
            //
            jugador[0].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            jugador[0].Location = new Point(0, 50);
            jugador[0].SizeMode = PictureBoxSizeMode.StretchImage;
            jugador[0].Image = (Image)ubicacion_jugador;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            jugador[0].Visible = true;
            jugador[0].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(jugador[0]);
            //---------Jugador 2-------------------
            jugador[1] = new PictureBox();
            //
            jugador[1].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            jugador[1].Location = new Point(0, 150);
            jugador[1].SizeMode = PictureBoxSizeMode.StretchImage;
            jugador[1].Image = (Image)ubicacion_jugador2;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            jugador[1].Visible = true;
            jugador[1].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(jugador[1]);
        }
        public void IniciarBombaImagen(int posx, int posy)
        {
            int x = posx;
            int y = posy;
            /*if (this.tecla_up == 1 && posy % 50 != 0)//posy < posy + 25)
            {
                y = posy + 25;
            }
            else if (this.tecla_down == 1 && posy % 50 != 0)
            {
                y = posy - 25;
            }else if(this.tecla_right == 1 && posx % 50 != 0)
            {
                x = posx - 25;
            }
            else if (this.tecla_left == 1 && posx % 50 != 0)
            {
                x = posx + 25;
            }*/
            if (this.tecla_up == 1 && posy % 50 != 0)
            {
                y = posy + 25;
            }
            else if (this.tecla_down == 1 && posy % 50 != 0)
            {
                y = posy - 25;
            }
            else if (this.tecla_right == 1 && posx % 50 != 0)
            {
                x = posx - 25;
            }
            else if (this.tecla_left == 1 && posx % 50 != 0)
            {
                x = posx + 25;
            }
            if (cont_bombas == 0)
            {
                bomba[0] = new PictureBox();
                //
                bomba[0].ClientSize = new Size(50, 50);//tamaño de la imagen
                //punto en donde se encontrará la imagen
                bomba[0].Location = new Point(x, y);
                bomba[0].SizeMode = PictureBoxSizeMode.StretchImage;
                bomba[0].Image = (Image)ubicacion_bomba;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                bomba[0].Visible = true;
                bomba[0].BringToFront();

                //mostramos por pantalla las imagenes
                panel1.Controls.Add(bomba[0]);
                cont_bombas++;
                timer1.Enabled = true;
                timer1.Start();
            }
            else if (cont_bombas == 1)
            {
                bomba[1] = new PictureBox();
                //
                bomba[1].ClientSize = new Size(50, 50);//tamaño de la imagen
                //punto en donde se encontrará la imagen
                bomba[1].Location = new Point(x, y);
                bomba[1].SizeMode = PictureBoxSizeMode.StretchImage;
                bomba[1].Image = (Image)ubicacion_bomba;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                bomba[1].Visible = true;
                bomba[1].BringToFront();

                //mostramos por pantalla las imagenes
                panel1.Controls.Add(bomba[1]);
                cont_bombas++;
                timer2.Enabled = true;
                timer2.Start();
            }
            else if (timer2.Enabled == false && cont_bombas == 2)
            {
                cont_bombas = 0;
            }
        }
        public void IniciarExplosionImagen(int posx, int posy)
        {
            explosion[0] = new PictureBox();
            //
            explosion[0].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            explosion[0].Location = new Point(posx, posy);
            explosion[0].SizeMode = PictureBoxSizeMode.StretchImage;
            explosion[0].Image = (Image)ubicacion_expl_centro;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            explosion[0].Visible = true;
            explosion[0].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[0]);
            //**************************up******************************
            explosion[1] = new PictureBox();
            //
            explosion[1].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            explosion[1].Location = new Point(posx, posy - 50);
            explosion[1].SizeMode = PictureBoxSizeMode.StretchImage;
            explosion[1].Image = (Image)ubicacion_expl_up;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            explosion[1].Visible = true;
            explosion[1].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[1]);
            //**************************down******************************
            explosion[2] = new PictureBox();
            //
            explosion[2].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            explosion[2].Location = new Point(posx, posy + 50);
            explosion[2].SizeMode = PictureBoxSizeMode.StretchImage;
            explosion[2].Image = (Image)ubicacion_expl_down;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            explosion[2].Visible = true;
            explosion[2].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[2]);
            //**************************left******************************
            explosion[3] = new PictureBox();
            //
            explosion[3].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            explosion[3].Location = new Point(posx - 50, posy);
            explosion[3].SizeMode = PictureBoxSizeMode.StretchImage;
            explosion[3].Image = (Image)ubicacion_expl_left;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            explosion[3].Visible = true;
            explosion[3].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[3]);
            //**************************right******************************
            explosion[4] = new PictureBox();
            //
            explosion[4].ClientSize = new Size(50, 50);//tamaño de la imagen
            //punto en donde se encontrará la imagen
            explosion[4].Location = new Point(posx + 50, posy);
            explosion[4].SizeMode = PictureBoxSizeMode.StretchImage;
            explosion[4].Image = (Image)ubicacion_expl_right;
            //ponemos una etiqueta a cada imagen
            /*img_vec[i].Tag = i;
            img_vec[i].Click += new System.EventHandler(this.evento);*/
            explosion[4].Visible = true;
            explosion[4].BringToFront();

            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[4]);

        }
        public void timer2_Tick(object sender, EventArgs e)
        {
            if (cont2 == 0)
            {
                //timer1.Enabled = false;
                timer2.Stop();
                cont2 = 4;
                for (int i = 0; i < 5; i++)
                {
                    explosion[i].Visible = false;
                }
            }
            else if (cont2 == 1)
            {
                bomba[1].Visible = false;
                IniciarExplosionImagen(bomba[1].Location.X, bomba[1].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto();
                }
                cont2--;
            }
            else
            {
                cont2--;
            }
            label3.Text = "Tiempo: " + cont2;

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                //timer1.Enabled = false;
                timer1.Stop();
                cont = 4;
                for (int i = 0; i < 5; i++)
                {
                    explosion[i].Visible = false;
                }
            }
            else if (cont == 1)
            {
                bomba[0].Visible = false;
                IniciarExplosionImagen(bomba[0].Location.X, bomba[0].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto();
                }
                cont--;
            }
            else
            {
                cont--;
            }
            label1.Text = "Tiempo: " + cont;
        }
        private void PersonajeMuerto()
        {
            //jugador[0].Enabled = false;
            jugador[0].Location = new Point(0, 50);
            cont_muertes++;
            label2.Text = "Muertes:" + cont_muertes;
        }
        public void IniciarBloquesImagen()
        {
            /*for (int i = 0; i < 10; i++)
            {
                bloques[i] = new PictureBox();

                panel1.Controls.Add(bloques[i]);
                bloques[i].BringToFront();//lo mandamos al frente
             *  
            }*/
            int posX = 50;
            int posY = 50;

            for (int i = 0; i < 4; i++)
            {
                posX = 50;
                for (int j = 0; j < 6; j++)
                {
                    bloques[i, j] = new PictureBox();
                    //
                    bloques[i, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                    //punto en donde se encontrará la imagen
                    bloques[i, j].Location = new Point(posX, posY);
                    bloques[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    bloques[i, j].Image = (Image)ubicacion;
                    //ponemos una etiqueta a cada imagen
                    /*img_vec[i].Tag = i;
                    img_vec[i].Click += new System.EventHandler(this.evento);*/
                    bloques[i, j].Visible = true;
                    bloques[i, j].BringToFront();

                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bloques[i, j]);
                    posX += 100;
                }
                posY += 100;
            }
        }
        private void TeclaPresionadaAnterior(int a, int b, int c, int d)
        {
            this.tecla_up = a;
            this.tecla_down = b;
            this.tecla_left = c;
            this.tecla_right = d;
        }
        private int ComprobarBordeBloque(int up, int down, int left, int right, Point posicion)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (up == 1 && bloques[i, j].Location.Y == posicion.Y - 50
                        && (bloques[i, j].Location.X == posicion.X
                        || bloques[i, j].Location.X > posicion.X
                        && bloques[i, j].Location.X < posicion.X + 50
                        || bloques[i, j].Location.X < posicion.X
                        && bloques[i, j].Location.X > posicion.X - 50))
                    {
                        return 1;
                    }
                    else if (down == 1 && bloques[i, j].Location.Y == posicion.Y + 50
                        && (bloques[i, j].Location.X == posicion.X ||
                        bloques[i, j].Location.X > posicion.X
                        && bloques[i, j].Location.X < posicion.X + 50
                        || bloques[i, j].Location.X < posicion.X
                        && bloques[i, j].Location.X > posicion.X - 50))
                    {
                        return 1;
                    }
                    else if (left == 1 && bloques[i, j].Location.X == posicion.X - 50
                        && (bloques[i, j].Location.Y == posicion.Y
                        || bloques[i, j].Location.Y > posicion.Y
                        && bloques[i, j].Location.Y < posicion.Y + 50
                        || bloques[i, j].Location.Y < posicion.Y
                        && bloques[i, j].Location.Y > posicion.Y - 50))
                    {
                        return 1;
                    }
                    else if (right == 1 && bloques[i, j].Location.X == posicion.X + 50
                        && (bloques[i, j].Location.Y == posicion.Y
                        || bloques[i, j].Location.Y > posicion.Y
                        && bloques[i, j].Location.Y < posicion.Y + 50
                        || bloques[i, j].Location.Y < posicion.Y
                        && bloques[i, j].Location.Y > posicion.Y - 50))
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
        private int ComprobarTocadoExplosion(Point posicion)
        {
            for (int i = 0; i < 5; i++)
            {
                if (posicion.X == explosion[i].Location.X
                    && posicion.Y == explosion[i].Location.Y)
                {
                    return 1;
                }
            }
            return 0;
        }
        public void miPersonaje(int numero)
        {
            this.numero_personaje = numero;
        }
        delegate void ponerMovimientoPersonaje(int x, int y);
        delegate void ponerMovimientoPersonaje2(int x, int y);
        public void moverPersonaje(int pox, int poy)
        {
            this.jugador[0].Location = new Point(pox, poy);
        }
        public void moverPersonaje2(int pox, int poy)
        {
            this.jugador[1].Location = new Point(pox, poy);
        }
        public void guardarPosicionOtroJugador(string posicion_otro)
        {
            string[] numper = posicion_otro.Split('-');
            if (numper[0] == "0" && this.numero_personaje != 0)
            {
                ponerMovimientoPersonaje delegado = new ponerMovimientoPersonaje(moverPersonaje);
                this.jugador[0].Invoke(delegado, new object[] { Convert.ToInt32(numper[1]), Convert.ToInt32(numper[2]) });
                //this.jugador[0].Location = new Point(Convert.ToInt32(numper[1]), Convert.ToInt32(numper[2]));
            }
            else if (numper[0] == "1" && this.numero_personaje != 1)
            {
                ponerMovimientoPersonaje2 delegado2 = new ponerMovimientoPersonaje2(moverPersonaje2);
                this.jugador[1].Invoke(delegado2, new object[] { Convert.ToInt32(numper[1]), Convert.ToInt32(numper[2]) });
                //this.jugador[1].Location = new Point(Convert.ToInt32(numper[1]), Convert.ToInt32(numper[2]));
            }
            else
            {
                //MessageBox.Show("Este es la posicion de otro jugador: " + posicion_otro);
                //MessageBox.Show("Numero del personaje: "+numper[0]+"\nPosicion X: " + numper[1] + "\nPosicion Y: " + numper[2]);
            }
        }
        private void enviarPosicion()
        {
            string mensaje = "8/" + this.numero_personaje + "-" + jugador[this.numero_personaje].Location.X + "-" + jugador[this.numero_personaje].Location.Y;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void InterficieGrafica_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.pictureBox1.Location = new Point(pictureBox1.Location.X - 25, pictureBox1.Location.Y);
                    break;

                case Keys.Right:
                    this.pictureBox1.Location = new Point(pictureBox1.Location.X + 25, pictureBox1.Location.Y);
                    break;

                case Keys.Up:
                    this.pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 25);
                    break;

                case Keys.Down:
                    this.pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 25);
                    break;
            }
             */
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (ComprobarBordeBloque(0, 0, 1, 0, this.jugador[this.numero_personaje].Location) == 1)
                    {
                        this.jugador[this.numero_personaje].Location = this.jugador[this.numero_personaje].Location;
                    }
                    else
                    {
                        this.jugador[this.numero_personaje].Location = new Point(jugador[this.numero_personaje].Location.X - 25, jugador[this.numero_personaje].Location.Y);
                        TeclaPresionadaAnterior(0, 0, 1, 0);
                    }
                    //this.jugador[0].Location = new Point(jugador[0].Location.X - 25, jugador[0].Location.Y);
                    /*string mensaje = "8/" + this.numero_personaje + "-" + jugador[this.numero_personaje].Location.X + "-" + jugador[this.numero_personaje].Location.Y;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);*/
                    enviarPosicion();
                    break;

                case Keys.Right:
                    if (ComprobarBordeBloque(0, 0, 0, 1, this.jugador[this.numero_personaje].Location) == 1)
                    {
                        this.jugador[this.numero_personaje].Location = this.jugador[this.numero_personaje].Location;
                    }
                    else
                    {
                        this.jugador[this.numero_personaje].Location = new Point(jugador[this.numero_personaje].Location.X + 25, jugador[this.numero_personaje].Location.Y);
                        TeclaPresionadaAnterior(0, 0, 0, 1);
                    }
                    enviarPosicion();
                    break;

                case Keys.Up:
                    if (ComprobarBordeBloque(1, 0, 0, 0, this.jugador[this.numero_personaje].Location) == 1)
                    {
                        this.jugador[this.numero_personaje].Location = this.jugador[this.numero_personaje].Location;
                    }
                    else
                    {
                        this.jugador[this.numero_personaje].Location = new Point(jugador[this.numero_personaje].Location.X, jugador[this.numero_personaje].Location.Y - 25);
                        TeclaPresionadaAnterior(1, 0, 0, 0);
                    }
                    enviarPosicion();
                    break;

                case Keys.Down:
                    if (ComprobarBordeBloque(0, 1, 0, 0, this.jugador[this.numero_personaje].Location) == 1)
                    {
                        this.jugador[this.numero_personaje].Location = this.jugador[this.numero_personaje].Location;
                    }
                    else
                    {
                        this.jugador[this.numero_personaje].Location = new Point(jugador[this.numero_personaje].Location.X, jugador[this.numero_personaje].Location.Y + 25);
                        TeclaPresionadaAnterior(0, 1, 0, 0);
                    }
                    enviarPosicion();
                    break;
                case Keys.Space:
                    IniciarBombaImagen(jugador[this.numero_personaje].Location.X, jugador[this.numero_personaje].Location.Y);
                    break;
            }
        }
    }
}

