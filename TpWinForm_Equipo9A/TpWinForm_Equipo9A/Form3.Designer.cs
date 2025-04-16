namespace TpWinForm_Equipo9A
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextDescripcion = new System.Windows.Forms.Label();
            this.newNombre = new System.Windows.Forms.TextBox();
            this.inputDescripcion = new System.Windows.Forms.TextBox();
            this.newAceptar = new System.Windows.Forms.Button();
            this.newCancelar = new System.Windows.Forms.Button();
            this.textCod = new System.Windows.Forms.Label();
            this.inputCod = new System.Windows.Forms.TextBox();
            this.inputPrecio = new System.Windows.Forms.NumericUpDown();
            this.textPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TextDescripcion
            // 
            this.TextDescripcion.AutoSize = true;
            this.TextDescripcion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextDescripcion.Location = new System.Drawing.Point(49, 226);
            this.TextDescripcion.Name = "TextDescripcion";
            this.TextDescripcion.Size = new System.Drawing.Size(109, 18);
            this.TextDescripcion.TabIndex = 2;
            this.TextDescripcion.Text = "Descripcion:";
            // 
            // newNombre
            // 
            this.newNombre.Location = new System.Drawing.Point(164, 93);
            this.newNombre.Name = "newNombre";
            this.newNombre.Size = new System.Drawing.Size(146, 20);
            this.newNombre.TabIndex = 3;
            // 
            // inputDescripcion
            // 
            this.inputDescripcion.Location = new System.Drawing.Point(164, 227);
            this.inputDescripcion.Name = "inputDescripcion";
            this.inputDescripcion.Size = new System.Drawing.Size(146, 20);
            this.inputDescripcion.TabIndex = 4;
            // 
            // newAceptar
            // 
            this.newAceptar.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newAceptar.Location = new System.Drawing.Point(109, 276);
            this.newAceptar.Name = "newAceptar";
            this.newAceptar.Size = new System.Drawing.Size(232, 40);
            this.newAceptar.TabIndex = 5;
            this.newAceptar.Text = "Agregar producto ";
            this.newAceptar.UseVisualStyleBackColor = true;
            this.newAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // newCancelar
            // 
            this.newCancelar.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCancelar.Location = new System.Drawing.Point(164, 345);
            this.newCancelar.Name = "newCancelar";
            this.newCancelar.Size = new System.Drawing.Size(134, 40);
            this.newCancelar.TabIndex = 6;
            this.newCancelar.Text = "Salir";
            this.newCancelar.UseVisualStyleBackColor = true;
            this.newCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // textCod
            // 
            this.textCod.AutoSize = true;
            this.textCod.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCod.Location = new System.Drawing.Point(89, 140);
            this.textCod.Name = "textCod";
            this.textCod.Size = new System.Drawing.Size(69, 18);
            this.textCod.TabIndex = 7;
            this.textCod.Text = "Codigo:";
            // 
            // inputCod
            // 
            this.inputCod.Location = new System.Drawing.Point(164, 140);
            this.inputCod.Name = "inputCod";
            this.inputCod.Size = new System.Drawing.Size(146, 20);
            this.inputCod.TabIndex = 8;
            // 
            // inputPrecio
            // 
            this.inputPrecio.DecimalPlaces = 3;
            this.inputPrecio.Location = new System.Drawing.Point(164, 183);
            this.inputPrecio.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.inputPrecio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputPrecio.Name = "inputPrecio";
            this.inputPrecio.Size = new System.Drawing.Size(146, 20);
            this.inputPrecio.TabIndex = 9;
            this.inputPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputPrecio.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // textPrecio
            // 
            this.textPrecio.AutoSize = true;
            this.textPrecio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrecio.Location = new System.Drawing.Point(82, 182);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(65, 18);
            this.textPrecio.TabIndex = 10;
            this.textPrecio.Text = "Precio:";
            this.textPrecio.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(448, 450);
            this.Controls.Add(this.textPrecio);
            this.Controls.Add(this.inputPrecio);
            this.Controls.Add(this.inputCod);
            this.Controls.Add(this.textCod);
            this.Controls.Add(this.newCancelar);
            this.Controls.Add(this.newAceptar);
            this.Controls.Add(this.inputDescripcion);
            this.Controls.Add(this.newNombre);
            this.Controls.Add(this.TextDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TextDescripcion;
        private System.Windows.Forms.TextBox newNombre;
        private System.Windows.Forms.TextBox inputDescripcion;
        private System.Windows.Forms.Button newAceptar;
        private System.Windows.Forms.Button newCancelar;
        private System.Windows.Forms.Label textCod;
        private System.Windows.Forms.TextBox inputCod;
        private System.Windows.Forms.NumericUpDown inputPrecio;
        private System.Windows.Forms.Label textPrecio;
    }
}