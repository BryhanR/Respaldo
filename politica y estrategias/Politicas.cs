using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Logic;
using politica_y_estrategias;

namespace politica_y_estrategias
{
    public partial class Politicas : Form
    {
        private Form1 principal;
        // private string nom_Server;

        public Politicas(Form1 p)
        {
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
        }

        private DateTime getDate()
        {
            int d = dateTimePicker1.Value.Day;
            int mes = dateTimePicker1.Value.Month;
            int a = dateTimePicker1.Value.Year;
            int h = (int)num_Hora.Value;
            int m = (int)num_Minutos.Value;
            int s = (int)num_Segundos.Value;
            return new DateTime(a, mes, d, h, m, s);
        }

        //------ METODOS -------//
        private void Guardar_Politica()
        {
            Politica p = new Politica();

            p.setServer(principal.getServer());
            p.setNombre(this.nom_Politica.Text.ToUpper());

            // La frecuencia
            foreach (object itemChecked in checkedList_Dias.CheckedItems)
            {
                p.addFrecuencia(itemChecked.ToString().ToUpper());
            }

            p.setFecha(getDate());

            // Repeticion
            if (radioB_30.Checked)
                p.setRepeticion(30);
            if (radioB_60.Checked)
                p.setRepeticion(60);
            if (radioB_120.Checked)
                p.setRepeticion(120);
            if (radioB_Otro.Checked)
                p.setRepeticion((int)num_Tiempo.Value);

            //Abrimos el archivo txt
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            principal.addPolitica(p);
            p.guardar_Politica(escrito);
            principal.add_Check_Politica(p.getNombre());
        }

        //------ EVENTOS--------//
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar_Politica();
        }

        private void Politicas_Load(object sender, EventArgs e)
        {

        }
    }
}
