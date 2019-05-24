using DasemBeniSanssen.Classes;
using System;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    public partial class Observation : Form
    {
        public Observation()
        {
            InitializeComponent();
        }

        private void bnt_add_to_observation_Click(object sender, EventArgs e)
        {
            Sqlite db = new Sqlite();


            if (isEmpty())
            {
                MessageBox.Show("veuillez remplir tous les champs obligatoires", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }else if (db.CountIdTicket(Convert.ToInt32(txb_id_ticket.Text)) == 0)
            {
                MessageBox.Show("Le Numero de Ticket n'existe pas", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            String query = "insert into Observation(IdTicket,Observ) Values('" + txb_id_ticket.Text + "','" + rtxb_remarque.Text + "')";
            db.ExecuteQuery(query);
            clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool isEmpty()
        {
            if (String.IsNullOrEmpty(txb_id_ticket.Text)) return true;
            if (String.IsNullOrEmpty(rtxb_remarque.Text)) return true;
            return false;
        }
        private void clear()
        {
            rtxb_remarque.Clear();
            txb_id_ticket.Clear();
        }
    }
}