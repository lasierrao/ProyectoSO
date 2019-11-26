namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.Registrarse = new System.Windows.Forms.Button();
            this.Loguearse = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtReContraseña = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.Label();
            this.Contraseña = new System.Windows.Forms.Label();
            this.RepetirContraseña = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(126, 80);
            this.IP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(193, 26);
            this.IP.TabIndex = 2;
            this.IP.Text = "192.168.56.101";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(694, 458);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(198, 62);
            this.Desconectar.TabIndex = 7;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.button3_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(694, 148);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(136, 54);
            this.Registrarse.TabIndex = 8;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Loguearse
            // 
            this.Loguearse.Location = new System.Drawing.Point(694, 351);
            this.Loguearse.Name = "Loguearse";
            this.Loguearse.Size = new System.Drawing.Size(136, 55);
            this.Loguearse.TabIndex = 9;
            this.Loguearse.Text = "Loguearse";
            this.Loguearse.UseVisualStyleBackColor = true;
            this.Loguearse.Click += new System.EventHandler(this.Loguearse_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(694, 34);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 26);
            this.txtUsuario.TabIndex = 10;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(694, 92);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(100, 26);
            this.txtContraseña.TabIndex = 11;
            // 
            // txtReContraseña
            // 
            this.txtReContraseña.Location = new System.Drawing.Point(836, 92);
            this.txtReContraseña.Name = "txtReContraseña";
            this.txtReContraseña.Size = new System.Drawing.Size(100, 26);
            this.txtReContraseña.TabIndex = 12;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(694, 249);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 26);
            this.txtUser.TabIndex = 13;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(694, 302);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 26);
            this.txtPassword.TabIndex = 14;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(690, 9);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(64, 20);
            this.Usuario.TabIndex = 15;
            this.Usuario.Text = "Usuario";
            // 
            // Contraseña
            // 
            this.Contraseña.AutoSize = true;
            this.Contraseña.Location = new System.Drawing.Point(690, 69);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(92, 20);
            this.Contraseña.TabIndex = 16;
            this.Contraseña.Text = "Contraseña";
            // 
            // RepetirContraseña
            // 
            this.RepetirContraseña.AutoSize = true;
            this.RepetirContraseña.Location = new System.Drawing.Point(832, 69);
            this.RepetirContraseña.Name = "RepetirContraseña";
            this.RepetirContraseña.Size = new System.Drawing.Size(144, 20);
            this.RepetirContraseña.TabIndex = 17;
            this.RepetirContraseña.Text = "RepetirContraseña";
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(694, 228);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(43, 20);
            this.User.TabIndex = 18;
            this.User.Text = "User";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(693, 278);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(78, 20);
            this.Password.TabIndex = 19;
            this.Password.Text = "Password";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(102, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(133, 373);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(185, 54);
            this.Actualizar.TabIndex = 21;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 749);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.User);
            this.Controls.Add(this.RepetirContraseña);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtReContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.Loguearse);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button Loguearse;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtReContraseña;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label Contraseña;
        private System.Windows.Forms.Label RepetirContraseña;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Actualizar;
    }
}

