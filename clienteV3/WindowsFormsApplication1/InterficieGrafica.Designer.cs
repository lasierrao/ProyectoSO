namespace WindowsFormsApplication1
{
    partial class InterficieGrafica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.lbl_mensaje = new System.Windows.Forms.Label();
            this.btn_enviar_msj = new System.Windows.Forms.Button();
            this.box_msj = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.fondo_verde;
            this.panel1.Location = new System.Drawing.Point(27, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 450);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(699, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // lbl_mensaje
            // 
            this.lbl_mensaje.AutoSize = true;
            this.lbl_mensaje.Location = new System.Drawing.Point(42, 493);
            this.lbl_mensaje.Name = "lbl_mensaje";
            this.lbl_mensaje.Size = new System.Drawing.Size(50, 13);
            this.lbl_mensaje.TabIndex = 4;
            this.lbl_mensaje.Text = "Mensaje:";
            // 
            // btn_enviar_msj
            // 
            this.btn_enviar_msj.Location = new System.Drawing.Point(353, 527);
            this.btn_enviar_msj.Name = "btn_enviar_msj";
            this.btn_enviar_msj.Size = new System.Drawing.Size(75, 23);
            this.btn_enviar_msj.TabIndex = 5;
            this.btn_enviar_msj.Text = "Enviar";
            this.btn_enviar_msj.UseVisualStyleBackColor = true;
            this.btn_enviar_msj.Click += new System.EventHandler(this.btn_enviar_msj_Click);
            // 
            // box_msj
            // 
            this.box_msj.Location = new System.Drawing.Point(45, 527);
            this.box_msj.Name = "box_msj";
            this.box_msj.Size = new System.Drawing.Size(274, 20);
            this.box_msj.TabIndex = 6;
            // 
            // InterficieGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 594);
            this.Controls.Add(this.box_msj);
            this.Controls.Add(this.btn_enviar_msj);
            this.Controls.Add(this.lbl_mensaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "InterficieGrafica";
            this.Text = "InterficieGrafica";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InterficieGrafica_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lbl_mensaje;
        private System.Windows.Forms.Button btn_enviar_msj;
        private System.Windows.Forms.TextBox box_msj;
    }
}