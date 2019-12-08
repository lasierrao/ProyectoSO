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
    public partial class Form2 : Form
    {
        bool respuesta;
        string jugador;
        public Form2()
        {
            InitializeComponent();
            label_mensaje.Text = "Te han invitado a que te unas a una partida.";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            respuesta = true;
            Close();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            respuesta = false;
            Close();
        }
        public void setNombre(string jugador)
        {
            this.jugador = jugador;
        }
        public bool getRespuesta()
        {
            return this.respuesta;
        }
    }
}
