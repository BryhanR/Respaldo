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


namespace politica_y_estrategias
{
    public partial class Estrategias : Form
    {
        String ConexionOracle = "User id= System; Password=admin123; Data Source= XE;"; //////cambiar password
        //Server g = new Server();
        OracleConnection con = new OracleConnection();

        String nom_Server = "";

        public Estrategias(string nom)
        {
            nom_Server = nom;
            con.ConnectionString = ConexionOracle;
            InitializeComponent();
            this.CenterToScreen();
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

            nombre = this.nom_estra.Text;


            foreach (object itemChecked in checkedList_Tablespaces.CheckedItems)
            {
                tablespaces.Add(itemChecked.ToString());
            }

            if (check_Archive.Checked)
                plus[1] = 1;
            if (check_ControlF.Checked)
                plus[1] = 1;
            if (checkBox2.Checked)
                plus[0] = 1;
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


            Estrategia estrategia = new Estrategia(nom_Server,nombre, tipoRes, modoRes, tablespaces, plus);
            estrategia.Guardar_Estrategia(estrategia);
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

        private void Estrategias_Load(object sender, EventArgs e)
        {
          
        }

        private void btn_CrearEstra_Click(object sender, EventArgs e)
        {
            Guardar_Estrategia();
            Console.WriteLine("Estrategia creada");
          //  Recupear_Estrategia();
            Console.WriteLine("Estrategia recuperda");
        }
    }
}
