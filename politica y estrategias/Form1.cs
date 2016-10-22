using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Oracle.DataAccess.Client;
using System.Threading;
using Logic;

namespace politica_y_estrategias
{
    public partial class Form1 : Form
    {
        String ConexionOracle = "User id= System; Password=admin123; Data Source= XE;"; //////cambiar password
        Server g = new Server();
        OracleConnection con = new OracleConnection();
        private readonly SynchronizationContext syncC;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            con.ConnectionString = ConexionOracle;
            syncC = SynchronizationContext.Current; // obtiene el contexto de syncronizacion del hilo de ui
            
            ArchiveLog();
            panel1.Enabled=false;
            panel2.Enabled =false;
            panel4.Enabled = false;

            ResuperaServidorTxT();
            
            
        }

        public void ArchiveLog() {

            con.Open();
            String sql = "select  log_mode from v$database";
            OracleDataAdapter datos = new OracleDataAdapter(sql, con);
            DataSet data = new DataSet();
            datos.Fill(data);
            String modo = (String)data.Tables[0].Rows[0][0];
            label18.Text = modo;
            con.Close();
            if (modo == "NOARCHIVELOG") {
                label18.ForeColor = Color.Red;
                //activarArchiveLog();
                //this.ArchiveLog();

            }
            else label18.ForeColor = Color.Green;
                
            
        }

        public void activarArchiveLog() {
            con.Open();
            String sql = "alter system set log_archive_dest_1='location=C:archive_log_offline' scope=spfile; shutdown immediate; startup mount; alter database archivelog; alter database open;";
            OracleDataAdapter datos = new OracleDataAdapter(sql, con);
            con.Close();
           // ArchiveLog();
        }

        private void startFull()
        {
            DateTime d = DateTime.Now;
            while (DateTime.Now.ToString("g").CompareTo(d.ToString("g")) < 0) System.Threading.Thread.Sleep(1000);
           // respaldar();
        }

        


