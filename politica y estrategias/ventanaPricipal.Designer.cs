﻿namespace politica_y_estrategias
{
    partial class ventanaPricipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_CrearEstra = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.estado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(342, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 24);
            this.button3.TabIndex = 27;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(15, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(382, 117);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Servidores";
            this.Column1.Name = "Column1";
            this.Column1.Width = 169;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Seleccionar";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 169;
            // 
            // btn_CrearEstra
            // 
            this.btn_CrearEstra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CrearEstra.Location = new System.Drawing.Point(211, 129);
            this.btn_CrearEstra.Name = "btn_CrearEstra";
            this.btn_CrearEstra.Size = new System.Drawing.Size(55, 25);
            this.btn_CrearEstra.TabIndex = 29;
            this.btn_CrearEstra.Text = "Nueva";
            this.btn_CrearEstra.UseVisualStyleBackColor = true;
            this.btn_CrearEstra.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Controls.Add(this.groupBoxServer);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Location = new System.Drawing.Point(12, 11);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(484, 406);
            this.panel7.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_CrearEstra);
            this.groupBox1.Location = new System.Drawing.Point(27, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 163);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estrategias y politicas existentes:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(342, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 25);
            this.button4.TabIndex = 31;
            this.button4.Text = "Status";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView2.Location = new System.Drawing.Point(15, 29);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(382, 94);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estrategia";
            this.Column3.Name = "Column3";
            this.Column3.Width = 113;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Politica";
            this.Column4.Name = "Column4";
            this.Column4.Width = 113;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Activa";
            this.Column5.Name = "Column5";
            this.Column5.Width = 113;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 30;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.button3);
            this.groupBoxServer.Controls.Add(this.dataGridView1);
            this.groupBoxServer.Location = new System.Drawing.Point(27, 36);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(427, 177);
            this.groupBoxServer.TabIndex = 26;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Servidores existentes";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(110, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(258, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Seleccione Servidor a ejecutar ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // estado
            // 
            this.estado.Enabled = false;
            this.estado.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.estado.Location = new System.Drawing.Point(12, 434);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(153, 20);
            this.estado.TabIndex = 26;
            this.estado.Text = "Programa inicializado...";
            // 
            // ventanaPricipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(512, 459);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.panel7);
            this.Name = "ventanaPricipal";
            this.Text = "Sistema Automatizado de Respaldo ( GENERADOR DE ESTRATEGIAS)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBoxServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_CrearEstra;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox estado;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

