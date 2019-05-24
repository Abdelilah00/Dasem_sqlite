using System;
using DasemBeniSanssen.Forms;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;

namespace DasemBeniSanssen.Forms
{
    public partial class SearchJournale : Form
    {
        int id_target;
        string dt1, dt2;
        string matricule, idTicket;
        string queryDGV;
        Sqlite db = new Sqlite();


        public SearchJournale()
        {
            InitializeComponent();
        }

		private void SearchJournale_Load(object sender, EventArgs e)
		{
			dateTimePicker1.Text = DateTime.Now.ToString("dd-MM-yyyy");
			dateTimePicker2.Text = DateTime.Now.ToString("dd-MM-yyyy");
			getRangOfSearch();
			db.autoCompiletMatricule(txb_matricule);
			db.LoadDataToGradeView(dgv_journal, queryDGV);
			get_first_idTicketTarget();
		}

		//btn click
		private void btn_search_Click(object sender, EventArgs e)
        {
            getRangOfSearch();
            db.LoadDataToGradeView(dgv_journal, queryDGV);
			get_first_idTicketTarget();
		}
		private void btn_print_Click(object sender, EventArgs e)
        {
			if (db.CountIdTicket(id_target) == 1)
            {
                db.PrintTicket(id_target);
            }
            else
            {
				MessageBox.Show("N°_PESEE n'existe pas", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btn_update_ticket_Click(object sender, EventArgs e)
        {
			UpdateTicket updateTicket = new UpdateTicket();
            updateTicket.set_id_ticket(id_target);
            updateTicket.FormBorderStyle = FormBorderStyle.FixedDialog;
            updateTicket.Owner = this;
            updateTicket.ShowDialog();
        }

        private void getRangOfSearch()
        {
            //get date
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            dt1 = date.ToString("yyyy-MM-dd");

            date = DateTime.Parse(dateTimePicker2.Text);
            dt2 = date.AddDays(1).ToString("yyyy-MM-dd");

            
            //get id           
            if (String.IsNullOrEmpty(txb_id_ticket.Text))
            {
                idTicket = "is not null";
            }
            else
            {
                idTicket = "='" + txb_id_ticket.Text+"'";
            }

            //get matricule
            if (String.IsNullOrEmpty(txb_matricule.Text))
            {
                matricule = "is not null";
            }
            else
            {
                matricule = "='" + txb_matricule.Text+"'";
            }

            queryDGV = "select IdTicket as 'N° Bon', Matricule,Tare , DateE, DateS," +
                   " Produit.NomProduit AS AGREGATS, Net, ROUND((Brut-Tare)/Density/1000,2) as 'Net M', NomClient AS Client, Credit" +
                   " from Ticket" +
                   " INNER JOIN Camion ON Ticket.IdCamion = Camion.IdCamion " +
                   " left join Client On Ticket.IdClient=Client.IdClient" +
                   " INNER JOIN Produit ON Ticket.IdProduit = Produit.IdProduit where IdTicket " + idTicket + " and Matricule " + matricule +
                   " and DateE between '" + dt1 + "' and '" + dt2 + "'" +
                   " Order By IdTicket desc";
        }

        private void dgv_journal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int inRow = e.RowIndex;
            if (inRow >= 0 && inRow < dgv_journal.RowCount - 1)
            {
                DataGridViewRow row = dgv_journal.Rows[inRow];
                if(! String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString())){
                    id_target = Convert.ToInt32(row.Cells[0].Value);
                }
            }
        }
        private void dgv_journal_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 46)
            {
                db.deleteRowTicket(id_target.ToString());
                getRangOfSearch();
                db.LoadDataToGradeView(dgv_journal, queryDGV);
            }
        }

        private void SearchJournale_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Splash)this.Owner).LoadDataToDGVSplash();
        }

        public void get_first_idTicketTarget()
		{
			if (dgv_journal.RowCount > 1)
			{
				DataGridViewRow in_row = dgv_journal.Rows[0];
				if (!String.IsNullOrWhiteSpace(in_row.Cells[0].Value.ToString()))
				{
					id_target = Convert.ToInt32(in_row.Cells[0].Value);
				}
			}	
		}
        public void LoadDataToDGVJournal()
        {
            db.LoadDataToGradeView(dgv_journal, queryDGV);
        }

    }
}
