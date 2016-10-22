using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using System.IO;
using politica_y_estrategias;

namespace politica_y_estrategias
{
    public partial class Servidores : Form
    {
        private Form1 principal; 
        public Servidores(Form1 p)
        {
            principal = p;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        public void GuardarServer() {
            string nom=nombre_txt.Text.ToUpper();
            string datbalink = textBox1.Text.ToUpper();
            string usuario = textBox2.Text.ToUpper();
            string contra = textBox3.Text.ToUpper();
            string ip = textBox4.Text.ToUpper();
            string puerto = textBox5.Text.ToUpper();
            string nomBase = textBox6.Text.ToUpper();

            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            Server s = new Server(nom,datbalink,usuario,contra,ip,puerto,nomBase);
            s.guardar_Server(escrito);
            principal.addServer(s);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GuardarServer();
        }
    }
}
