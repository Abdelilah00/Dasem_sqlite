using DasemBeniSanssen.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    public partial class Client : Form
    {
        Sqlite db = new Sqlite();
        string query;
        int id_target = -1;
        int type = -1;

        public int Id_target { get => id_target; set => id_target = value; }
        public int Type { get => type; set => type = value; }

        public Client()
        {
            InitializeComponent(); 
        }
        private void Client_Load(object sender, EventArgs e)
        {
            if (type == 0)
                btn_ok.Text = "Ajouter";
            else if (type == 1)
            {
                btn_ok.Text = "Update";
                setClient(id_target);
            }
            else
                Application.Exit();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                MessageBox.Show("veuillez remplir tous les champs obligatoires", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (type == 0)
            {   
                if (db.CountClient(txb_client.Text) == 0)
                {
                    query = "insert into Client(NomClient) Values('" + txb_client.Text + "')";
                    db.ExecuteQuery(query);
                    Clear();
                }
                else
                    MessageBox.Show("Le Client déja Exist");
            }
            else if (type == 1)
            {

                query = "Update Client set NomClient='" + txb_client.Text + "' where IdClient=" + Id_target;
                db.ExecuteQuery(query);
                
                /////Reload DataGrid View
                Clear();
            }
        }
       
        private void setClient(int x)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Client where IdClient=" + x;

            myReadear = sql_cmd.ExecuteReader();

            myReadear.Read();
            
            string nomClient = (string)myReadear["NomClient"];
            txb_client.Text = nomClient.ToString();     

            myReadear.Close();
            sql_con.Close();
        }
        private bool IsEmpty()
        {
            if (String.IsNullOrEmpty(txb_client.Text)) return true;
            return false;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Clear()
        {
            txb_client.Clear();
        }
    }
}
