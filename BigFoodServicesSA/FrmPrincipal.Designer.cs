namespace BigFoodServicesSA
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumero = new System.Windows.Forms.Label();
            this.btnNum = new System.Windows.Forms.Button();
            this.lblContadorErrores = new System.Windows.Forms.Label();
            this.lblErrorM = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransferencias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(447, 272);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(102, 39);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Iniciar";
            // 
            // btnNum
            // 
            this.btnNum.BackColor = System.Drawing.Color.Firebrick;
            this.btnNum.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNum.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNum.Location = new System.Drawing.Point(375, 375);
            this.btnNum.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNum.Name = "btnNum";
            this.btnNum.Size = new System.Drawing.Size(269, 70);
            this.btnNum.TabIndex = 1;
            this.btnNum.Text = "Iniciar proceso";
            this.btnNum.UseVisualStyleBackColor = false;
            this.btnNum.Click += new System.EventHandler(this.btnNum_Click);
            // 
            // lblContadorErrores
            // 
            this.lblContadorErrores.AutoSize = true;
            this.lblContadorErrores.Location = new System.Drawing.Point(549, 203);
            this.lblContadorErrores.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContadorErrores.Name = "lblContadorErrores";
            this.lblContadorErrores.Size = new System.Drawing.Size(0, 26);
            this.lblContadorErrores.TabIndex = 2;
            // 
            // lblErrorM
            // 
            this.lblErrorM.AutoSize = true;
            this.lblErrorM.Location = new System.Drawing.Point(15, 203);
            this.lblErrorM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorM.Name = "lblErrorM";
            this.lblErrorM.Size = new System.Drawing.Size(81, 26);
            this.lblErrorM.TabIndex = 3;
            this.lblErrorM.Text = "Errores:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transferencias realizadas:";
            // 
            // lblTransferencias
            // 
            this.lblTransferencias.AutoSize = true;
            this.lblTransferencias.Location = new System.Drawing.Point(264, 125);
            this.lblTransferencias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransferencias.Name = "lblTransferencias";
            this.lblTransferencias.Size = new System.Drawing.Size(0, 26);
            this.lblTransferencias.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 39);
            this.label2.TabIndex = 7;
            this.label2.Text = "BigFoodService S.A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BigFoodServicesSA.Properties.Resources.personaje_mascota_hamburguesa_6427_395;
            this.pictureBox1.Location = new System.Drawing.Point(652, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 411);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "transfer program";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(227)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(1041, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTransferencias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblErrorM);
            this.Controls.Add(this.lblContadorErrores);
            this.Controls.Add(this.btnNum);
            this.Controls.Add(this.lblNumero);
            this.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FrmPrincipal";
            this.Text = "Migración de datos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Button btnNum;
        private System.Windows.Forms.Label lblContadorErrores;
        private System.Windows.Forms.Label lblErrorM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransferencias;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

