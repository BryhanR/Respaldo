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
        //-------- Variables ---------------------------------------
       // String ConexionOracle = "User id= system; Password=1234; Data Source= XE;"; //////cambiar password
        Server g = new Server();
        OracleConnection con = new OracleConnection();
        private readonly SynchronizationContext syncC;

        //----- Lista de estrategias politicas y servidores 
        List<Estrategia> estrategias = new List<Estrategia>();
        List<Politica> politicas = new List<Politica>();
        List<Server> servidores = new List<Server>();
        List<Tarea> tareas = new List<Tarea>();

        //-------- METODOS DEL FORM1 ---------//
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            con.ConnectionString = Globals.ConexionOracle;//ConexionOracle;
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
           

        private void respaldar(string backups)
        {
            //Console.WriteLine("Respaldo ......\n" + backups);
            Process proc = new Process();
            proc.StartInfo.FileName = "rman.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.Start();
            StreamWriter writter = proc.StandardInput;
            writter.WriteLine("connect target /;");
            writter.WriteLine("run {" + /*backups"*/"Backup database;" + "}");
            writter.WriteLine("quit");

        }

        public void ResuperaServidorTxT()
        {
              // Auxiliares para crear Server
            string nom_Server = "";
            string dbLink="";
            string usuario = "";
            string contrasenia = "";
            string ip = "";
            string puerto = "";
            string baseDatos = "";

            //Auxiliares para crear Politica
            string nom_P_Server = "";
            string nomP = "";
            List<string>frecuencia = new List<string>();
           DateTime fecha;
            int repeti = 0;

            //Auxiliares para crear Estrategia
            string nom_E_Server = "";
            string nom = "";
            int tr = 0;
            int mr = 0;
            List<string> ts = new List<string>();
            int[] p = new int[3];
            p[0] = 0;
            p[1] = 0;

            // Auxiliares para crear Tarea
            string nom_T_Server = "";
            string estra = "";
            string poli = "";
        

         StreamReader leido = File.OpenText(Path.GetFullPath("Servidores.txt"));
            //Variable que contendrá el archivo
            string contenido = null;
            //Leemos linea a linea hasta el final.
            while ((contenido = leido.ReadLine()) != null)
            {
                if (contenido == "%%") {
                    nom_Server = leido.ReadLine();
                    dbLink = leido.ReadLine();
                    usuario = leido.ReadLine();
                    contrasenia = leido.ReadLine();
                    ip = leido.ReadLine();
                    puerto = leido.ReadLine();
                    baseDatos = leido.ReadLine();
                    Server ser = new Server(nom_Server,dbLink,usuario,contrasenia,ip,puerto,baseDatos);
                   servidores.Add(ser);
                }
                if (contenido == "##")
                {
                    nom_E_Server = leido.ReadLine();
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
                    Estrategia est = new Estrategia(nom_E_Server,nom, tr, mr, ts, p);
                    estrategias.Add(est);
                    
                }
                if (contenido == "&&") {
                    nom_P_Server = leido.ReadLine();
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
                     Politica pol = new Politica(nom_P_Server, nomP, frecuencia, fecha, repeti);
                    politicas.Add(pol);
                }

                if (contenido == "@@") {
                    nom_T_Server = leido.ReadLine();
                    estra = leido.ReadLine();
                    poli = leido.ReadLine();

                    Tarea tarea = new Tarea(nom_T_Server, estra, poli);
                    tareas.Add(tarea);
                }
            }
            leido.Close();
          //  cargarNomServidores();
          
        }


        public string elementosBackup(int[] p){ //Hace las sentencias para le backup de archivelog, controlfile e init(falta)
            string salida = "";
            if (p[0] == 1)
                salida += "backup archivelog all;\n";
            if (p[1] == 1)
                salida += "backup current controlfile;\n";
            if (p[2] == 1)
                salida += "";
            return salida;
        }

        private string modoRespaldo(int modo, List<string> tablespaces){ // Modo de respaldo (incremental, total)
            string comandos = "";
            if (modo == 1)      // FALTA son respaldos incrementales
            {

            }
            else
            {
                tablespaces.ForEach(delegate(String table)
                {
                    comandos += "backup tablespace " + table + ";\n";
                });
            }
            return comandos;
        }

        //Recibe el nombe de la estrategia a buscar y devuelve las sentencias correspondientes
        public string restaurarEstrategia(string nom)
        {
            string comandos = "";
            Estrategia e = estrategias.Find(x => x.getNombre() == nom);
            if (e != null)
            {

                switch (e.getTipoRes())
                { // Tipo de respaldo (inconsistente = 1, consistente = 2, fullbackup = 3)
                    case 1:
                        comandos += modoRespaldo(e.getModoRes(), e.getTablespaces());
                        comandos += elementosBackup(e.getPlus());
                        break;

                    case 2:
                        comandos = " backup database; \n" + elementosBackup(e.getPlus());
                        break;

                    case 3:
                        comandos = " backup database; \n" + elementosBackup(e.getPlus());

                        break;
                    default:
                        break;

                }


            }
            Console.Write(comandos);
            return comandos;
        }


        //Creación del databaseLink
        private void crearDatabaseLink(string nomS) {
        
            Server s = servidores.Find(x => x.getNombre() == nomS);

            string DBLink = "CREATE DATABASE LINK" + s.getDBLink() + " CONNECT TO "+s.getUsuario()+" IDENTIFIED BY";
            DBLink += s.getContrasenia() +" USING '(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST =" + s.getIP()+")(PORT =";
            DBLink += s.getPuerto() + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME =" +s.getNomBase()+")))';";

            //NOTA: La sentencia del databaselink si sirve pero no se si desde aqui se ejecuta bien xq no puedo 
            //ver la respuesta de la base
          /*  con.Open();
            string sql = DBLink;
            OracleDataAdapter datos = new OracleDataAdapter(sql, con);
            con.Close();*/

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

       
        public List<Estrategia> getEstrategiasServer()
        {
            List<Estrategia> estra = new List<Estrategia>();
            estrategias.ForEach(delegate(Estrategia e)
            {
                if (e.getServer() == getServer())
                {
                    estra.Add(e);
                }
            });
            return estra;
        }

        public List<Politica> getPoliticasServer()
        {
            List<Politica> poli = new List<Politica>();
            politicas.ForEach(delegate(Politica p)
            {
                if (p.getServer() == getServer())
                {
                    poli.Add(p);
                }
            });
            return poli;
        }

        private void llenarCheckedList_Estretegias()
        {
            List<Estrategia> le = getEstrategiasServer();
            checkedList_Estrategias.Items.Clear();

            le.ForEach(delegate(Estrategia e)
            {
                checkedList_Estrategias.Items.Add(e.getNombre());
            });

            checkedList_Estrategias.HorizontalScrollbar = true;

        }

        private void llenarCheckedList_Politicas()
        {
            List<Politica> lp = getPoliticasServer();
            checkedList_Politicas.Items.Clear();

            lp.ForEach(delegate(Politica p)
            {
                checkedList_Politicas.Items.Add(p.getNombre());
            });

            checkedList_Politicas.HorizontalScrollbar = true;

        }

        public string getServer()
        {
            return label15.Text.Substring(10, label15.Text.Count() - 10);
        }

        public void add_Check_Estrategia(string nom_Estrategia)
        {
            checkedList_Estrategias.Items.Add(nom_Estrategia);
        }

        public void add_Check_Politica(string nom_Politica)
        {
            checkedList_Politicas.Items.Add(nom_Politica);
        }

        public void addEstrategias(Estrategia e)
        {
            estrategias.Add(e);
        }

        public void addPolitica(Politica p)
        {
            politicas.Add(p);
        }

        private void guardar_Tarea() {
            Tarea t = new Tarea(getServer(),nom_Estra.Text,nom_Poli.Text);
            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            t.guardar_Tarea(escrito);
            tareas.Add(t);
        }

        private void start()
        {
            DateTime d = politicas[0].getFecha();
            Task.Factory.StartNew((t) => { TransitionClass tc = t as TransitionClass; startThread(tc); }, new TransitionClass(d, restaurarEstrategia(nom_Estra.Text)));
            
            
            //respaldar(restaurarEstrategia(nom_Estra.Text));
        }

        private void startThread(TransitionClass t)
        {
            while (DateTime.Now.ToString("g").CompareTo(t.date.ToString("g")) < 0) { Thread.Sleep(1000);
            Console.WriteLine("Esperando");
            }
              respaldar(restaurarEstrategia(t.text));
        }
        //------ EVENTOS DEL FORM1 ------//

        private void button3_Click(object sender, EventArgs e)
        {
            Servidores s = new Servidores(this);
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar_Tarea();
            start();
            estado.Text = "Respaldo Finalizado";
           
           // respaldar(restaurarEstrategia(nom_Estra.Text)); // Cambiar
           // ResuperaServidorTxT();
           /* estrategias.ForEach(delegate(Estrategia tables)
            {
                tables.toString();
            });*/
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Estrategias m = new Estrategias(this);
            m.Show();

           /* Console.WriteLine(label15.Text.Substring(0,9));
            Console.WriteLine(label15.Text.Count());
            
             Console.WriteLine();*/
        }

   

        private void button2_Click_1(object sender, EventArgs e)
        {
            Politicas p = new Politicas(this);
            p.Show();
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


        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarNomServidores();
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

                //---- Se vacia el checkList de Estretagias
                checkedList_Estrategias.Items.Clear();
                checkedList_Politicas.Items.Clear();

            }

            else
            {
                label15.Text = "Servidor: "+e.Node.Text;
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel4.Enabled = true;
                 //-- Se colocan las estretegias de un server especifico ---
                llenarCheckedList_Estretegias();
                llenarCheckedList_Politicas();

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

        private void checkedList_Estrategias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            if (checkedList_Estrategias.GetItemChecked(e.Index) == false)
            {
                nom_Estra.Text = checkedList_Estrategias.Items[e.Index].ToString();
            }
            else {
                nom_Estra.Text = "";
            }
           
        }

        private void checkedList_Politicas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedList_Politicas.GetItemChecked(e.Index) == false)
            {
                nom_Poli.Text = checkedList_Politicas.Items[e.Index].ToString();
            }
            else
            {
                nom_Poli.Text = "";
            }
        }


    }

}



