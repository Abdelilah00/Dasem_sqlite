using DasemBeniSanssen.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    public partial class Camion : Form
    {
        Sqlite db = new Sqlite();
        string query;
        int id_target = -1;
        int type = -1;

        public Camion()
        {
            InitializeComponent();          
        }
        private void Camion_Load(object sender, EventArgs e)
        {
            if (type == 0)
                btn_ok.Text = "Ajouter";
            else if (type == 1)
            {
                btn_ok.Text = "Update";
                setCamion(Id_target);
            }
            else
                Application.Exit();
        }
        public int Id_target { get => id_target; set => id_target = value; }
        public int Type { get => type; set => type = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
            {
                MessageBox.Show("veuillez remplir tous les champs obligatoires", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!isMatricule())
            {
                MessageBox.Show("Le matricule est incorrect 'numero + Capital Alpha + numero'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }

            if (type == 0)
            {
                if (db.CountMatricule(txb_matricule.Text) == 0)
                {
                    query = "insert into Camion(Matricule,Tare) Values('" + txb_matricule.Text + "','" + txb_tare.Text + "')";
                    db.ExecuteQuery(query);
                    Clear();
                }
                else
                    MessageBox.Show("Le Matricule déja Exist");
            }
            else if (type == 1)
            {
                query = "Update Camion set Matricule='" + txb_matricule.Text + "' where IdCamion="+ Id_target;
                db.ExecuteQuery(query);

                query = "Update Camion set Tare=" + txb_tare.Text + " where IdCamion="+ Id_target;
                db.ExecuteQuery(query);

                /////Reload DataGrid View
                Clear();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();

        }
        private bool IsEmpty()
        {
            if (String.IsNullOrEmpty(txb_matricule.Text)) return true;
            else if (String.IsNullOrEmpty(txb_tare.Text)) return true;
            return false;
        }
        private void setCamion(int x)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
           
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Camion where idCamion =" + x;

            myReadear = sql_cmd.ExecuteReader();

            myReadear.Read();
            string matricule = (string)myReadear["Matricule"];
            txb_matricule.Text = matricule.ToString();

            int tare = (int)myReadear["Tare"];
            txb_tare.Text = tare.ToString();

            myReadear.Close();
            sql_con.Close();
        }
        private void Clear()
        {
            txb_matricule.Clear();
            txb_tare.Clear();
        }
        private bool isMatricule()
        {
            Regex regex = new Regex("[0-9]+ [A-Z]{1} [0-9]+");
            Match match = regex.Match(txb_matricule.Text);

            if (match.Success) return true;
            else return false;
        }

        private void txb_tare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
