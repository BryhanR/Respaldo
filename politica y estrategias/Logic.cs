using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{

    public static class Globals
    {
        public static String ConexionOracle = "User id= system; Password=admin123; Data Source= XE;"; //////cambiar password
    }


    public class TransitionClass
    {
        public DateTime date;
        public string text;
        public TransitionClass(DateTime d, string txt)
        {
            date = d;
            text = txt;
        }
    }


    public class Server
    {
        private string nombre;
        string databaseLink;
        string usuario;
        string contrasenia;
        string ip;
        string puerto;
        string baseDatos;

        public Server()
        {
            nombre = "";
            databaseLink = "";
            usuario = "";
            contrasenia = "";
            ip = "";
            puerto = "";
            baseDatos = "";
            Console.Out.WriteLine("Logic creado");
        }

        public Server(string nom,string dbLink,string u, string c, string numip,string p, string nbase) {
            this.nombre = nom;
            this.databaseLink = dbLink;
            this.usuario = u;
            this.contrasenia = c;
            this.ip = numip;
            this.puerto = p;
            this.baseDatos = nbase;
        }

        public string getNombre() {
            return this.nombre;
        }
        public string getDBLink()
        {
            return this.databaseLink;
        }
        public string getUsuario()
        {
            return this.usuario;
        }
        public string getContrasenia()
        {
            return this.contrasenia;
        }
        public string getIP()
        {
            return this.ip;
        }
        public string getPuerto()
        {
            return this.puerto;
        }
        public string getNomBase()
        {
            return this.baseDatos;
        }
        
        public void setNombre(string nom)
        {
            this.nombre = nom;
        }
        public void setDBLink(string dbl)
        {
            this.databaseLink = dbl;
        }
        public void setUsuario(string u)
        {
           this.usuario = u;
        }
        public void setContrasenia(string con)
        {
            this.contrasenia = con;
        }
        public void setIP(string newIp)
        {
            this.ip = newIp;
        }
        public void setPuerto(string p)
        {
            this.puerto = p;
        }
        public void setNomBase (string nomB)
        {
            this.baseDatos = nomB;
        }


        public string ToString() {
            return nombre;
        }

        public void guardar_Server(StreamWriter es)
        {
            // Para saber que lo que viene es un server
            es.WriteLine("%%");
      
            es.WriteLine(nombre);
            es.WriteLine(databaseLink);
            es.WriteLine(usuario);
            es.WriteLine(contrasenia);
            es.WriteLine(ip);
            es.WriteLine(puerto);
            es.WriteLine(baseDatos);



            es.Flush();
            //Cerramos
           // es.Close();
           
        }
    }


    public class Politica
    {
        private string nom_Server;
        private string nombre;
        private List<string> frecuencia;
        private DateTime fecha;
        private int repeticion;

        public Politica()
        {
            nom_Server = "";
            this.nombre = "";
            this.frecuencia = new List<string>();
            this.fecha = new DateTime();
            this.repeticion = 0;
        }

        public Politica(string ns, string nom, List<string> fre, DateTime fe, int repe)
        {
            this.nom_Server = ns;
            this.nombre = nom;
            this.frecuencia = fre;
            this.fecha = fe;
            this.repeticion = repe;
        }

        public string getNombre()
        {
            return nombre;
        }

        public List<string> getListFrecuencia()
        {
            return frecuencia;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public int getRepeticion()
        {
            return repeticion;
        }

        public string getServer()
        {
            return nom_Server;
        }

        public void setNombre(String nom)
        {
            this.nombre = nom;
        }

        public void setFecha(DateTime f)
        {
            this.fecha = f;
        }

        public void setRepeticion(int r)
        {
            this.repeticion = r;
        }

        public void setServer(string ns)
        {
            this.nom_Server = ns;
        }
        public void setFrecuencia(List<string> newFrecuencia) {
            this.frecuencia = newFrecuencia;
        }
        public void addFrecuencia(String fre)
        {
            frecuencia.Add(fre);
        }

        public void guardar_Politica(StreamWriter es)
        {
            //escribimos. 
            // Para saber que lo que viene es una politica
            es.WriteLine("&&");
            // Nombre del servidor
            es.WriteLine(nom_Server);
            // Nombre de la politica
            es.WriteLine(nombre);
            // Antes de guardar la frecuencia (los dias) 
            //vamos a guardar la cantidad de items con check
            es.WriteLine(frecuencia.Count);
            // La frecuencia
            foreach (string itemChecked in frecuencia)
            {
                es.WriteLine(itemChecked.ToString());
            }
            // Dia
            es.WriteLine(fecha.Day);
            // Mes
            es.WriteLine(fecha.Month);
            // Año
            es.WriteLine(fecha.Year);
            // Hora
            es.WriteLine(fecha.Hour);
            // Minutos
            es.WriteLine(fecha.Minute);
            // Segundos
            es.WriteLine(fecha.Second);

            // Repeticion
            es.WriteLine(repeticion);

            es.Flush();

            //Cerramos
           // es.Close();
            //Vaciamos
            //   textBox1.Text = "";
        }
    }
    public class Estrategia
    {
        string nom_Server;
        string nombre;
        int tipoRes;
        int modoRes;
        List<string> tablespaces;
        int[] plus;

        public Estrategia(string ns, string n, int tr, int mr, List<string> t, int[] p)
        {
            nom_Server = ns;
            nombre = n;
            tipoRes = tr;
            modoRes = mr;
            tablespaces = t;
            plus = p;
        }

        public Estrategia()
        {
            nom_Server = "";
            nombre = "";
            tipoRes = 0;
            modoRes = 0;
            tablespaces = new List<string>();
            plus = null;
        }

        public string getNombre()
        {
            return nombre;
        }
        public int getTipoRes()
        {
            return tipoRes;
        }
        public int getModoRes()
        {
            return modoRes;
        }
        public List<string> getTablespaces()
        {
            return tablespaces;
        }
        public int[] getPlus()
        {
            return plus;
        }
        public void addTablespace(String t)
        {
            tablespaces.Add(t);
        }

        public string getServer()
        {
            return nom_Server;
        }
        public void setNombre(string nom){
          nombre = nom;
        }
        public void setNomServer(string s) {
            nom_Server = s;
        }
        public void setTipoRes(int re) {
            tipoRes = re;
        }
        public void setModoRes(int m)
        {
             modoRes = m;
        }
     
        public void setPlus(int [] p)
        {
            plus = p;
        }
        public void setTablespaces(List<string> newTablespaces) { 
            tablespaces = newTablespaces;
        }
        public void Guardar_Estrategia(StreamWriter escrito)
        {

            //escribimos. 
            escrito.WriteLineAsync("##");//PAra saber que es una estrategia
            escrito.WriteLine(nom_Server); // Nombre del servidor que lo creo
            escrito.WriteLine(nombre);
            escrito.WriteLine(tipoRes);
            escrito.WriteLine(modoRes);
            escrito.WriteLine(tablespaces.Count);
            tablespaces.ForEach(delegate(String tables)
            {
                escrito.WriteLine(tables);
            });
            escrito.WriteLine(plus[0]);
            escrito.WriteLine(plus[1]);
            escrito.WriteLine(plus[2]);
            escrito.Flush();
            //Cerramos
           
        }

        public void toString()
        {
            Console.WriteLine("Server: " + nom_Server);
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("tipo: " + tipoRes);
            Console.WriteLine("modo: " + modoRes);
        }
    }

    public class Tarea
    {
        private string nom_Server;
        private string estrategia;
        private string politica;
        private int status;

        public Tarea(string ns, string e, string p, int st) {
            this.nom_Server = ns;
            this.estrategia = e;
            this.politica = p;
            this.status = st;
        }

        public Tarea()
        {
            this.nom_Server = "";
            this.estrategia = "";
            this.politica = "";
            this.status = 0;
        }

        public string getNom_Estrategia(){
            return estrategia;
        }
        public string getNom_Politica()
        {
            return politica;
        }
        public string getNom_Server()
        {
            return nom_Server;
        }
        public int getStatus() {
            return status;
        }
        public void setStatus(int st) {
            status = st;
        }
        public void setNom_Estrategia(string e)
        {
            estrategia = e;
        }
        public void setNom_Politica(string p)
        {
            politica = p;
        }
        public void setNom_Server(string s)
        {
            nom_Server = s;
        }

        public void guardar_Tarea(StreamWriter es)
        {
            //escribimos. 
            // Para saber que lo que viene es una Tarea
            es.WriteLine("@@");
            // Nombre del servidor
            es.WriteLine(nom_Server);
            // Nombre de la Estrategia
            es.WriteLine(estrategia);
            // 'Nombre de la politica
            es.WriteLine(politica);
            // Guarda el status 0 no activo, 1 activo
            es.WriteLine(status);

            es.Flush();
            //Cerramos
           // es.Close();
        }
    }

}