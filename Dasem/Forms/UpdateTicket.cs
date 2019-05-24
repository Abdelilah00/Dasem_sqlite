using System;
using System.Data.SQLite;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;

namespace DasemBeniSanssen.Forms
{
    //Add delete Ticket

    public partial class UpdateTicket : Form
    {
        int id_ticket;
        Sqlite db = new Sqlite();
        
        public UpdateTicket()
        {
            InitializeComponent();
        }
        public void set_id_ticket(int x)
        {
            id_ticket = x;
        }
        private void UpdateTicket_Load(object sender, EventArgs e)
        {
            getProduitToCombox();
            getClientToCombox();
            autoCompiletMatricule();
            txb_id_ticket.Text = id_ticket.ToString();
            setTicket(id_ticket);
        }

        private void updateTicket(int x)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            string dt = date.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime date2 = DateTime.Parse(dateTimePicker2.Text);
            string dt2 = date2.ToString("yyyy-MM-dd HH:mm:ss"); 
            
            if(date > date2)
            {
                MessageBox.Show("la date d'entrée est plus grand grand que la date de sortie", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string query = "UPDATE Ticket SET Brut='" + txb_brut.Text + "'where idTicket=" + x;
            ExecuteQuery(query);

            query = "UPDATE Ticket SET IdProduit='" + db.getProduit_IdProduit(cb_produit.Text) + "' where idTicket=" + x;
            ExecuteQuery(query);

            if (!String.IsNullOrEmpty(cb_client.Text))
            {
                query = "UPDATE Ticket SET IdClient='" + db.getClient_IdClient(cb_client.Text) + "' where idTicket=" + x;
                ExecuteQuery(query);
            }
            else
            {
                query = "UPDATE Ticket SET IdClient = null where idTicket=" + x;
                ExecuteQuery(query);
            }
            

            query = "UPDATE Ticket SET IdCamion='" + db.getCamion_IdCamion(txb_matricule.Text) + "' where idTicket=" + x;
            ExecuteQuery(query);

            query = "UPDATE Ticket SET Credit=" +Convert.ToInt32(cb_credit.Checked) + " where idTicket=" + x;
            ExecuteQuery(query);

            query = "Update Ticket set Net = Brut - (select Tare From Camion where Ticket.IdCamion = Camion.IdCamion) where IdTicket="+x;
            ExecuteQuery(query);

            
            query = "UPDATE Ticket SET DateE='" + dt+ "' where idTicket=" + x;
            ExecuteQuery(query);

            
            query = "UPDATE Ticket SET DateS='" + dt2 + "' where idTicket=" + x;
            ExecuteQuery(query);
        }
        private void ExecuteQuery(string txtQuery)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private void autoCompiletMatricule()
        {
            txb_matricule.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txb_matricule.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collectionMatricule = new AutoCompleteStringCollection();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Camion";
            myReadear = sql_cmd.ExecuteReader();
            while (myReadear.Read())
            {
                string prod = myReadear.GetString(myReadear.GetOrdinal("Matricule"));
                collectionMatricule.Add(prod);
            }

            myReadear.Close();
            sql_con.Close();
            txb_matricule.AutoCompleteCustomSource = collectionMatricule;

        }
        private void getClientToCombox()
        {
            cb_client.Items.Clear();
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Client order by NomClient";
            myReadear = sql_cmd.ExecuteReader();
            string prod = "";
            cb_client.Items.Add(prod);
  
            while (myReadear.Read())
            {
                prod = myReadear.GetString(myReadear.GetOrdinal("NomClient"));
                cb_client.Items.Add(prod);
            }
            myReadear.Close();
            sql_con.Close();
        }
        private void getProduitToCombox()
        {
            cb_produit.Items.Clear();
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Produit order by NomProduit";
            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                string prod = myReadear.GetString(myReadear.GetOrdinal("NomProduit"));
                cb_produit.Items.Add(prod);
            }

            myReadear.Close();
            sql_con.Close();
        }

        private void setTicket(int x)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Ticket inner join Produit On Ticket.IdProduit=Produit.IdProduit " +
                " inner join Camion On Ticket.IdCamion=Camion.IdCamion" +
                " left join Client On Client.IdClient=Ticket.IdClient where IdTicket=" + x;

            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                string matricule = (string)myReadear["Matricule"];
                txb_matricule.Text = matricule.ToString();

                DateTime dateTime = (DateTime)myReadear["DateE"];
                dateTimePicker1.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime dateTime2 = (DateTime)myReadear["DateS"];
                dateTimePicker2.Text = dateTime2.ToString("yyyy-MM-dd HH:mm:ss");

                int brut = (int)myReadear["Brut"];
                txb_brut.Text = brut.ToString();

                string produit = (string)myReadear["NomProduit"];
                cb_produit.Text = produit.ToString();


                var client = myReadear["NomClient"];
                cb_client.Text = client.ToString();
                

                bool credit = (bool)myReadear["Credit"];
                cb_credit.Checked = credit;
            }

            myReadear.Close();
            sql_con.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            updateTicket(Convert.ToInt32(txb_id_ticket.Text));
            ((SearchJournale)this.Owner).LoadDataToDGVJournal();
            Close();
        }
        private void btn_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}