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

        public string getNombre() {
            return nombre_txt.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server s = new Server(nombre_txt.Text);
            principal.addServer(s);
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            s.guardar_Server(escrito);
        }
    }
}
