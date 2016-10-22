namespace politica_y_estrategias
{
    partial class Politicas
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nom_Politica = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.num_Segundos = new System.Windows.Forms.NumericUpDown();
            this.num_Minutos = new System.Windows.Forms.NumericUpDown();
            this.num_Hora = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.num_Tiempo = new System.Windows.Forms.NumericUpDown();
            this.radioB_Otro = new System.Windows.Forms.RadioButton();
            this.radioB_120 = new System.Windows.Forms.RadioButton();
            this.radioB_60 = new System.Windows.Forms.RadioButton();
            this.radioB_30 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkedList_Dias = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Segundos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hora)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.nom_Politica);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.num_Segundos);
            this.panel2.Controls.Add(this.num_Minutos);
            this.panel2.Controls.Add(this.num_Hora);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.checkedList_Dias);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 231);
            this.panel2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Crear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nom_Politica
            // 
            this.nom_Politica.Location = new System.Drawing.Point(100, 31);
            this.nom_Politica.Name = "nom_Politica";
            this.nom_Politica.Size = new System.Drawing.Size(112, 20);
            this.nom_Politica.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Nombre politica:";
            // 
            // num_Segundos
            // 
            this.num_Segundos.Location = new System.Drawing.Point(296, 131);
            this.num_Segundos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_Segundos.Name = "num_Segundos";
            this.num_Segundos.Size = new System.Drawing.Size(37, 20);
            this.num_Segundos.TabIndex = 29;
            // 
            // num_Minutos
            // 
            this.num_Minutos.Location = new System.Drawing.Point(229, 131);
            this.num_Minutos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.num_Minutos.Name = "num_Minutos";
            this.num_Minutos.Size = new System.Drawing.Size(37, 20);
            this.num_Minutos.TabIndex = 28;
            // 
            // num_Hora
            // 
            this.num_Hora.Location = new System.Drawing.Point(171, 131);
            this.num_Hora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.num_Hora.Name = "num_Hora";
            this.num_Hora.Size = new System.Drawing.Size(37, 20);
            this.num_Hora.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(293, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Segundos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(226, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Minutos";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.radioB_Otro);
            this.panel6.Controls.Add(this.radioB_120);
            this.panel6.Controls.Add(this.radioB_60);
            this.panel6.Controls.Add(this.radioB_30);
            this.panel6.Location = new System.Drawing.Point(383, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(105, 119);
            this.panel6.TabIndex = 24;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.num_Tiempo);
            this.panel8.Location = new System.Drawing.Point(6, 91);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(98, 30);
            this.panel8.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Minutos";
            // 
            // num_Tiempo
            // 
            this.num_Tiempo.Location = new System.Drawing.Point(49, 5);
            this.num_Tiempo.Name = "num_Tiempo";
            this.num_Tiempo.Size = new System.Drawing.Size(47, 20);
            this.num_Tiempo.TabIndex = 4;
            // 
            // radioB_Otro
            // 
            this.radioB_Otro.AutoSize = true;
            this.radioB_Otro.Location = new System.Drawing.Point(4, 72);
            this.radioB_Otro.Name = "radioB_Otro";
            this.radioB_Otro.Size = new System.Drawing.Size(45, 17);
            this.radioB_Otro.TabIndex = 3;
            this.radioB_Otro.TabStop = true;
            this.radioB_Otro.Text = "Otro";
            this.radioB_Otro.UseVisualStyleBackColor = true;
            // 
            // radioB_120
            // 
            this.radioB_120.AutoSize = true;
            this.radioB_120.Location = new System.Drawing.Point(3, 50);
            this.radioB_120.Name = "radioB_120";
            this.radioB_120.Size = new System.Drawing.Size(62, 17);
            this.radioB_120.TabIndex = 2;
            this.radioB_120.TabStop = true;
            this.radioB_120.Text = "120 min";
            this.radioB_120.UseVisualStyleBackColor = true;
            // 
            // radioB_60
            // 
            this.radioB_60.AutoSize = true;
            this.radioB_60.Location = new System.Drawing.Point(3, 27);
            this.radioB_60.Name = "radioB_60";
            this.radioB_60.Size = new System.Drawing.Size(56, 17);
            this.radioB_60.TabIndex = 1;
            this.radioB_60.TabStop = true;
            this.radioB_60.Text = "60 min";
            this.radioB_60.UseVisualStyleBackColor = true;
            // 
            // radioB_30
            // 
            this.radioB_30.AutoSize = true;
            this.radioB_30.Location = new System.Drawing.Point(3, 4);
            this.radioB_30.Name = "radioB_30";
            this.radioB_30.Size = new System.Drawing.Size(56, 17);
            this.radioB_30.TabIndex = 0;
            this.radioB_30.TabStop = true;
            this.radioB_30.Text = "30 min";
            this.radioB_30.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "Politica";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Frecuencia de aplicación";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Hora";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Repetición ";
            // 
            // checkedList_Dias
            // 
            this.checkedList_Dias.FormattingEnabled = true;
            this.checkedList_Dias.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.checkedList_Dias.Location = new System.Drawing.Point(17, 74);
            this.checkedList_Dias.Name = "checkedList_Dias";
            this.checkedList_Dias.Size = new System.Drawing.Size(123, 109);
            this.checkedList_Dias.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Incio dia";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateTimePicker1.Location = new System.Drawing.Point(164, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(199, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // Politicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 255);
            this.Controls.Add(this.panel2);
            this.Name = "Politicas";
            this.Text = "Politica";
            this.Load += new System.EventHandler(this.Politicas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Segundos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hora)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tiempo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox nom_Politica;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown num_Segundos;
        private System.Windows.Forms.NumericUpDown num_Minutos;
        private System.Windows.Forms.NumericUpDown num_Hora;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown num_Tiempo;
        private System.Windows.Forms.RadioButton radioB_Otro;
        private System.Windows.Forms.RadioButton radioB_120;
        private System.Windows.Forms.RadioButton radioB_60;
        private System.Windows.Forms.RadioButton radioB_30;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox checkedList_Dias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
    }
}