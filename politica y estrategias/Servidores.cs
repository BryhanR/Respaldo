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
        private ventanaPrincipal principal;
        public Servidores(ventanaPrincipal p)
        {
            principal = p;
            InitializeComponent();
            this.CenterToScreen();
        }

        public Servidores(ventanaPrincipal p, Server s, bool editable)
        {

            InitializeComponent();
            this.CenterToScreen();
            principal = p;
            llenarCampos(s);
            nomBoton(editable);
            bloqueo_Desbloqueo_Panel(editable);
        }

        private void bloqueo_Desbloqueo_Panel(bool editable)
        {
            panel1.Enabled = editable;
        }
        private void nomBoton(bool editable)
        {
            if (editable)
                btn_Crear.Text = "Modificar";
            else
            {
                btn_Crear.Visible = false;
                btn_Cancelar.Text = "Cerrar";
            }

        }

        private void llenarCampos(Server s)
        {
            nombre_txt.Text = s.getNombre();
            txt_DataBaseLink.Text = s.getDBLink();
            txt_NomUsuario.Text = s.getUsuario();
            txt_Contraseña.Text = s.getContrasenia();
            txt_IP.Text = s.getIP();
            txt_Puerto.Text = s.getPuerto();
            txt_NombeBase.Text = s.getNomBase();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void GuardarServer()
        {
            

            StreamWriter escrito = new StreamWriter(Path.GetFullPath("Servidores.txt"), true); // escribe al final de Servidores.txt
            Server s = construirServer();
            s.guardar_Server(escrito);
            escrito.Close();
            principal.addServer(s);
            MessageBox.Show("Server " + s.getNombre() + " Creado Con Exito", "Success", MessageBoxButtons.OK);
        }

        private Server construirServer() {
            string nom = nombre_txt.Text.ToUpper();
            string datbalink = txt_DataBaseLink.Text.ToUpper();
            string usuario = txt_NomUsuario.Text.ToUpper();
            string contra = txt_Contraseña.Text.ToUpper();
            string ip = txt_IP.Text.ToUpper();
            string puerto = txt_Puerto.Text.ToUpper();
            string nomBase = txt_NombeBase.Text.ToUpper();
            return new Server(nom, datbalink, usuario, contra, ip, puerto, nomBase);
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {

            crear_o_Modificar();
         
            
        }
        private void crear_o_Modificar() {
         if(btn_Crear.Text == "Crear"){
            crearServer(); 
         }
         else{
                 modificarServer();
                 modificarPolitica();
                 modificarEstrategia();
                 modificarTareas();
                 MessageBox.Show("Modificacion realizada con exito...!", "Success", MessageBoxButtons.OK);
                 principal.llenarTablaServidores();
                 this.Close();
         }
          
        }

        private Politica modificarPolitica()
        {
            return principal.getPoliticasServer().Find(x =>
            {
                    x.setServer(nombre_txt.Text);
                    //Sobreescribimos todo el documento
                    principal.sobreescribirDocumento();
                    return true;
            });
        }

        private Estrategia modificarEstrategia()
        {
            return principal.getEstrategiasServer().Find(x =>
            {   
                    x.setNomServer(nombre_txt.Text);
                    // Sobreescribimos todo el documento.
                    principal.sobreescribirDocumento();
                    return true;
            });
        }
        private void modificarTareas(){
            principal.getTareaServer().Find(x =>
            {
                x.setNom_Server(nombre_txt.Text);
                // Sobreescribimos todo el documento.
                principal.sobreescribirDocumento();
                return true;
            });
        }

        private Server modificarServer()
        {
            return principal.getServidores().Find(x =>
            {
                if (x.getNombre() == principal.getServer())
                {
                    Server s = construirServer();
                    x.setNombre(s.getNombre());
                    x.setDBLink(s.getDBLink());   
                    x.setUsuario(s.getUsuario());
                    x.setContrasenia(s.getContrasenia());
                    x.setIP(s.getIP());
                    x.setPuerto(s.getPuerto());
                    x.setNomBase(s.getNomBase());
      
                    // Sobreescribimos todo el documento.
                    principal.sobreescribirDocumento();
                    return true;
                }

                return false;
            });
        }

    private void crearServer(){
      if(principal.getServidores().Exists(x=> x.getNombre().ToUpper() == nombre_txt.Text.ToUpper())){
         MessageBox.Show("Ya existe un servidor con ese nombre", "ERROR", MessageBoxButtons.OK);
      }
      else{
        GuardarServer();
        this.Close();
      }
    }
}
}
