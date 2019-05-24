using DasemBeniSanssen.Classes;
using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    /// <summary>
    /// ////////////////////////////////////// Problem in autoCompileClient AND insert the Configuration Valus
    /// </summary>
    public partial class Splash : Form
    {
        //gourpe Ticket

        Tables.Ticket ticket = new Tables.Ticket();
        Tables.Camion camion = new Tables.Camion();
        Tables.Product product = new Tables.Product();
        Tables.Client client = new Tables.Client();
        Sqlite db = new Sqlite();

        string query;
        string queryDGV = "SELECT IdTicket as 'N°_PESEE',DateE AS 'DATE ENTREE',DateS as 'Date Sortie',Matricule,NomClient as Client,NomProduit as Produit,Brut,Tare, Net," +
                " round((Brut - Tare) / (Density * 1000), 2) as Net_m, ((Brut - Tare) * Prix/1000) as Prix, Credit" +
                " from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                            " left join Client C on Ticket.IdClient = C.IdClient" +
                             " inner join Camion C2 on Ticket.IdCamion = C2.IdCamion where attend=0" +
                             " ORDER BY IdTicket desc limit 10";

        public Splash()
        {
            InitializeComponent();
            //groupBox1.BackColor = System.Drawing.Color.FromArgb(242, 222, 140);
            //groupBox3.BackColor = System.Drawing.Color.FromArgb(246, 201, 115);
        }
        public void Splash_Load(object sender, EventArgs e)
        {
            ClearTicket();
            getProduitToCombox();
            //getClientToCombox();
            db.LoadDataToGradeView(dgv_ticket, queryDGV);
            db.autoCompiletMatricule(txb_matricule);
            db.autoCompiletClient(txb_client);
            //LoadDataToTicket();
            loadListAttend();
            updatSplashViewStyle();
            removeControlersFromTabOrder();         
        }
        public void LoadDataToDGVSplash()
        {
            db.LoadDataToGradeView(dgv_ticket, queryDGV);
        }
        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
                Environment.Exit(Environment.ExitCode);
        }

        private void LoadDataToTicket()
        {
            txb_id_ticket.Text = db.getMaxIdIncr().ToString();
            dtp_date_e.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            dtp_date_s.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        //validation textBox
        public void txb_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txb_string_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }


        //Call Calcule
        private void txb_KeyUp(object sender, KeyEventArgs e)
        {
            Calculat();
        }
        private void txb_TextChanged(object sender, EventArgs e)
        {
            Calculat();
        }
        private void txb_matricule_TextChanged(object sender, EventArgs e)
        {
            getMatriculeToTextBox();
        }

        private void txb_brut_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 13)
            {
                validateTicket();
            }
        }

        //btn click
        private void btn_validation_Click(object sender, EventArgs e)
        {
            validateTicket();
            actualiser();
        }
        private void btn_add_to_camion_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txb_matricule.Text))
            {
                MessageBox.Show("Ajouter un Matricule", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (String.IsNullOrEmpty(txb_tare.Text))
            {
                MessageBox.Show("Ajouter une Tare", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                getDataGrpTicket();
            }

            if (!isMatricule())
            {
                MessageBox.Show("Le matricule est incorrect 'numero + Capital Alpha + numero'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }

            if (db.CountMatricule(camion.Matricule) == 0)
            {
                query = "INSERT INTO Camion(Matricule,Tare) Values('" +camion.Matricule+ "','" + camion.Tare + "')";
                db.ExecuteQuery(query);
            }
            else
            {
                query = "UPDATE Camion SET Tare=" + camion.Tare + " where Matricule='" + camion.Matricule + "'";
                db.ExecuteQuery(query);
            }
            db.autoCompiletMatricule(txb_matricule);
        }
        private void btn_add_to_attend_Click(object sender, EventArgs e)
        {
            String curr_dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (grpTicketIsEmpty("New"))
            {
                MessageBox.Show("please complet all records", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
                getDataGrpTicket();

            if (!isMatricule())
            {
                MessageBox.Show("Le matricule est incorrect 'numero + Capital Alpha + numero'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            if (isExistInListAttend())
            {
                MessageBox.Show("déja exist dans la list d'attent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (db.CountMatricule(camion.Matricule) == 0)
            {
                query = "INSERT INTO Camion(Matricule,Tare) Values('" + camion.Matricule + "','" + camion.Tare + "')";
                db.ExecuteQuery(query);
            }
            else
            {
                if (Properties.Settings.Default.AutoSaveMatricule)
                {
                    query = "UPDATE Camion SET Tare=" + camion.Tare + " where Matricule='" + camion.Matricule + "'";
                    db.ExecuteQuery(query);
                }
            }

            db.ExecuteQuery("insert into Ticket(DateE, IdTicket, IdCamion, attend) values('" + curr_dt + "','" + ticket.IdTicket + "','" 
                + db.getCamion_IdCamion(camion.Matricule) + "',1)");
            loadListAttend();
        }

        private void list_box_attend_DoubleClick(object sender, EventArgs e)
        {
            if (list_box_attend.SelectedItem == null) return;
            Tables.Ticket ticket = new Tables.Ticket();
            ticket = db.getAttenTicketsByMatricule(list_box_attend.SelectedItem.ToString());
            txb_id_ticket.Text = ticket.IdTicket.ToString();
            dtp_date_e.Text = ticket.EnterDate.ToString();
            txb_matricule.Text = list_box_attend.SelectedItem.ToString();
        }

        //ComboBox Produit
        private void cb_produit_SelectedIndexChanged(object sender, EventArgs e)
        {
            setProduitDetails();
            Calculat();
        }

        //get data to combo box
        //private void getClientToCombox()
        //{
        //    txb_client.Clear();
        //    SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
        //    sql_con.Open();
        //    SQLiteDataReader myReadear;
        //    SQLiteCommand sql_cmd = sql_con.CreateCommand();
        //    sql_cmd.CommandText = "select * from Client order by NomClient";
        //    myReadear = sql_cmd.ExecuteReader();
        //    string clt = "";
        //    cb_client.Items.Add(clt);
        
        //    while (myReadear.Read())
        //    {
        //        clt = myReadear.GetString(myReadear.GetOrdinal("NomClient"));
        //        cb_client.Items.Add(clt);
        //    }
        //    myReadear.Close();
        //    sql_con.Close();
        //}
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
        private void setProduitDetails()
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Produit where NomProduit='" + cb_produit.SelectedItem + "'";
            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                decimal density = (decimal)myReadear["Density"];
                txb_density.Text = density.ToString();
                int prix = (int)myReadear["Prix"];
                txb_prix.Text = prix.ToString();
            }

            myReadear.Close();
            sql_con.Close();
        }


        //Other about ticket data
        private bool grpTicketIsEmpty(string type)
        {
            if (type.Equals("Valider"))
            {
                if (String.IsNullOrEmpty(txb_matricule.Text)) return true;
                else if (txb_tare.Text == "0" || String.IsNullOrEmpty(txb_tare.Text)) return true;
                else if (txb_brut.Text == "0" || String.IsNullOrEmpty(txb_brut.Text)) return true;
                else if (String.IsNullOrEmpty(txb_id_ticket.Text)) return true;
                else if (String.IsNullOrEmpty(cb_produit.Text)) return true;
                else if (String.IsNullOrEmpty(txb_prix.Text)) return true;
                else if (String.IsNullOrEmpty(txb_density.Text)) return true;

            }
            else if (type.Equals("New"))
            {

                if (String.IsNullOrEmpty(txb_matricule.Text)) return true;
                else if (txb_tare.Text == "0" || String.IsNullOrEmpty(txb_tare.Text)) return true;
                else if (String.IsNullOrEmpty(txb_id_ticket.Text)) return true;
            }
            return false;

        }
        private void getDataGrpTicket()
        {
            int prix, idTicket, netKg, brut, tare;
            float density;
            float netM3;
            //DateTime enterDate, exitDate;


            ticket.Credit = ckb_credit.Checked;
            Int32.TryParse(txb_tare.Text,out tare);
            camion.Tare = tare;
            camion.Matricule = txb_matricule.Text;
            Int32.TryParse(txb_brut.Text,out brut);
            ticket.Brut = brut;
            float.TryParse(txb_net_m.Text,out netM3);
            ticket.NetM3 = netM3;
            Int32.TryParse(txb_net_t.Text,out netKg);
            ticket.NetKg = netKg;
            int.TryParse(txb_id_ticket.Text,out idTicket);
            ticket.IdTicket = idTicket;
            product.ProductName = cb_produit.Text;
            Int32.TryParse(txb_prix.Text,out prix);
            product.Prix = prix;
            float.TryParse(txb_density.Text,out density);
            product.Density = density;
            client.ClientName = txb_client.Text;      
        }


        //Calculation
        private void Calculat()
        {
            int brut = 0, tare = 0, prix = 0;
            float density = 0, net = 0;

            int.TryParse(txb_brut.Text, out brut);
            int.TryParse(txb_tare.Text, out tare);
            float.TryParse(txb_density.Text, out density);
            int.TryParse(txb_prix.Text, out prix);

            net = (float)(brut - tare);

            txb_net_t.Text = net.ToString();
            txb_net_m.Text = Math.Round(net / density / 1000, 2, MidpointRounding.AwayFromZero).ToString();
            txb_prix_ttc.Text = (net * prix/1000).ToString(".");
        }

        private void ClearTicket()
        {
            txb_id_ticket.Clear();
            dtp_date_e.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            txb_matricule.Clear();
            txb_tare.Clear();
            txb_brut.Clear();
            txb_net_m.Clear();
            txb_net_t.Clear();
            txb_prix_ttc.Clear();
            list_box_attend.Items.Clear();

            cb_produit.Text = null;
            txb_density.Clear();
            txb_prix.Clear();
            ckb_credit.Checked = false;
            txb_client.Clear();
        }

        //Actualiser
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualiser();  
        }
        //totalisation BarTools
        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Totalisation totalisation = new Totalisation();
            totalisation.set_type(0);
            totalisation.FormBorderStyle = FormBorderStyle.FixedDialog;
            totalisation.ShowDialog();
        }
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Totalisation totalisation = new Totalisation();
            totalisation.set_type(1);
            totalisation.FormBorderStyle = FormBorderStyle.FixedDialog;
            totalisation.ShowDialog(this);
        }
        private void camionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Totalisation totalisation = new Totalisation();
            totalisation.set_type(2);
            totalisation.FormBorderStyle = FormBorderStyle.FixedDialog;
            totalisation.ShowDialog();
        }
        private void clientCamionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Totalisation totalisation = new Totalisation();
            totalisation.set_type(3);
            totalisation.FormBorderStyle = FormBorderStyle.FixedDialog;
            totalisation.ShowDialog();
        }
        //Sutuation
        private void rapportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfirmationAdmin confirmationAdmin = new ConfirmationAdmin();
            confirmationAdmin.setType(2);
            confirmationAdmin.Show();      
        }
        
        //Base de donnees
        private void journaleDePeseeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchJournale searchJournale = new SearchJournale();
            searchJournale.FormBorderStyle = FormBorderStyle.FixedDialog;
            searchJournale.Owner = this;
            searchJournale.ShowDialog();
        }
        /*Produit*/
        private void modifierToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddData configuration = new AddData();
            configuration.set_type(0);
            configuration.FormBorderStyle = FormBorderStyle.FixedDialog;
            configuration.ShowDialog();
        }
        /*Client*/
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddData configuration = new AddData();
            configuration.set_type(1);
            configuration.FormBorderStyle = FormBorderStyle.FixedDialog;
            configuration.ShowDialog();
        }
        /*Camion*/
        private void modifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddData configuration = new AddData();
            configuration.set_type(2);
            configuration.FormBorderStyle = FormBorderStyle.FixedDialog;
            configuration.ShowDialog();
        }
       
        /*Produit*/
        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Type = 0;
            product.Show();

        }
        /*Client*/
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Type = 0;
            client.Show();
        }
        /*Camion*/
        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Camion camion = new Camion();
            camion.Type = 0;
            camion.Show();
        }


        //Obseravtion
        private void observationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Observation obs = new Observation();
            obs.Show();
        }
        
        //option
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.FormBorderStyle = FormBorderStyle.FixedDialog;
            configuration.FormClosed += new FormClosedEventHandler(configuration_FormClosed);
            configuration.ShowDialog(this);
        }
        private void resetLaBaseDeDonnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vouler Vous Vraiment Suprrimer La base de donne", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                ConfirmationAdmin admin = new ConfirmationAdmin();
                admin.FormBorderStyle = FormBorderStyle.FixedDialog;
                admin.setType(0);
                admin.ShowDialog();
            }
        }
        private void quitterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfirmationAdmin admin = new ConfirmationAdmin();
            admin.FormBorderStyle = FormBorderStyle.FixedDialog;
            admin.setType(1);
            admin.ShowDialog();

        }

        //aide
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }


        private void configuration_FormClosed(object sender, FormClosedEventArgs e)
        {
            updatSplashViewStyle();
        }

        private void getMatriculeToTextBox()
        {
            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Camion where Matricule='" + txb_matricule.Text + "'";
            myReadear = sql_cmd.ExecuteReader();
            myReadear.Read();
            if (myReadear.StepCount == 1)
            {
                string tare = myReadear["Tare"].ToString();
                txb_tare.Text = tare;
            }
            else
            {
                txb_tare.Text = null;
            }
            myReadear.Close();
            sql_con.Close();
        }
        private void updatSplashViewStyle()
        {
            if (!Properties.Settings.Default.ShowSplashDGV)
            {
                dgv_ticket.Visible = false;
                Width = 1013;
                Height = 450;
            }
            else
            {
                dgv_ticket.Visible = true;
                Width = 1013;
                Height = 607;
            }

            
        }
        private void removeControlersFromTabOrder()
        {
            txb_net_m.TabStop = false;
            txb_net_t.TabStop = false;
            txb_prix_ttc.TabStop = false;
            btn_add_to_camion.TabStop = false;
            dtp_date_e.TabStop = false;
            txb_id_ticket.TabStop = false;
            txb_prix.TabStop = false;
            txb_density.TabStop = false;
        }

        private void validateTicket()
        {
            if (grpTicketIsEmpty("Valider"))
            {
                MessageBox.Show("veuillez remplir tous les champs obligatoires", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
                getDataGrpTicket();

            // insert the new camion in camion table
            if (!isMatricule())
            {
                MessageBox.Show("Le matricule est incorrect 'numero + Capital Alpha + numero'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            if (db.CountMatricule(camion.Matricule) == 0)
            {
                query = "INSERT INTO Camion(Matricule,Tare) Values('" + camion.Matricule + "','" + camion.Tare + "')";
                db.ExecuteQuery(query);
            }
            else
            {
                if (Properties.Settings.Default.AutoSaveMatricule)
                {
                    query = "UPDATE Camion SET Tare=" + camion.Tare + " where Matricule='" + camion.Matricule + "'";
                    db.ExecuteQuery(query);
                }
            }


            if (db.CountClient(client.ClientName) == 0)
            {
                query = "INSERT INTO Client(NomClient) Values('" + client.ClientName + "')";
                db.ExecuteQuery(query);
            }

            String curr_dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (db.CountIdTicket(ticket.IdTicket) == 0)
            {
                if (!String.IsNullOrEmpty(client.ClientName))
                {
                    query = "INSERT INTO Ticket(DateE,DateS,IdTicket,Brut,IdCamion,IdProduit,IdClient,Credit,Net)" +
                            " Values('" + curr_dt + "','" + curr_dt + "','" + ticket.IdTicket + "','" + ticket.Brut + "','" + db.getCamion_IdCamion(camion.Matricule) + "','" 
                            + db.getProduit_IdProduit(product.ProductName) + "','" + db.getClient_IdClient(client.ClientName) + "','" +Convert.ToInt32(ticket.Credit) + "'," + ticket.NetKg + ")";
                }
                else
                {
                    query = "INSERT INTO Ticket(DateE,DateS,IdTicket,Brut,IdCamion,IdProduit,Credit,Net)" +
                            " Values('" + curr_dt + "','" + curr_dt + "','" + ticket.IdTicket + "','" + ticket.Brut + "','" + db.getCamion_IdCamion(camion.Matricule) + 
                            "','" + db.getProduit_IdProduit(product.ProductName) + "','" + Convert.ToInt32(ticket.Credit) + "'," + ticket.NetKg + ")";
                }
                db.ExecuteQuery(query);
            }
            else if(db.CountIdTicket(ticket.IdTicket) == 1 && db.isTicketAttend(ticket.IdTicket))
            {
                query = "update Ticket set DateS='"+curr_dt+"' where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
                query = "update Ticket set IdProduit='"+db.getProduit_IdProduit(product.ProductName)+"' where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
                query = "update Ticket set brut='"+ticket.Brut+ "' where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
                if (!String.IsNullOrEmpty(client.ClientName))
                {
                    query = "update Ticket set IdClient='" + db.getClient_IdClient(client.ClientName) + "' where idTicket=" + ticket.IdTicket;
                    db.ExecuteQuery(query);
                }
                query = "update Ticket set Credit='" + Convert.ToInt32(ticket.Credit) + "' where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
                query = "update Ticket set Net='" + ticket.NetKg + "' where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
                query = "update Ticket set attend=0 where idTicket=" + ticket.IdTicket;
                db.ExecuteQuery(query);
            }
            else
            {

                MessageBox.Show("Numero de Ticket Non valide", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //start Repport Ticket Forms
            db.PrintTicket(ticket.IdTicket);

            db.LoadDataToGradeView(dgv_ticket, queryDGV);
            ClearTicket();
            loadListAttend();
        }

        public void loadListAttend()
        {
            ClearTicket();
            db.loadListAAttend(list_box_attend);
            LoadDataToTicket();
        }

        private bool isMatricule()
        {
            Regex regex = new Regex("[0-9]+ [A-Z]{1} [0-9]+");
            Match match = regex.Match(txb_matricule.Text);

            if (match.Success) return true;
            else return false;
        }
        private bool isExistInListAttend()
        {
            foreach(var mat in list_box_attend.Items)
            {
                if (txb_matricule.Text.Equals(mat)) return true;
            }
            return false;
        }
        private void actualiser()
        {
            ClearTicket();
            //ClearTicket();
            db.LoadDataToGradeView(dgv_ticket, queryDGV);
            LoadDataToTicket();
            loadListAttend();
            db.autoCompiletMatricule(txb_matricule);
            db.autoCompiletClient(txb_client);
            getProduitToCombox();
            //getClientToCombox();
        }

       
    }
}