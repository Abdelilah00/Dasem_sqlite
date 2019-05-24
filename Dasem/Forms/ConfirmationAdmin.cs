using System;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;
using System.Drawing;

namespace DasemBeniSanssen.Forms
{
    public partial class ConfirmationAdmin : Form
    {
        Sqlite db = new Sqlite();
        int type;

        public void setType(int type)
        {
            this.type = type;
        }
        public ConfirmationAdmin()
        {
            InitializeComponent();
            txb_passord.PasswordChar = '*';
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            if (db.LoginAdminSecssfuuly(txb_user.Text, txb_passord.Text))
            {
                if (type == 0)
                {
                    reset();
                    MessageBox.Show("Reset data Base Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(type == 1)
                {
                    Query query = new Query();
                    query.Show();

                }else if(type == 2)
                {
                    Rapport rapport = new Rapport();
                    rapport.FormBorderStyle = FormBorderStyle.FixedDialog;
                    rapport.ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBox.Show("The user not a Admin user or you enter a Wrong user or password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void reset()
        {
            //reset Ticket Table
            string query = "drop table Ticket";
            db.ExecuteQuery(query);
            query = "CREATE TABLE `Ticket` ("+
	                        "`IdCompany`	integer DEFAULT 2,"+
	                        "`IdTicket`	INTEGER,"+
	                        "`DateE`	datetime DEFAULT current_timestamp,"+
	                        "`DateS`	datetime,"+
	                        "`Brut`	int,"+
	                        "`IdCamion`	nvarchar(20),"+
	                        "`IdProduit`	integer,"+
	                        "`IdClient`	integer DEFAULT null,"+
	                        "`Credit`	boolean DEFAULT false,"+
	                        "`Net`	int,"+
	                        "`attend`	boolean DEFAULT false,"+
	                        "CONSTRAINT `Client___fk` FOREIGN KEY(`IdClient`) REFERENCES `Client`,"+
	                        "FOREIGN KEY(`IdCamion`) REFERENCES `Camion`(`Matricule`),"+
	                        "PRIMARY KEY(`IdTicket`),"+
	                        "CONSTRAINT `Produit___fk` FOREIGN KEY(`IdProduit`) REFERENCES `Produit`)";
            db.ExecuteQuery(query);
            query = " create unique index Ticket_IdTicket_uindex on Ticket(IdTicket)";
            db.ExecuteQuery(query);

            //reset Camion Table
            query = "drop table Camion";
            db.ExecuteQuery(query);
            query = "create table Camion(IdCamion integer primary key autoincrement," +
                "    Matricule Text, Tare int)";
            db.ExecuteQuery(query);
            query = "create unique index Camion_Matricule_uindex on Camion(Matricule)";
            db.ExecuteQuery(query);

            //reset Produit Table
            query = "drop table Produit";
            db.ExecuteQuery(query);
            query = "create table Produit(IdProduit  Integer  primary key autoincrement, " +
                    "NomProduit varchar(20), " +
                    "Density  decimal default 0, " +
                    "Prix  int default 0)";
            db.ExecuteQuery(query);
            query = "create unique index Produit_NomProduit_uindex on Produit(NomProduit)";
            db.ExecuteQuery(query);

            //reset Client Table
            query = "drop table Client";
            db.ExecuteQuery(query);
            query = "create table Client(" +
                    "IdClient integer primary key autoincrement, " +
                    "NomClient varchar(20))";
            db.ExecuteQuery(query);


            //reset Login Table
            query = "drop table Login";
            db.ExecuteQuery(query);
            query = "create table Login(User varchar(20) primary key, Password varchar(20), Admin boolean)";
            db.ExecuteQuery(query);
            query = "insert into Login(User, Password, Admin) Values('Alexis','Alexis_dh',1)";
            db.ExecuteQuery(query);
            query = "insert into Login(User, Password, Admin) Values('KHALID','1962',1)";
            db.ExecuteQuery(query);
            query = "insert into Login(User, Password, Admin) Values('user','user',0)";
            db.ExecuteQuery(query);

            //reset observation
            query = "drop table Observation";
            db.ExecuteQuery(query);
            query = "CREATE TABLE `Observation` ("+
	                "`IdTicket`	INTEGER,"+
	                "`Observ`	TEXT,"+
	                "`IdObseravtion`	INTEGER PRIMARY KEY AUTOINCREMENT,"+
                    "FOREIGN KEY(`IdTicket`) REFERENCES `Ticket`(`IdTicket`))";
            db.ExecuteQuery(query);

        }
    }
}
