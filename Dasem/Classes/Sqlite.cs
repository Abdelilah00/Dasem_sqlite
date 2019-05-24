using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DasemBeniSanssen.Classes
{
    class Sqlite
    {
        string query;

        public bool LoginUserSecssfuuly(string user,string passeWord)
        {
            string query = "select * from Login where User='" + user + "' and Password='" + passeWord + "' and Admin=0";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows == 1 ? true : false;
        }
        public bool LoginAdminSecssfuuly(string user, string passeWord)
        {
            string query = "select * from Login where User='"+user+"' and Password='"+passeWord+"' and Admin=1";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows == 1 ? true : false;
        }
        public int getMaxIdIncr()
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            int currId=0;


            sql_cmd.CommandText = "select max(IdTicket) as CurrIdTicket from Ticket";
            myReadear = sql_cmd.ExecuteReader();


            if (CountTickets() > 0)
            {
                while (myReadear.Read())
                {
                    currId = myReadear.GetInt32(myReadear.GetOrdinal("CurrIdTicket"));
                }
            }

            myReadear.Close();

            return ++currId;
        }
        public int getMaxId()
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            int currId = 0;


            sql_cmd.CommandText = "select max(IdTicket) as CurrIdTicket from Ticket";
            myReadear = sql_cmd.ExecuteReader();


            if (CountTickets() > 0)
            {
                while (myReadear.Read())
                {
                    currId = myReadear.GetInt32(myReadear.GetOrdinal("CurrIdTicket"));
                }
            }

            myReadear.Close();

            return currId;
        }
        ////////////////////////////////////////////
        public int CountMatricule(string Matricule)
        {
            query = "select * from Camion where Matricule='" + Matricule + "'";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows;
        }
        public int CountProduit(string NomProduit)
        {
            query = "select * from Produit where NomProduit='" + NomProduit + "'";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows;
        }
        public int CountClient(string NomClient)
        {
            query = "select * from Client where NomClient='" + NomClient + "'";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows;
        }
        public int CountIdTicket(int IdTicket)
        {
            string query = "select * from Ticket where IdTicket='" + IdTicket + "'";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows;
        }
        public int CountTickets()
        {
            string query = "select * from Ticket";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows;
        }

        ////////////////////////////////////////////
        public int getProduit_IdProduit(string NomProduit)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select IdProduit from Produit where NomProduit='" + NomProduit + "'";
            myReadear = sql_cmd.ExecuteReader();
            myReadear.Read();

            int idProd = Convert.ToInt32(myReadear["IdProduit"]);

            myReadear.Close();
            sql_con.Close();

            return idProd;
        }
        public int getClient_IdClient(string NomClient)
        {

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select IdClient from Client where NomClient='" + NomClient + "'";
            myReadear = sql_cmd.ExecuteReader();
            myReadear.Read();

            int IdClt = Convert.ToInt32(myReadear["IdClient"]);

            myReadear.Close();
            sql_con.Close();

            return IdClt;
        }
        public int getCamion_IdCamion(string NomMatricule)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select IdCamion from Camion where Matricule='" + NomMatricule + "'";
            myReadear = sql_cmd.ExecuteReader();
            myReadear.Read();

            int IdCamio = Convert.ToInt32(myReadear["IdCamion"]);

            myReadear.Close();
            sql_con.Close();

            return IdCamio;
        }

        ////////////////////////////////////////////
        public void deleteRowProduit(string IdProduit)
        {
            if (produidUsed(IdProduit))
            {
                MessageBox.Show("the'is a Used Produit can't be deleted");
            }
            else
            {
                if (MessageBox.Show("Vouler Vous Vraiment Suprrimer Cette ligne", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Delete From Produit where IdProduit=" + IdProduit;
                    ExecuteQuery(query);
                }
            }
        }
        public void deleteRowClient(string IdClient)
        {
            if (ClientUsed(IdClient))
            {
                MessageBox.Show("the'is a Used Client can't be deleted");
            }
            else
            {
                if (MessageBox.Show("Vouler Vous Vraiment Suprrimer Cette ligne", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Delete From Client where IdClient=" + IdClient;
                    ExecuteQuery(query);
                }
            }
        }
        public void deleteRowCamion(string IdCamion)
        {
            if (CamionUsed(IdCamion))
            {
                MessageBox.Show("the'is a Used Matricule can't be deleted");
            }
            else
            {
                if (MessageBox.Show("Vouler Vous Vraiment Suprrimer Cette ligne", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Delete From Camion where IdCamion='" + IdCamion+ "'";
                    ExecuteQuery(query);
                }
            }
        }
        public void deleteRowTicket(string IdTicket)
        {
            if (CountIdTicket(Convert.ToInt32(IdTicket)) == 0)
            {
                MessageBox.Show("N° Ticket pas valide");
            }
            else
            {
                if (MessageBox.Show("Vouler Vous Vraiment Suprrimer Cette ligne", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "Delete From Ticket where IdTicket='" + IdTicket + "'";
                    ExecuteQuery(query);
                }
            }
        }
        ///////////////////////////////////////////////
        public bool produidUsed(string IdProduit)
        {
            query = "select * from Ticket where IdProduit=" + IdProduit;
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows>0 ? true:false;
        }
        public bool ClientUsed(string IdClient)
        {
            query = "select * from Ticket where IdClient=" + IdClient;
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows > 0 ? true : false;
        }
        public bool CamionUsed(string IdCamion)
        {
            query = "select * from Ticket where IdCamion='" + IdCamion+"'";
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows > 0 ? true : false;
        }

        ////////////////////////////////////////////

        public void ExecuteQuery(string txtQuery)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        ////////////////////////////////////////////
        public void setTableToDgv(DataGridView DGV, string table)
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT * from " + table;
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            DGV.DataSource = DT;
            sql_con.Close();
        }
        public void LoadDataToGradeView(DataGridView DGV, string query)
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();


            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();

            DB = new SQLiteDataAdapter(query, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            DGV.DataSource = DT;
            sql_con.Close();
        }

        ////////////////////////////////////////////
        public void PrintTicket(int IdTicket)
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            TicketDataSet TDS = new TicketDataSet();
            DataTable DT = new DataTable();
            sql_con.Open();
            sql_con.CreateCommand();
            String CommandText;

            
            
            CommandText = "SELECT IdTicket, DateE, DateS, Matricule, Tare, Brut, Net, (Net / Density / 1000) AS NET_M, " +
                    " NomProduit, NomClient, (prix*Net/1000) as Prix" +
                    " FROM Ticket INNER JOIN Camion ON Ticket.IdCamion = Camion.IdCamion " +
                    " INNER JOIN Produit ON Ticket.IdProduit = Produit.IdProduit " +
                    " LEFT join Client C on Ticket.IdClient = C.IdClient where IdTicket=" + IdTicket;
            

            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, sql_con);
            DB.Fill(TDS, "TicketTable");

            if (TDS.Tables["TicketTable"].Rows.Count == 0)
            {
                MessageBox.Show("No Ticket Valide");
            }

            RPT.Rept rept = new RPT.Rept();
            rept.setTicketDataSet(TDS);
            rept.Show();
        }

        ////////////////////////////////////////////
        public void autoCompiletMatricule(TextBox txb)
        {
            if (Properties.Settings.Default.AutoCompiletMatricule)
            {
                txb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txb.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                txb.AutoCompleteCustomSource = collectionMatricule;
            }
        }
        public void autoCompiletClient(TextBox txb)
        {
            if (Properties.Settings.Default.AutoCompiletMatricule)
            {
                txb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collectionClient = new AutoCompleteStringCollection();

                SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
                sql_con.Open();
                SQLiteDataReader myReadear;
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "select * from Client";
                myReadear = sql_cmd.ExecuteReader();
                while (myReadear.Read())
                {
                    string prod = myReadear.GetString(myReadear.GetOrdinal("NomClient"));
                    collectionClient.Add(prod);
                }

                myReadear.Close();
                sql_con.Close();
                txb.AutoCompleteCustomSource = collectionClient;
            }
        }
        public Tables.Ticket getAttenTicketsByMatricule(String matricule)
        {
            Tables.Ticket ticket = new Tables.Ticket();


            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from ticket natural join Camion where attend=1 and matricule='" + matricule+"' ";
            myReadear = sql_cmd.ExecuteReader();
            while (myReadear.Read())
            {
                ticket.IdTicket = myReadear.GetInt32(myReadear.GetOrdinal("IdTicket"));
                ticket.EnterDate = myReadear.GetDateTime(myReadear.GetOrdinal("DateE"));
            }

            myReadear.Close();
            sql_con.Close();
            return ticket;
        }
        public void loadListAAttend(ListBox listBox)
        {
            listBox.Items.Clear();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from ticket inner join Camion on Ticket.idCamion = Camion.IdCamion where attend=1";
            myReadear = sql_cmd.ExecuteReader();
            while (myReadear.Read())
            {
                listBox.Items.Add(myReadear.GetString(myReadear.GetOrdinal("matricule")));
            }

            myReadear.Close();
            sql_con.Close();
        }
        public bool isTicketAttend(int idTicket)
        {
            query = "select * from Ticket where attend=1 and IdTicket=" + idTicket;
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = query;
            myReadear = sql_cmd.ExecuteReader();
            int nbrRows = myReadear.StepCount;
            if (nbrRows.Equals(null)) nbrRows = 0;
            myReadear.Close();
            sql_con.Close();
            return nbrRows > 0 ? true : false;
        }
    }
}