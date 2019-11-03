namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.btn_mos_jug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_mos_jug
            // 
            this.btn_mos_jug.Location = new System.Drawing.Point(201, 195);
            this.btn_mos_jug.Name = "btn_mos_jug";
            this.btn_mos_jug.Size = new System.Drawing.Size(75, 23);
            this.btn_mos_jug.TabIndex = 0;
            this.btn_mos_jug.Text = "Mostrar jugadores";
            this.btn_mos_jug.UseVisualStyleBackColor = true;
            this.btn_mos_jug.Click += new System.EventHandler(this.btn_mos_jug_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 346);
            this.Controls.Add(this.btn_mos_jug);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_mos_jug;
    }
}