using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DasemBeniSanssen.Forms
{
    public partial class Totalisation : Form
    {
        string list_items="", group_by="";
        string dt1, dt2;
        DataTable dataTable;
        bool back = false;
        int type = 0;

        public void set_type(int type)
        {
            this.type = type;
        }
        string StringConnection = Properties.Settings.Default.StringConnection;

        public Totalisation()
        {
            InitializeComponent();
        }
        private void Totalisation_Load(object sender, EventArgs e)
        {
            getDateZone();
            cb_type.SelectedIndex = type;
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_type.SelectedItem.ToString() == "Produit")
            {
                group_by = "NomProduit";
                getProduitToCheckListBox();
            }
            else if (cb_type.SelectedItem.ToString() == "Client")
            {
                group_by = "NomClient";
                getClientToCheckListBox();
            }
            else if (cb_type.SelectedItem.ToString() == "Camion")
            {
                group_by = "Matricule";
                getCamionToCheckListBox();
            }else if(cb_type.SelectedItem.ToString() == "Client-Camion")
            {
                group_by = "Client-Camion";
                getClientToCheckListBox();
            }
            getDataToDataGridView();
        }

        private void getProduitToCheckListBox()
        {
            cbl_1.Items.Clear();
            SQLiteConnection sql_con = new SQLiteConnection(StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Produit";
            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                string prod = myReadear.GetString(myReadear.GetOrdinal("NomProduit"));
                cbl_1.Items.Add(prod);
            }

            myReadear.Close();
            sql_con.Close();
        }
        private void getClientToCheckListBox()
        {
            cbl_1.Items.Clear();
            SQLiteConnection sql_con = new SQLiteConnection(StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Client";
            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                string prod = myReadear.GetString(myReadear.GetOrdinal("NomClient"));
                cbl_1.Items.Add(prod);
            }

            myReadear.Close();
            sql_con.Close();
        }
        private void getCamionToCheckListBox()
        {
            cbl_1.Items.Clear();
            SQLiteConnection sql_con = new SQLiteConnection(StringConnection);
            sql_con.Open();
            SQLiteDataReader myReadear;
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "select * from Camion";
            myReadear = sql_cmd.ExecuteReader();

            while (myReadear.Read())
            {
                string prod = myReadear.GetString(myReadear.GetOrdinal("Matricule"));
                cbl_1.Items.Add(prod);
            }

            myReadear.Close();
            sql_con.Close();
        }


        private void btn_export_report_Click(object sender, EventArgs e)
        {
            getChekdItems();
            getDataToDataGridView();
            if(!back)
                export();
        }
        private void getChekdItems()
        {
            list_items = null;
            bool first = true;

            foreach (string s in cbl_1.CheckedItems)
            {
                if (first)
                {
                    list_items += "'" + s + "'";
                    first = false;
                }
                else
                {
                    list_items += ",'" + s + "'";
                }   
            }
        }
        private void getDataToDataGridView()
        {
            getChekdItems();
            if (group_by.Equals("NomProduit"))
            {
                dataTable = getDataTotalitation("select NomProduit as Produit, SUM(CAST(NET as float))/1000 as 'NET Tonne', Round(SUM(CAST(NET as float))/1000/Density,2) as 'NET M' " +
                    " from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit" +
                    " where NomProduit IN(" + list_items + ") and DateE between '" + dt1 + "' and '" + dt2 + "' group by NomProduit");
            }
            else if(group_by == "NomClient")
            {
                dataTable = getDataTotalitation("select NomClient,NomProduit,Count(*) as 'Nbr de Voyage',SUM(CAST(NET as float))/1000 as 'NET Tonne', Round(SUM(CAST(NET as float))/1000/Density,2) as 'NET M'" +
                    " from Ticket  inner join Produit P on Ticket.IdProduit = P.IdProduit  " +
                    " left join Client C on Ticket.IdClient = C.IdClient where NomClient IN("+ list_items +") and " +
                    " DateE Between '" + dt1 +"' and '"+dt2+"' group by NomClient,NomProduit order by NomClient");
            }
            else if(group_by == "Matricule")
            {
                dataTable = getDataTotalitation("select Matricule,NomProduit,Count(*) as 'Nbr de Voyage',SUM(CAST(NET as float))/1000 as 'NET Tonne', Round(SUM(CAST(NET as float))/1000/Density,2) as 'NET M'" +
                    " from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                    " inner join  Camion C on C.IdCamion = Ticket.IdCamion " +
                    " where Matricule IN("+list_items+ ") and DateE between '" + dt1 + "' and '" + dt2 + "'" +
                    " group by Matricule, NomProduit order by Matricule");
            }
            else if (group_by == "Client-Camion")
            {
                dataTable = getDataTotalitation("select NomClient,Matricule,NomProduit,Count(*) as 'Nbr de Voyage',SUM(CAST(NET as float))/1000 as 'NET Tonne', " +
                    "Round(SUM(CAST(NET as float))/1000/Density,2) as 'NET M' " +
                     "from Ticket " +
                      "inner join Client on Ticket.IdClient = Client.IdClient " +
                      "inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                      "inner join  Camion C on C.IdCamion = Ticket.IdCamion " +
                      "where NomClient IN(" + list_items + ") and DateE between '" + dt1 + "' and '" + dt2 + "'" +
                     "group by NomClient, Matricule, NomProduit order by Matricule");
            }
                
            else
            {
                MessageBox.Show("please select the Filter", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                back = true;
                return;
            }
            back = false;
        }

        private void export()
        {

            Excel._Application app = new Excel.Application();
            Excel.Workbook workBook = app.Workbooks.Add();
            Excel.Worksheet workSheet = null;

            //WorkSheet Repport Details
            workSheet = workBook.Worksheets[1];
            workSheet = workBook.ActiveSheet;
            workSheet.Name = "Report";

            for (int culomn = 0; culomn < dataTable.Columns.Count; culomn++)
            {
                workSheet.Cells[1, culomn + 1] = dataTable.Columns[culomn].ColumnName.ToUpper();
            }
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int column = 0; column < dataTable.Columns.Count; column++)
                {
                    int inRow = row + 2;
                    int inColumn = column + 1;
                    workSheet.Cells[inRow, inColumn] = dataTable.Rows[row].ItemArray[column].ToString();
                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = list_items +" de "+ dt1 +" à "+ dt2;
            saveFileDialoge.DefaultExt = ".xlsx";

            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workBook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing);
            }
            app.Quit();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getDataToDataGridView();
            dataGridView1.DataSource = dataTable;
        }

        private void getDateZone()
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            dt1 = date.ToString("yyyy-MM-dd");

            date = DateTime.Parse(dateTimePicker2.Text);
            dt2 = date.AddDays(1).ToString("yyyy-MM-dd");
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getDateZone();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            getDateZone();
        }


        private DataTable getDataTotalitation(string CommandText)
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            return DT;
        }
    }
}