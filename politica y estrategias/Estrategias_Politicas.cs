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
using Oracle.DataAccess.Client;
using Logic;
using politica_y_estrategias;

namespace politica_y_estrategias
{
    public partial class Estrategias_Politicas : Form
    {
        //String ConexionOracle = "User id= System; Password=admin123; Data Source= XE;"; //////cambiar password
        //Server g = new Server();
        OracleConnection con = new OracleConnection();

        private ventanaPricipal principal;

        public Estrategias_Politicas(ventanaPricipal p, Estrategia es, Politica po)
        {
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
            llenarCampos(es,po);
        }

        private void llenarCampos(Estrategia es, Politica p) {
            nom_estra.Text = es.getNombre();
            marcarTipoRespaldo(es.getTipoRes());
            if (es.getModoRes() == 1)
                radioButton6.Checked = true;
            else
                radioButton5.Checked = true;
            marcarTablespace(es.getTablespaces());
        }
        private void marcarTipoRespaldo(int op) {
            switch (op) {
                case 1: radioButton1.Checked = true; break;
                case 2: radioButton2.Checked = true; break;
                case 3: radioButton3.Checked = true; break;
                default: MessageBox.Show("Error..."); break;    
            }
        }

        private void marcarTablespace(List<string> l) { // Terminar
            if (l.Count != 0) {
                check_Tablespaces.Checked = true;
            }
          /*  for (int i =0; i< checkedList_Tablespaces.Items.Count; i++)
            {
                if (checList_Tablespaces[i].toString() == l.ToString()) { }
                string e = l.Find(x => x == item.ToString());
                if (e != null)
               
                tablespaces.Add(item.ToString());
            }*/
        }
        public Estrategias_Politicas(ventanaPricipal p)
        {
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
        }

        //------ METODOS---------//
        private void Guardar_Estrategia()
        {

            string nombre;
            int tipoRes = 0;
            int modoRes = 0;
            List<string> tablespaces = new List<string>();
            int[] plus = new int[3];
            plus[0] = 0;
            plus[1] = 0;
            plus[2] = 0;

            nombre = this.nom_estra.Text.ToUpper();


            foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
            {
                tablespaces.Add(itemChecked.ToString());
            }

            if (check_Archive.Checked)
                plus[0] = 1;
            if (check_ControlF.Checked)
                plus[1] = 1;
            if (checkBox2.Checked)
                plus[2] = 1;
            if (radioButton1.Checked)
                tipoRes = 1;
            if (radioButton2.Checked)
                tipoRes = 2;
            if (radioButton3.Checked)
                tipoRes = 3;
            if (radioButton6.Checked)
                modoRes = 1;
            if (radioButton5.Checked)
                modoRes = 2;

            Estrategia estrategia = new Estrategia(principal.getServer(), nombre, tipoRes, modoRes, tablespaces, plus);
            principal.addEstrategias(estrategia);
            estrategia.Guardar_Estrategia(estrategia);
            principal.add_Check_Estrategia(nombre);

            MessageBox.Show("Estrategia " + nombre + " Creada Con Exito", "Success", MessageBoxButtons.OK);
        }

        private void llenarCheckedList_Tablespaces()
        {
            con.Open();
            String sql = "SELECT tablespace_name FROM dba_tablespaces";
            OracleDataAdapter datos = new OracleDataAdapter(sql, con);
            DataSet data = new DataSet();
            datos.Fill(data);
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                checkedList_Tablespaces.Items.Add(data.Tables[0].Rows[i][0]);

            }
            checkedList_Tablespaces.HorizontalScrollbar = true;
            con.Close();
        }

        private void fullBackup(bool state1, bool state2)
        {
            radioButton5.Checked = state2;
            panel4.Enabled = state1;

            check_Tablespaces.Checked = state2;
            check_Tablespaces.Enabled = state1;

            for (int item = 0; item < checkedList_Tablespaces.Items.Count; item++)
            {
                checkedList_Tablespaces.SetItemChecked(item, state2);
            }
            checkedList_Tablespaces.Enabled = state1;
            check_Archive.Checked = state2;
            checkBox2.Checked = state2;
            check_ControlF.Checked = state2;
            // btn_Cancelar.Enabled = state2;
        }

        //-------- EVENTOS----------//
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                fullBackup(false, true);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                fullBackup(true, false);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                fullBackup(true, false);
            }
        }

        private void check_Tablespaces_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Tablespaces.Checked)
                llenarCheckedList_Tablespaces();
            else
                checkedList_Tablespaces.Items.Clear();
        }
 
     

        private void button2_Click(object sender, EventArgs e)
        {

        }
//-------------------------Politica---------------------------------
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
           

            MessageBox.Show("Politica " + p.getNombre() + " Creada Con Exito", "Success", MessageBoxButtons.OK);
            
        }

        private void btn_CrearEstra_Click_1(object sender, EventArgs e)
        {
            Guardar_Estrategia();
            Guardar_Politica();
            Guardar_Tarea();
           // MessageBox.Show("Creado... ");
            this.Close();
        }

        private void Guardar_Tarea(){
            Tarea t = new Tarea(principal.getServer(), nom_estra.Text, nom_Politica.Text,1);
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            t.guardar_Tarea(escrito);
            principal.guardar_Tarea(t);
        }

        private void btn_CrearEstra_Click_2(object sender, EventArgs e)
        {
            Guardar_Estrategia();
            Guardar_Politica();
            Guardar_Tarea();
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        /*  private void button1_Click(object sender, EventArgs e)
 {
     this.Close();
 }

 private void button2_Click(object sender, EventArgs e)
 {
     Guardar_Politica();
     this.Close();
 }

 private void Politicas_Load(object sender, EventArgs e)
 {

 }*/

    }
}
