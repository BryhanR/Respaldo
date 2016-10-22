using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{

    public class Server
    {
        private string nombre;
        public Server()
        {
            nombre = "";
            Console.Out.WriteLine("Logic creado");
        }

        public Server(string nom) {
            this.nombre = nom;
        }

        public string ToString() {
            return nombre;
        }

        public void guardar_Server(StreamWriter es)
        {
            //escribimos. 
            // Para saber que lo que viene es un server
            es.WriteLine("%%");
            // Nombre de la politica
            es.WriteLine(nombre);
            // Antes de guardar la frecuencia (los dias) 
            //vamos a guardar la cantidad de items con check
          

            es.Flush();
            //Cerramos
            es.Close();
            //Vaciamos
            //   textBox1.Text = "";
        }
    }


    public class Politica
    { 
       private  string nombre;
       private List<string> frecuencia;
       private DateTime fecha;
       private int repeticion;

       public Politica() {
           this.nombre = "";
           this.frecuencia = new List<string>();
           this.fecha = new DateTime();
           this.repeticion = 0;
       }

       public Politica(string nom, List<string> fre, DateTime fe, int repe ) {
           this.nombre = nom;
           this.frecuencia = fre;
           this.fecha = fe;
           this.repeticion = repe;
       }

       public string getNombre() {
           return nombre;
       }

       public List<string>  getListFrecuencia()
       {
           return frecuencia;
        }

       public DateTime getFecha() {
           return fecha;
       }

       public int getRepeticion() {
           return repeticion;
       }
       public void setNombre(String nom) {
           this.nombre = nom;
       }

       public void setFecha(DateTime f) {
           this.fecha = f;
       }

       public void setRepeticion(int r) {
           this.repeticion = r;
       }
       public void addFrecuencia(String fre) {
           frecuencia.Add(fre);
       }

       public void guardar_Politica(StreamWriter es) {
           //escribimos. 
           // Para saber que lo que viene es una politica
           es.WriteLine("&&");
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
           es.Close();
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
            tablespaces = null;
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

        public string getServer() {
            return nom_Server;
        }

        public void Guardar_Estrategia(Estrategia e)
        {

            //Fijar donde se guardara el archivo txt

            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt


            //escribimos. 
            escrito.WriteLineAsync("##");//PAra saber que es una estrategia
            escrito.WriteLine(e.nom_Server); // Nombre del servidor que lo creo
            escrito.WriteLine(e.nombre);
            escrito.WriteLine(e.tipoRes);
            escrito.WriteLine(e.modoRes);
            escrito.WriteLine(e.tablespaces.Count);
            e.tablespaces.ForEach(delegate (String tables)
            {
                escrito.WriteLine(tables);
            });
            escrito.WriteLine(e.plus[0]);
            escrito.WriteLine(e.plus[1]);
            escrito.WriteLine(e.plus[2]);
            escrito.Flush();
            //Cerramos
            escrito.Close();
            //Vaciamos
            //   textBox1.Text = "";
        }

        public void toString() {
            Console.WriteLine("Server: " + nom_Server);
            Console.WriteLine("Nombre: "+nombre);
            Console.WriteLine("tipo: " + tipoRes);
            Console.WriteLine("modo: " + modoRes);
        }
    }
       
    public class Tarea // son las asociaciones entre las politicas y estrategias que se estan ejecutando 
    { 
        
    }

}