        private void respaldar()
        {
            Process proc = new Process();   
            proc.StartInfo.FileName = "rman.exe";   
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardInput = true; 
            proc.Start();
            StreamWriter writter = proc.StandardInput; 
            writter.WriteLine("connect target /;");
            writter.WriteLine( "run {backup database;}");
            writter.WriteLine("quit"); 

        }


        
        

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "Nodo3")
            {

                label15.Text = "Seleccione Servidor";
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel4.Enabled = false;

            }

            else {
                label15.Text = e.Node.Text;
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            
            }
          /*  else
            if (e.Node.Name == "Nodo4") {

                label15.Text = "Servidor 1";
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            }else
                 if (e.Node.Name == "Nodo5") {

                label15.Text = "Servidor 2";
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            }else
                      if (e.Node.Name == "Nodo6") {

                label15.Text = "Servidor 3";
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            }else
                     if (e.Node.Name == "Nodo7") {

                label15.Text = "Servidor 4";
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            }else 
                   if (e.Node.Name == "Nodo8") {

                label15.Text = "Servidor 5";
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
            }
                   else
                       if (e.Node.Name == "Nodo11")
                       {
                           label15.Text = "ALL SERVERS";
                           panel1.Enabled = true;
                           panel2.Enabled = true;
                           panel4.Enabled = true;
                       }
            */
          //  e.Node.Nodes.Add("Carro");
           //   treeView1.Nodes.Add("Carro");

        }
       

   
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
          
              /*  startFull();
                timer1.Enabled = true;
            //    timer1.Interval = (int)num_Tiempo.Value * 60000;
                timer1.Start();*/
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startFull();
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
            Estrategias m = new Estrategias();
            m.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Politicas p = new Politicas();
            p.Show();
        }

        //Lista de estrategias y politicas
        List<Estrategia> estrategias = new List<Estrategia>();
        List<Politica> politicas = new List<Politica>();
        List<Server> servidores = new List<Server>();
        public void ResuperaServidorTxT()
        {
              // Auxiliares para crear Server
            string nom_Server = "";
            
            //Auxiliares para crear Politica
            string nomP = "";
            List<string>frecuencia = new List<string>();
           DateTime fecha;
            int repeti = 0;

            //Auxiliares para crear Estrategia
            string nom = "";
            int tr = 0;
            int mr = 0;
            List<string> ts = new List<string>();
            int[] p = new int[3];
            p[0] = 0;
            p[1] = 0;

        

         StreamReader leido = File.OpenText(Path.GetFullPath("Servidores.txt"));
            //Variable que contendrá el archivo
            string contenido = null;
            //Leemos linea a linea hasta el final.
            while ((contenido = leido.ReadLine()) != null)
            {
                if (contenido == "%%") {
                    nom_Server = leido.ReadLine();
                    Server ser = new Server(nom_Server);
                    servidores.Add(ser);
                }
                if (contenido == "##")
                {
                    nom = leido.ReadLine();
                    tr = int.Parse(leido.ReadLine());
                    mr = int.Parse(leido.ReadLine());
                    int a = int.Parse(leido.ReadLine());
                    ts.Clear();
                    for (int i = 0; i < a; i++)
                    {
                        ts.Add(leido.ReadLine());
                    }
                   
                    p[0] = int.Parse(leido.ReadLine());
                    p[1] = int.Parse(leido.ReadLine());
                    p[2] = int.Parse(leido.ReadLine());
                    Estrategia est = new Estrategia(nom, tr, mr, ts, p);
                    estrategias.Add(est);
                }
                if (contenido == "&&") {
                    nomP = leido.ReadLine();
                    int a = int.Parse(leido.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        frecuencia.Add(leido.ReadLine());
                    }

                    int dia = int.Parse(leido.ReadLine());
                    int mes = int.Parse(leido.ReadLine());
                    int anno = int.Parse(leido.ReadLine());          
                    int hora= int.Parse(leido.ReadLine());
                    int min= int.Parse(leido.ReadLine());
                    int seg= int.Parse(leido.ReadLine());
                    fecha = new DateTime(anno,mes,dia,hora,min,seg);
                     repeti = int.Parse(leido.ReadLine());
                    Politica pol = new Politica(nomP, frecuencia, fecha, repeti);
                    politicas.Add(pol);
                }
            }
            leido.Close();
          //  cargarNomServidores();
          
        }
      
       /* public void bajarBase() {
            con.Open();
            String sql = "shutdown";
            OracleDataAdapter datos = new OracleDataAdapter(sql, con);
          
            sql=  "startup mount";
            datos = new OracleDataAdapter(sql, con);
           
            sql = "commit";
            datos = new OracleDataAdapter(sql, con);
           
            sql = "alter system checkpoint; ";
            datos = new OracleDataAdapter(sql, con);
           
            sql = "alter system switch logfile;";
            datos = new OracleDataAdapter(sql, con);

        }*/
        public string elementosBackup(int []p) { //Hace las sentencias para le backup de archivelog, controlfile e init(falta)
            string salida = "";
            if (p[0] == 1)
                salida += "backup archivelog all;";
            if (p[1] == 1)
                salida += "backup current controlfile;";
            if (p[2] == 1)
                salida +="";
            return salida;
        }
        //Recibe el nombe de la estrategia a buscar y devuelve las sentencias correspondientes
        public string restaurarEstrategia( string nom) {
            string comandos="";
            Estrategia e = estrategias.Find(x => x.getNombre()==nom);
            if (e != null) {

                switch (e.getTipoRes()) {
                    case 1:
                        if (e.getModoRes() == 1) {

                        }
                        else {
                            e.getTablespaces().ForEach(delegate (String table)
                            {
                                comandos += "backup tablespace " + table + " ;";
                            });
                        }
                        comandos+= elementosBackup(e.getPlus());
                       
                        break;
                    case 2:
                        comandos = " backup database ; " + elementosBackup(e.getPlus());
                        break;

                    case 3:
                        comandos = " backup database ; "+elementosBackup(e.getPlus());
                        
                        break;
                    default:
                        break;

                }
             
               
            }
            Console.Write(comandos);
            return comandos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ResuperaServidorTxT();
            estrategias.ForEach(delegate (Estrategia tables)
            {
                tables.toString();
            });
            restaurarEstrategia("estra02");
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // e.Node.Nodes.Add("Carro");
            Servidores s = new Servidores(this);
            s.Show();
            Console.WriteLine("Valor "+s.getNombre());
            //treeView1.TopNode.Nodes.Add("Ver");
        }

        private void cargarNomServidores() {
            servidores.ForEach(delegate(Server name)
            {
                treeView1.TopNode.Nodes.Add(name.ToString());
            });
        }

        public void addServer(Server s) {
            servidores.Add(s);
            servidores.ForEach(delegate(Server name)
            {
                Console.WriteLine(name.ToString());
            });
            if(servidores.Count!=0)
            treeView1.TopNode.Nodes.Add(servidores[servidores.Count-1].ToString());
          //  Console.WriteLine("Valores "+servidores.get.ToString());
        }
    }

}



