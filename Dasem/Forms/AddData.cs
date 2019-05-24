using System;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;
using DasemBeniSanssen.Forms;

namespace DasemBeniSanssen.Forms
{
    /////////////////////////////////////////// MESSAGES CONFERMATION
    
    public partial class AddData : Form
    {
        int type = 0, id_target;
        Sqlite db = new Sqlite();

        public void set_type(int type)
        {
            this.type = type;
        }

        public AddData()
        {
            InitializeComponent();
        }
        private void Configuration_Load(object sender, EventArgs e)
        {
            cb_config.SelectedIndex = type;
        }

        private void cb_config_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.setTableToDgv(dgv_config, cb_config.Text);
            get_first_idTicketTarget();

        }

        //Set DataBase To DataGridView
        private void dgv_config_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 46)
            {
                switch (cb_config.Text)
                {
                    case "Produit":
                        db.deleteRowProduit(id_target.ToString());
                        break;
                    case "Client":
                        db.deleteRowClient(id_target.ToString());
                        break;
                    case "Camion":
                        db.deleteRowCamion(id_target.ToString());
                        break;
                }
                db.setTableToDgv(dgv_config, cb_config.Text);
            }
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            switch (cb_config.Text)
            {
                case "Produit":
                    Product product = new Product();
                    product.Type = 1;
                    product.Id_target = id_target;
                    product.Show();
                    break;
                case "Client":
                    Client client = new Client();
                    client.Type = 1;
                    client.Id_target = id_target;
                    client.Show();
                    break;
                case "Camion":
                    Camion camion = new Camion();
                    camion.Type = 1;
                    camion.Id_target = id_target;
                    camion.Show();
                    break;
            }
        }

        private void dgv_config_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int inRow = e.RowIndex;
            if (inRow >= 0 && inRow < dgv_config.RowCount - 1)
            {
                DataGridViewRow row = dgv_config.Rows[inRow];
                id_target = Convert.ToInt32(row.Cells[0].Value);
                switch (cb_config.Text)
                {
                    case "Produit":
                        Product product = new Product();
                        product.Type = 1;
                        product.Id_target = id_target;
                        product.Show();
                        break;
                    case "Client":
                        Client client = new Client();
                        client.Type = 1;
                        client.Id_target = id_target;
                        client.Show();
                        break;
                    case "Camion":
                        Camion camion = new Camion();
                        camion.Type = 1;
                        camion.Id_target = id_target;
                        camion.Show();
                        break;
                    default:
                        MessageBox.Show("MA3reft");
                        break;
                }
            }
        }

        private void dgv_config_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int inRow = e.RowIndex;
            if (inRow >= 0 && inRow < dgv_config.RowCount-1)
            {
                DataGridViewRow row = dgv_config.Rows[inRow];
                id_target = Convert.ToInt32(row.Cells[0].Value);
            }
        }
        public void get_first_idTicketTarget()
        {
            if (dgv_config.RowCount > 1)
            {
                DataGridViewRow in_row = dgv_config.Rows[0];
                if (!String.IsNullOrWhiteSpace(in_row.Cells[0].Value.ToString()))
                {
                    id_target = Convert.ToInt32(in_row.Cells[0].Value);
                }
            }
        }
    }
}