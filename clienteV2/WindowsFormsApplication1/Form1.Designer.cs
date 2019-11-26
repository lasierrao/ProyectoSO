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
            this.btnConectar = new System.Windows.Forms.Button();
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
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(319, 294);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(135, 40);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.bntConectar_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(517, 294);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(2);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(132, 40);
            this.Desconectar.TabIndex = 7;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.button3_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(318, 210);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(2);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(91, 35);
            this.Registrarse.TabIndex = 8;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Loguearse
            // 
            this.Loguearse.Location = new System.Drawing.Point(517, 160);
            this.Loguearse.Margin = new System.Windows.Forms.Padding(2);
            this.Loguearse.Name = "Loguearse";
            this.Loguearse.Size = new System.Drawing.Size(91, 36);
            this.Loguearse.TabIndex = 9;
            this.Loguearse.Text = "Loguearse";
            this.Loguearse.UseVisualStyleBackColor = true;
            this.Loguearse.Click += new System.EventHandler(this.Loguearse_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(319, 60);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(111, 20);
            this.txtUsuario.TabIndex = 10;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(319, 115);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(111, 20);
            this.txtContraseña.TabIndex = 11;
            // 
            // txtReContraseña
            // 
            this.txtReContraseña.Location = new System.Drawing.Point(319, 176);
            this.txtReContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtReContraseña.Name = "txtReContraseña";
            this.txtReContraseña.Size = new System.Drawing.Size(111, 20);
            this.txtReContraseña.TabIndex = 12;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(517, 60);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(101, 20);
            this.txtUser.TabIndex = 13;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(517, 115);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(101, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Location = new System.Drawing.Point(316, 43);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(43, 13);
            this.Usuario.TabIndex = 15;
            this.Usuario.Text = "Usuario";
            // 
            // Contraseña
            // 
            this.Contraseña.AutoSize = true;
            this.Contraseña.Location = new System.Drawing.Point(316, 89);
            this.Contraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(61, 13);
            this.Contraseña.TabIndex = 16;
            this.Contraseña.Text = "Contraseña";
            // 
            // RepetirContraseña
            // 
            this.RepetirContraseña.AutoSize = true;
            this.RepetirContraseña.Location = new System.Drawing.Point(315, 152);
            this.RepetirContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RepetirContraseña.Name = "RepetirContraseña";
            this.RepetirContraseña.Size = new System.Drawing.Size(95, 13);
            this.RepetirContraseña.TabIndex = 17;
            this.RepetirContraseña.Text = "RepetirContraseña";
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(514, 43);
            this.User.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(29, 13);
            this.User.TabIndex = 18;
            this.User.Text = "User";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(514, 89);
            this.Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 19;
            this.Password.Text = "Password";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 43);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(213, 202);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(93, 266);
            this.Actualizar.Margin = new System.Windows.Forms.Padding(2);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(123, 35);
            this.Actualizar.TabIndex = 21;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 384);
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
            this.Controls.Add(this.btnConectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
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

