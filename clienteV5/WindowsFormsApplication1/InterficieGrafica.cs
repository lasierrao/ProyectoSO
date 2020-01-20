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
        PictureBox[] bomba = new PictureBox[4];
        PictureBox[,] explosion = new PictureBox[5,4];
        PictureBox[,] bloques = new PictureBox[4, 6];
        
        //en ubicacion se escogera la imagen que se usará para los bloques
        Bitmap ubicacion = new Bitmap("bloque.png");
        Bitmap ubicacion_jugador = new Bitmap("bomberman.png");
        Bitmap ubicacion_jugador2 = new Bitmap("bomberman_negro.png");
        Bitmap ubicacion_bomba = new Bitmap("bomba.jpg");

        Bitmap ubicacion_expl_centro = new Bitmap("explosion_central.jpg");
        Bitmap ubicacion_expl_up = new Bitmap("explosion_up1.jpg");
        Bitmap ubicacion_expl_down = new Bitmap("explosion_down1.jpg");
        Bitmap ubicacion_expl_left = new Bitmap("explosion_left1.jpg");
        Bitmap ubicacion_expl_right = new Bitmap("explosion_right1.jpg");

        Label label_cont = new Label();

        //Timer[] timers = Array();//new Array[2] ;
        //Timer t1 = new Timer();
        string nombre_mio;
        int tecla_up = 0;
        int tecla_down = 0;
        int tecla_left = 0;
        int tecla_right = 0;

        int cont = 4;
        int cont2 = 4;
        int cont3 = 4;
        int cont4 = 4;

        int cont_muertes = 0;
        int cont_muertes1 = 0;

        int cont_bombas = 0;
        int cont_bombas1 = 0;
        delegate void guardarNombre();
        private void ponerNombre()
        {
            label5.Text = this.nombre_mio;
        }
        public InterficieGrafica(int personaje, Socket server, string nombre)
        {
            InitializeComponent();
            this.nombre_mio = nombre;
            label5.Text = this.nombre_mio;
            /*guardarNombre gn = new guardarNombre(ponerNombre);
            this.Invoke(gn,new object[]{});*/
            this.numero_personaje = personaje;
            this.server = server;
            IniciarJugadorImagen();
            IniciarBloquesImagen();
            IniciarBombaImagen();
            IniciarExplosionImagen();
            box_msj.Enabled = false;
            btn_enviar_msj.Enabled = false;

            //Timer timer = new Timer();
            timer1.Interval = 1000;
            timer1.Enabled = false;

            timer2.Interval = 1000;
            timer2.Enabled = false;

            timer3.Interval = 1000;
            timer3.Enabled = false;

            timer4.Interval = 1000;
            timer4.Enabled = false;
        }
        //--------------------------------------JUGADOR-------------------------------
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
        //----------------------------Bomba---------------------------------------
        public void IniciarBombaImagen()
        {
            for(int i = 0; i < 4;i++){
                bomba[i] = new PictureBox();
                //
                bomba[i].ClientSize = new Size(50, 50);//tamaño de la imagen
                bomba[i].SizeMode = PictureBoxSizeMode.StretchImage;
                bomba[i].Image = (Image)ubicacion_bomba;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                bomba[i].Visible = false;
                bomba[i].BringToFront();

            }
        }
        //------------------------------BOMBA OTRO JUGADOR-------------
        delegate void ponerPosicionBomba0(int x, int y);
        delegate void ponerPosicionBomba1(int x, int y);
        delegate void ponerPosicionBomba2(int x, int y);
        delegate void ponerPosicionBomba3(int x, int y);
        private void posicionBomba0(int x, int y)
        {
            //punto en donde se encontrará la imagen
            bomba[0].Location = new Point(x, y);
            bomba[0].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(bomba[0]);
            cont_bombas++;
            timer1.Enabled = true;
            timer1.Start();
            
        }
        private void posicionBomba1(int x, int y)
        {
            //punto en donde se encontrará la imagen
            bomba[1].Location = new Point(x, y);
            bomba[1].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(bomba[1]);
            cont_bombas++;    
            timer2.Enabled = true;
            timer2.Start();

        }
        private void posicionBomba2(int x, int y)
        {
            //punto en donde se encontrará la imagen
            bomba[2].Location = new Point(x, y);
            bomba[2].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(bomba[2]);
            cont_bombas++;
            timer3.Enabled = true;
            timer3.Start();

        }
        private void posicionBomba3(int x, int y)
        {
            //punto en donde se encontrará la imagen
            bomba[3].Location = new Point(x, y);
            bomba[3].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(bomba[3]);
            cont_bombas++;
            timer4.Enabled = true;
            timer4.Start();

        }
        private void ponerBombaImagenOtro(int numpersonaje, int posx, int posy)
        {
            int x = posx;
            int y = posy;

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

            if (numpersonaje == 0)
            {
                if (cont_bombas == 0)
                {
                    ponerPosicionBomba0 delegadobomb = new ponerPosicionBomba0(posicionBomba0);
                    this.Invoke(delegadobomb, new object[] { x, y });
                    //punto en donde se encontrará la imagen
                    /*bomba[0].Location = new Point(x, y);
                    bomba[0].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[0]);
                    cont_bombas++;
                    timer1.Enabled = true;
                    timer1.Start();*/
                    //cont_bombas++;
                }
                else if (cont_bombas == 1)
                {
                    ponerPosicionBomba1 delegadobomb = new ponerPosicionBomba1(posicionBomba1);
                    this.Invoke(delegadobomb, new object[] { x, y });
                    //punto en donde se encontrará la imagen
                    /*bomba[1].Location = new Point(x, y);
                    bomba[1].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[1]);
                    cont_bombas++;
                    timer2.Enabled = true;
                    timer2.Start();*/
                    //cont_bombas++;
                }
                else if (timer2.Enabled == false && cont_bombas == 2)
                {
                    cont_bombas = 0;
                }
            }
            else if (numpersonaje == 1)
            {
                if (cont_bombas1 == 0)
                {
                    ponerPosicionBomba2 delegadobomb = new ponerPosicionBomba2(posicionBomba2);
                    this.Invoke(delegadobomb, new object[] { x, y });
                    //punto en donde se encontrará la imagen
                    /*bomba[2].Location = new Point(x, y);
                    bomba[2].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[2]);
                    cont_bombas1++;
                    timer3.Enabled = true;
                    timer3.Start();*/
                    //cont_bombas1++;
                }
                else if (cont_bombas1 == 1)
                {
                    ponerPosicionBomba3 delegadobomb = new ponerPosicionBomba3(posicionBomba3);
                    this.Invoke(delegadobomb, new object[] { x, y });
                    //punto en donde se encontrará la imagen
                    /*bomba[3].Location = new Point(x, y);
                    bomba[3].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[3]);
                    cont_bombas1++;
                    timer4.Enabled = true;
                    timer4.Start();*/
                    //cont_bombas1++;
                }
                /*else if (timer4.Enabled == false && cont_bombas1 == 2)
                {
                    cont_bombas1 = 0;
                }*/
            }
        }
        //---------------------------BOMBA
        private void ponerBombaImagen(int numpersonaje, int posx, int posy)
        {
            int x = posx;
            int y = posy;

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

            if (this.numero_personaje == 0)
            {
                if (cont_bombas == 0)
                {
                    //punto en donde se encontrará la imagen
                    bomba[0].Location = new Point(x, y);
                    bomba[0].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[0]);
                    cont_bombas++;
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else if (cont_bombas == 1)
                {
                    bomba[1].Location = new Point(x, y);
                    bomba[1].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[1]);
                    cont_bombas++;
                    timer2.Enabled = true;
                    timer2.Start();
                }
            }
            else if (this.numero_personaje == 1)
            {
                if (cont_bombas1 == 0)
                {
                    //punto en donde se encontrará la imagen
                    bomba[2].Location = new Point(x, y);
                    bomba[2].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[2]);
                    cont_bombas1++;
                    timer3.Enabled = true;
                    timer3.Start();
                }
                else if (cont_bombas1 == 1)
                {
                    //punto en donde se encontrará la imagen
                    bomba[3].Location = new Point(x, y);
                    bomba[3].Visible = true;
                    //mostramos por pantalla las imagenes
                    panel1.Controls.Add(bomba[3]);
                    cont_bombas1++;
                    timer4.Enabled = true;
                    timer4.Start();
                }
            }
        }
        //--------------------------EXPLOSION----------------------------
        public void IniciarExplosionImagen()
        {
            for (int j = 0; j < 4; j++)
            {
                explosion[0, j] = new PictureBox();
                //
                explosion[0, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                explosion[0, j].SizeMode = PictureBoxSizeMode.StretchImage;
                explosion[0, j].Image = (Image)ubicacion_expl_centro;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                explosion[0, j].Visible = false;
                explosion[0, j].BringToFront();

                //**************************up******************************
                explosion[1, j] = new PictureBox();
                //
                explosion[1, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                explosion[1, j].SizeMode = PictureBoxSizeMode.StretchImage;
                explosion[1, j].Image = (Image)ubicacion_expl_up;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                explosion[1, j].Visible = false;
                explosion[1, j].BringToFront();

                //**************************down******************************
                explosion[2, j] = new PictureBox();
                //
                explosion[2, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                explosion[2, j].SizeMode = PictureBoxSizeMode.StretchImage;
                explosion[2, j].Image = (Image)ubicacion_expl_down;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                explosion[2, j].Visible = false;
                explosion[2, j].BringToFront();

                //**************************left******************************
                explosion[3, j] = new PictureBox();
                //
                explosion[3, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                explosion[3, j].SizeMode = PictureBoxSizeMode.StretchImage;
                explosion[3, j].Image = (Image)ubicacion_expl_left;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                explosion[3, j].Visible = false;
                explosion[3, j].BringToFront();

                //**************************right******************************
                explosion[4, j] = new PictureBox();
                //
                explosion[4, j].ClientSize = new Size(50, 50);//tamaño de la imagen
                explosion[4, j].SizeMode = PictureBoxSizeMode.StretchImage;
                explosion[4, j].Image = (Image)ubicacion_expl_right;
                //ponemos una etiqueta a cada imagen
                /*img_vec[i].Tag = i;
                img_vec[i].Click += new System.EventHandler(this.evento);*/
                explosion[4, j].Visible = false;
                explosion[4, j].BringToFront();

            }
        }
        private void ponerExplosionImagen(int num_bomba, int posx, int posy)
        {
            //************************centro******************************
            //punto en donde se encontrará la imagen
            explosion[0, num_bomba].Location = new Point(posx, posy);
            explosion[0, num_bomba].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[0, num_bomba]);

            //**************************up******************************
            //punto en donde se encontrará la imagen
            explosion[1, num_bomba].Location = new Point(posx, posy - 50);
            explosion[1, num_bomba].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[1, num_bomba]);

            //**************************down******************************
            //punto en donde se encontrará la imagen
            explosion[2, num_bomba].Location = new Point(posx, posy + 50);
            explosion[2, num_bomba].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[2, num_bomba]);

            //**************************left******************************
            //punto en donde se encontrará la imagen
            explosion[3, num_bomba].Location = new Point(posx - 50, posy);
            explosion[3, num_bomba].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[3, num_bomba]);

            //**************************right******************************
            //punto en donde se encontrará la imagen
            explosion[4, num_bomba].Location = new Point(posx + 50, posy);
            explosion[4, num_bomba].Visible = true;
            //mostramos por pantalla las imagenes
            panel1.Controls.Add(explosion[4, num_bomba]);
        }
        //------------------------------TEMPORIZADOR------------------------------------------
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (cont4 == 0)
            {
                //timer1.Enabled = false;
                cont4 = 4;
                for (int i = 0; i < 5; i++)
                {
                    explosion[i, 3].Visible = false;
                }
                this.cont_bombas1 = 0;
                timer4.Stop();
            }
            else if (cont4 == 1)
            {
                bomba[3].Visible = false;
                ponerExplosionImagen(2, bomba[3].Location.X, bomba[3].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto(0);
                }
                int res2 = ComprobarTocadoExplosion(new Point(jugador[1].Location.X, jugador[1].Location.Y));
                if (res2 == 1)
                {
                    PersonajeMuerto(1);
                }
                cont4--;
            }
            else
            {
                cont4--;
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (cont3 == 0)
            {
                //timer1.Enabled = false;
                cont3 = 4;
                for (int i = 0; i < 5; i++)
                {
                    explosion[i, 2].Visible = false;
                }
                timer3.Stop();
            }
            else if (cont3 == 1)
            {
                bomba[2].Visible = false;
                ponerExplosionImagen(2, bomba[2].Location.X, bomba[2].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto(0);
                }
                int res2 = ComprobarTocadoExplosion(new Point(jugador[1].Location.X, jugador[1].Location.Y));
                if (res2 == 1)
                {
                    PersonajeMuerto(1);
                }
                cont3--;
            }
            else
            {
                cont3--;
            } 
            label4.Text = "Tiempo: " + cont3;
        }
        public void timer2_Tick(object sender, EventArgs e)
        {
            if (cont2 == 0)
            {
                //timer1.Enabled = false;
                cont2 = 4;
                for (int i = 0; i < 5; i++)
                {
                    explosion[i,1].Visible = false;
                }
                this.cont_bombas = 0;
                timer2.Stop();
            }
            else if (cont2 == 1)
            {
                bomba[1].Visible = false;
                ponerExplosionImagen(1, bomba[1].Location.X, bomba[1].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto(0);
                }
                int res2 = ComprobarTocadoExplosion(new Point(jugador[1].Location.X, jugador[1].Location.Y));
                if (res2 == 1)
                {
                    PersonajeMuerto(1);
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
                    explosion[i,0].Visible = false;
                }
            }
            else if (cont == 1)
            {
                bomba[0].Visible = false;
                ponerExplosionImagen(0, bomba[0].Location.X, bomba[0].Location.Y);
                int res = ComprobarTocadoExplosion(new Point(jugador[0].Location.X, jugador[0].Location.Y));
                if (res == 1)
                {
                    PersonajeMuerto(0);
                }
                int res2 = ComprobarTocadoExplosion(new Point(jugador[1].Location.X, jugador[1].Location.Y));
                if (res2 == 1)
                {
                    PersonajeMuerto(1);
                }
                cont--;
            }
            else
            {
                cont--;
            }
            label1.Text = "Tiempo: " + cont;
        }
        //--------------------------------------PERSONAJE MUERTO-------------------------
        private void PersonajeMuerto(int num)
        {
            //jugador[0].Enabled = false;
            if (num == 0)
            {
                jugador[0].Location = new Point(0, 50);
                cont_muertes++;
                label2.Text = "Muertes:" + cont_muertes;
            }
            else if (num == 1)
            {
                jugador[1].Location = new Point(0, 50);
                cont_muertes1++;
                label4.Text = "Muertes:" + cont_muertes1;
            }
        }
        public void IniciarBloquesImagen()
        {
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
        //----------------------LIMITES CON LOS BLOQUES------------------------------------
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
                if (posicion.X == explosion[i,0].Location.X
                    && posicion.Y == explosion[i,0].Location.Y
                    || posicion.X == explosion[i, 1].Location.X
                    && posicion.Y == explosion[i, 1].Location.Y)
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
        //---------------------------POSICION DEL OTRO PERSONAJE-------------------------------
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
        //----------------------------ENVIAR DATOS AL SERVIDOR--------------------------------
        private void enviarPosicion()
        {
            string mensaje = "8/" + this.numero_personaje + "-" + jugador[this.numero_personaje].Location.X + "-" + jugador[this.numero_personaje].Location.Y;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void guardarPosicionBombaOtro(string posicion)
        {
            string[] numper = posicion.Split('-');
            int posx = Convert.ToInt32(numper[1]);
            int posy = Convert.ToInt32(numper[2]);
            if (numper[0] == "0" && this.numero_personaje != 0)
            {
                ponerBombaImagenOtro(0, posx, posy);
            }
            else if (numper[0] == "1" && this.numero_personaje != 1)
            {
                ponerBombaImagenOtro(1, posx, posy);
            }
            /*int numero = Convert.ToInt32(numper[0]);
            ponerBombaImagenOtro(numero,posx,posy);*/
        }
        private void enviarPosicionBomba(int numero, Point posicion)
        {
            //string mensaje = "15/" + this.numero_personaje + "-" + jugador[this.numero_personaje].Location.X + "-" + jugador[this.numero_personaje].Location.Y;
            string mensaje = "15/" + numero + "-" + posicion.X + "-" + posicion.Y;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
       
        delegate void PonerFrase(string frase);
        public void mostrarFrase(string frase)
        {
            lbl_mensaje.Text = "Mensaje: " + frase;
        }
        public void guardarFrase(string frase)
        {
            PonerFrase delegadofrase = new PonerFrase(mostrarFrase);
            lbl_mensaje.Invoke(delegadofrase,new object[]{frase});
        }
        private void btn_enviar_msj_Click(object sender, EventArgs e)
        {
            string mensaje = "16/" + box_msj.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        //--------------------------------MOVIMIENTO----------------------------------------
        private void InterficieGrafica_KeyUp(object sender, KeyEventArgs e)
        {
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
                    if (this.numero_personaje == 0 && cont_bombas < 2)
                    {
                        Point posicion_act0 = jugador[0].Location;
                        ponerBombaImagen(0, posicion_act0.X, posicion_act0.Y);
                        enviarPosicionBomba(0, posicion_act0);
                        /*ponerBombaImagen(this.numero_personaje, jugador[this.numero_personaje].Location.X, jugador[this.numero_personaje].Location.Y);
                        enviarPosicionBomba();*/
                    }
                    else if (this.numero_personaje == 1 && cont_bombas1 < 2)
                    {
                        Point posicion_act1 = jugador[1].Location;
                        ponerBombaImagen(1, posicion_act1.X, posicion_act1.Y);
                        enviarPosicionBomba(1,posicion_act1);
                        /*
                        ponerBombaImagen(this.numero_personaje, jugador[this.numero_personaje].Location.X, jugador[this.numero_personaje].Location.Y);
                        enviarPosicionBomba();*/
                    }
                    break;
            }
        }
    }
}

