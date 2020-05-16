namespace Laberinto
{
    partial class frmLaberinto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTamanio = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.mapa = new System.Windows.Forms.Panel();
            this.btnSolucionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "GENERADOR DE LABERINTOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(201, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tamaño del laberinto:";
            // 
            // cmbTamanio
            // 
            this.cmbTamanio.BackColor = System.Drawing.Color.DarkCyan;
            this.cmbTamanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTamanio.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTamanio.ForeColor = System.Drawing.Color.White;
            this.cmbTamanio.FormattingEnabled = true;
            this.cmbTamanio.Items.AddRange(new object[] {
            "Pequeño",
            "Mediano",
            "Grande"});
            this.cmbTamanio.Location = new System.Drawing.Point(362, 238);
            this.cmbTamanio.Name = "cmbTamanio";
            this.cmbTamanio.Size = new System.Drawing.Size(121, 27);
            this.cmbTamanio.TabIndex = 3;
            this.cmbTamanio.SelectedValueChanged += new System.EventHandler(this.CmbTamanio_SelectedValueChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(16, 420);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 29);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(760, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bienvenido al laberinto de laberintos, este programa le permitirá generar laberin" +
    "tos aleatorios que le brindarán horas de diversión. ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnJugar
            // 
            this.btnJugar.AutoSize = true;
            this.btnJugar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.Location = new System.Drawing.Point(442, 420);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(75, 29);
            this.btnJugar.TabIndex = 6;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.BtnJugar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.AutoSize = true;
            this.btnMenu.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(309, 420);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 29);
            this.btnMenu.TabIndex = 8;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Visible = false;
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapa.Location = new System.Drawing.Point(16, 80);
            this.mapa.Name = "mapa";
            this.mapa.Size = new System.Drawing.Size(756, 334);
            this.mapa.TabIndex = 7;
            this.mapa.Visible = false;
            // 
            // btnSolucionar
            // 
            this.btnSolucionar.AutoSize = true;
            this.btnSolucionar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolucionar.Location = new System.Drawing.Point(673, 420);
            this.btnSolucionar.Name = "btnSolucionar";
            this.btnSolucionar.Size = new System.Drawing.Size(99, 29);
            this.btnSolucionar.TabIndex = 9;
            this.btnSolucionar.Text = "Solucionar";
            this.btnSolucionar.UseVisualStyleBackColor = true;
            this.btnSolucionar.Visible = false;
            this.btnSolucionar.Click += new System.EventHandler(this.BtnSolucionar_Click);
            // 
            // frmLaberinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSolucionar);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.mapa);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cmbTamanio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmLaberinto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de laberintos";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmLaberinto_KeyPress);
            this.Resize += new System.EventHandler(this.FrmLaberinto_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTamanio;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel mapa;
        private System.Windows.Forms.Button btnSolucionar;
    }
}

