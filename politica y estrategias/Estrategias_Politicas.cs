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

        private ventanaPrincipal principal;

        public Estrategias_Politicas(ventanaPrincipal p, Estrategia es, Politica po)
        {
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
            llenarCampos(es,po);
        }

        private void llenarCampos(Estrategia es, Politica p) {
            llenarCamposEstrategia(es);
            llenarCamposPolitica(p);
        }
       private void  llenarCamposPolitica(Politica p){
           nom_Politica.Text = p.getNombre();
           dateTimePicker1.Value = p.getFecha();
           num_Hora.Value = dateTimePicker1.Value.Hour;
           num_Minutos.Value = dateTimePicker1.Value.Minute;
           num_Segundos.Value = dateTimePicker1.Value.Second;
           marcarRepeticion(p.getRepeticion());
           marcarFrecuencia(p.getListFrecuencia());
        }

       private void marcarFrecuencia(List<string> l)
       { // Terminar
           l.ForEach(delegate(String dia)
           {
               int pos = checkedList_Dias.FindStringExact(dia);
               if (pos != -1)
               {
                   checkedList_Dias.SetItemChecked(pos, true);
               }
           });
          
        
       }

       private void marcarRepeticion(int op) {
           switch (op) {
               case 30: radioB_30.Checked = true; break;
               case 60: radioB_60.Checked = true; break;
               case 120: radioB_120.Checked = true; break;
               default: radioB_Otro.Checked = true; num_Tiempo.Value = op; break;
           }
       }
        private void llenarCamposEstrategia(Estrategia es){
              nom_estra.Text = es.getNombre();
            marcarTipoRespaldo(es.getTipoRes());
            if (es.getModoRes() == 1)
                radioButton6.Checked = true;
            else
                radioButton5.Checked = true;
            marcarTablespace(es.getTablespaces());
            marcarIncuir(es.getPlus());
            // Terminar falta tablespaces
        }
        private void marcarIncuir(int[] op) {
            if (op[0] == 1)
                check_Archive.Checked = true;
            if (op[1] == 1)
                check_ControlF.Checked = true;
            if (op[2] == 1)
                check_IniitF.Checked = true;
        }
        private void marcarTipoRespaldo(int op)
        {
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

            l.ForEach(delegate(String tablespace)
            {
                int pos = checkedList_Tablespaces.FindStringExact(tablespace);
                if (pos != -1)
                {
                    checkedList_Tablespaces.SetItemChecked(pos, true);
                }
            });

        }
        public Estrategias_Politicas(ventanaPrincipal p)
        {
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
            nom_estra.Text = p.getServer()+"E"+p.getEstrategiasServer().Count;
            nom_Politica.Text = p.getServer() + "P" + p.getPoliticasServer().Count;
        }

        //------ METODOS---------//
        private void Guardar_Estrategia()
        {
            
            Estrategia estrategia = new Estrategia();

            estrategia.setNomServer(principal.getServer());

            estrategia.setNombre(this.nom_estra.Text.ToUpper());


            foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
            {
                estrategia.addTablespace(itemChecked.ToString());
            }
            int[] plus = new int[3];
            plus[0] = 0;
            plus[1] = 0;
            plus[2] = 0;

            if (check_Archive.Checked)
                plus[0] = 1;
            if (check_ControlF.Checked)
                plus[1] = 1;
            if (check_IniitF.Checked)
                plus[2] = 1;

            estrategia.setPlus(plus);
 
            if (radioButton1.Checked)
                estrategia.setTipoRes(1);
            if (radioButton2.Checked)
                estrategia.setTipoRes(2);
            if (radioButton3.Checked)
                estrategia.setTipoRes(3);
            
            if (radioButton6.Checked)
                estrategia.setModoRes(1);
            if (radioButton5.Checked)
                estrategia.setModoRes(2);

           
           

            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            estrategia.Guardar_Estrategia(escrito);
            escrito.Close();
            principal.addEstrategias(estrategia);
            principal.add_Check_Estrategia(estrategia.getNombre());

            MessageBox.Show("Estrategia " + estrategia.getNombre() + " Creada Con Exito", "Success", MessageBoxButtons.OK);
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
            check_IniitF.Checked = state2;
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
            p.setRepeticion(getCanRepeticion());
            
        

            //Abrimos el archivo txt
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            principal.addPolitica(p);
            p.guardar_Politica(escrito);
            escrito.Close();

            MessageBox.Show("Politica " + p.getNombre() + " Creada Con Exito", "Success", MessageBoxButtons.OK);
            
        }
        private int getCanRepeticion() { 
         if (radioB_30.Checked)
                return 30;
            if (radioB_60.Checked)
               return 60;
            if (radioB_120.Checked)
                return 120;
            if (radioB_Otro.Checked)
            return (int)num_Tiempo.Value;
            return 0;
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
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"),true); // escribe al final de Servidores.txt
            t.guardar_Tarea(escrito);
            principal.guardar_Tarea(t);
            escrito.Close();
        }

        private void btn_CrearEstra_Click_2(object sender, EventArgs e)
        {
            //crear_o_Modificar();
            Guardar_Estrategia();
            Guardar_Politica();
            Guardar_Tarea();
            this.Close();
        }

        private void crear_o_Modificar() {
           
            
          Politica existe = principal.getPoliticasServer().Find(x =>
            {
                if (x.getNombre() == nom_Politica.Text)
                {
                    x.setFecha(getDate());
                    x.getListFrecuencia().Clear();
                    // La frecuencia
                    foreach (object itemChecked in checkedList_Dias.CheckedItems)
                    {
                        x.addFrecuencia(itemChecked.ToString().ToUpper());
                    }
                    // Repeticion
                    x.setRepeticion(getCanRepeticion());
                   principal.sobreescribirDocumento();
                    return true;
                }

                return false;
            });
          if (existe != null) {
              MessageBox.Show("Existe");
          }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
