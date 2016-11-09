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
       
        public Estrategias_Politicas(ventanaPrincipal p, Estrategia es, Politica po, bool editable)
        {
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
            principal = p;
            llenarCampos(es,po);
            bloqueo_Desbloqueo_Panel(editable);
            nomBoton(editable);
        }

        private void nomBoton(bool editable) {
            if (editable)
            {
                btn_CrearEstra.Text = "Modificar";
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                btn_Cancelar.Text = "Cerrar";
            }
            else
            {
                btn_CrearEstra.Visible = false;
                btn_Cancelar.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
               
            }
        }

        private void bloqueo_Desbloqueo_Panel(bool editable) {
            panel1.Enabled = editable;
            panel2.Enabled = editable;    
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
            label1.Visible = false;
            label7.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
        }

        //------ METODOS---------//
        private Estrategia construirEstrategia() {
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

            return estrategia;
        }
        private void Guardar_Estrategia()
        {
            Estrategia estrategia = construirEstrategia();
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            estrategia.Guardar_Estrategia(escrito);
            escrito.Close();
            principal.addEstrategias(estrategia);
            principal.add_Check_Estrategia(estrategia.getNombre());
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
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                fullBackup(true, false);
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
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
        private Politica construirPolitica() {
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
            return p;
        }
        private void Guardar_Politica()
        {
            //Abrimos el archivo txt
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            Politica p = construirPolitica();
            principal.addPolitica(p);
            p.guardar_Politica(escrito);
            escrito.Close();   
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


        private void Guardar_Tarea(){
            Tarea t = new Tarea(principal.getServer(), nom_estra.Text, nom_Politica.Text,1);
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"),true); // escribe al final de Servidores.txt
            t.guardar_Tarea(escrito);
            principal.guardar_Tarea(t);
            escrito.Close();
        }

        private void btn_CrearEstra_Click_2(object sender, EventArgs e)
        {
            if (validar())
            {
                crear_o_Modificar();
                this.Close();
            }
            else
                MessageBox.Show("Pro favor llenar los espacios que aparecen con * !", "Error", MessageBoxButtons.OK);
        }

        private bool validar() {
            bool b = false; bool d = false;  bool final = true;
            if (radioButton1.Checked == true) {
                if (radioButton5.Checked == false && radioButton6.Checked == false) {
                    final = false;
                    label8.Visible = true;
                }
                else
                    label8.Visible = false;

            }
            if (radioButton2.Checked == true) {
                label8.Visible = false;
            }
                if (check_Tablespaces.Checked == true) {
                    foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
                    {
                        b = true;
                    }
                    if (b == false)
                    {
                        label1.Visible = true;
                        final = false;
                    }
                }
            
            foreach (object itemChecked in checkedList_Dias.CheckedItems)
            {
                d = true;
            }
            if (d == false)
            {
                final = false;
                label9.Visible = true;
            }
            else
                label9.Visible = false;
            if (radioB_30.Checked == false && radioB_60.Checked == false && radioB_120.Checked == false && radioB_Otro.Checked == false)
            {
                final = false;
                label7.Visible = true;
            }
            else {
                label7.Visible = false;
            }
            if (radioB_Otro.Checked == true && num_Tiempo.Value == 0)
                label5.Visible = true;
            else
                label5.Visible = false;
            return final;
        }
        

        private void crear_o_Modificar() {
            Politica existeP = modificarPolitica();
            Estrategia existeE = modificarEstrategia();
          if (existeP != null && existeE!= null)
          {
              MessageBox.Show("Modificacion realizada con exito...!", "Success", MessageBoxButtons.OK);
          }
          else {
              Guardar_Estrategia();
              Guardar_Politica();
              Guardar_Tarea();
              MessageBox.Show("Creacion realizada con exito....!", "Success", MessageBoxButtons.OK);
          }
        }

        private Politica modificarPolitica() {
           return  principal.getPoliticasServer().Find(x =>
            {
                if (x.getNombre() == nom_Politica.Text)
                {
                    Politica p = construirPolitica();
                    x.setFecha(p.getFecha());
                    x.setFrecuencia(p.getListFrecuencia());
                    x.setRepeticion(p.getRepeticion());
                    //Sobreescribimos todo el documento
                    principal.sobreescribirDocumento();
                    return true;
                }

                return false;
            });
        }

        private Estrategia modificarEstrategia() {
            return principal.getEstrategiasServer().Find(x =>
            {
                if (x.getNombre() == nom_estra.Text)
                {
                    Estrategia e = construirEstrategia();
                    x.setModoRes(e.getModoRes());
                    x.setTablespaces(e.getTablespaces());
                    x.setPlus(e.getPlus());
                    x.setTipoRes(e.getTipoRes());
                    // Sobreescribimos todo el documento.
                    principal.sobreescribirDocumento();
                    return true;
                }

                return false;
            });
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioB_30_CheckedChanged(object sender, EventArgs e)
        {
            num_Tiempo.Enabled = false;
            label7.Visible = false;
        }

        private void radioB_60_CheckedChanged(object sender, EventArgs e)
        {
            num_Tiempo.Enabled = false;
            label7.Visible = false;
        }

        private void radioB_120_CheckedChanged(object sender, EventArgs e)
        {
            num_Tiempo.Enabled = false;
            label7.Visible = false;
        }

        private void radioB_Otro_CheckedChanged(object sender, EventArgs e)
        {
            num_Tiempo.Enabled = true;
            label7.Visible = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Las sentencias RMAN ejecutadas para esta "+
                "estrategia son:"+"\n\n"+"run {\n"+ rmanEstrategia()+"}", "RMAN de la Estrategia" ,MessageBoxButtons.OK);

           

        }


        public string elementosBackup()
        { //Hace las sentencias para le backup de archivelog, controlfile e init(falta)
            string salida = "";
            if (check_Archive.Checked ==true)
                salida += "backup archivelog all;\n";
            if (check_ControlF.Checked == true)
                salida += "backup current controlfile;\n";
            if (check_IniitF.Checked == true)
                salida += "";
            return salida;
        }

        private string modoRespaldo()
        { // Modo de respaldo (incremental, total)
            string comandos = "";
            if (radioButton6.Checked == true)      // FALTA son respaldos incrementales
            {
                foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
                {
                    comandos += "backup incremental level 1 tablespace " + itemChecked.ToString() + ";\n";
                }
            }
            else
            {
                foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
              {
                    
                    comandos += "backup incremental level 0 tablespace " + itemChecked.ToString() + ";\n";
                   
                }
               
            }
            return comandos;
        }

        //Recibe el nombe de la estrategia a buscar y devuelve las sentencias correspondientes
        public string rmanEstrategia()
        { // Tipo de respaldo (inconsistente = 1, consistente = 2, fullbackup = 3)

            string comandos = "";

            if (radioButton1.Checked == true) {
                comandos += modoRespaldo();
                comandos += elementosBackup();
            }
            if (radioButton2.Checked==true) {
                comandos = modoRespaldo() + elementosBackup();
                }

            if (radioButton3.Checked==true) {
                comandos = "backup database; \n" + elementosBackup();
            }
                            
                       
            Console.Write(comandos);
            return comandos;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start(@"C:\oraclexe\app\oracle\fast_recovery_area\XE\ARCHIVELOG");
            DialogResult result = MessageBox.Show("La ruta de acceso a los logs es: " +
                "C:/oraclexe/app/oracle/fast_recovery_area/XE/ARCHIVELOG", "Ruta de Logs", MessageBoxButtons.OK);


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void checkedList_Dias_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void num_Tiempo_ValueChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void checkedList_Tablespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
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
