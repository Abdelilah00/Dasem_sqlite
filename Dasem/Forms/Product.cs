using DasemBeniSanssen.Classes;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    public partial class Product : Form
    {
        Sqlite db = new Sqlite();
        string query;
        int id_target = -1;
        int type = -1;
        public Product()
        {
            InitializeComponent();
        }
        private void Product_Load(object sender, EventArgs e)
        {
            if (type == 0)
                btn_ok.Text = "Ajouter";
            else if (type == 1)
            {
                btn_ok.Text = "Update";
                setProduct(id_target);
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

            if (type == 0)
            {
                if (db.CountProduit(txb_produit.Text) == 0)
                {
                    query = "insert into Produit(NomProduit,Prix,Density) Values('" + txb_produit.Text + "','" + txb_prix.Text + "','" + txb_density.Text.Replace(',','.') + "')";
                    db.ExecuteQuery(query);
                    Clear();
                }
                else
                    MessageBox.Show("Le Produit déja Exist");
            }
            else if (type == 1)
            {
                query = "Update Produit set NomProduit='" + txb_produit.Text + "' where IdProduit=" + Id_target;
                db.ExecuteQuery(query);

                query = "Update Produit set Prix=" + txb_prix.Text + " where IdProduit=" + Id_target ;
                db.ExecuteQuery(query);

                query = "Update Produit set Density='" + txb_density.Text.Replace(",", ".") + "' where IdProduit=" + Id_target ;
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
            if (String.IsNullOrEmpty(txb_produit.Text)) return true;
            else if (String.IsNullOrEmpty(txb_prix.Text)) return true;
            else if (String.IsNullOrEmpty(txb_density.Text)) return true;    
            return false;
        }
        private void setProduct(int x)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            SQLiteDataReader myReadear=null;

            try
            {
                sql_con.Open();
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "select * from Produit where IdProduit=" + x;

                myReadear = sql_cmd.ExecuteReader();

                myReadear.Read();

                string nomProduit = (string)myReadear["NomProduit"];
                txb_produit.Text = nomProduit.ToString();

                int prix = (int)myReadear["Prix"];
                txb_prix.Text = prix.ToString();

                decimal density = (decimal)myReadear["Density"];
                txb_density.Text = density.ToString();
            }
            finally
            {
                myReadear.Close();
                sql_con.Close();
            }
            
        }
        private void Clear()
        {
            txb_produit.Clear();
            txb_density.Clear();
            txb_prix.Clear();
        }

        private void txb_prix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
