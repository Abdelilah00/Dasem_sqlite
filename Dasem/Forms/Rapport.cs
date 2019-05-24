using System;
using System.Data;
using System.Data.SQLite;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
/// <summary>
/// ////////////////////////////////////// Probleme in DateTime DataBase
/// </summary>

namespace DasemBeniSanssen.Forms
{
    public partial class Rapport : Form
    {
        string dt1,dt2;

        public Rapport()
        {
            InitializeComponent();
        }
        private void Rapport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dateTimePicker2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            getRangOfTime();
            LoadDataToReport();
        }

        private void LoadDataToReport()
        {
            LoadDataToReportDetails();
            LoadDataToReportTotale();
        }

        private void LoadDataToReportDetails()
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select IdCompany, IdTicket as 'N° Ticket', Matricule, Tare , DateE , DateS," +
               " Produit.NomProduit AS AGREGATS, Net, ROUND((Brut-Tare)/Density/1000,2) as 'Net M', NomClient AS Client, Credit AS 'Paiement'" +
               " from Ticket" +
               " INNER JOIN Camion ON Ticket.IdCamion = Camion.IdCamion " +
               " left join Client On Ticket.IdClient=Client.IdClient" +
               " INNER JOIN Produit ON Ticket.IdProduit = Produit.IdProduit" +
               " and DateE between '"+dt1+"' and '"+dt2+"'"+
               " Order By 'N° Bon'";

            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dgv_report_details.DataSource = DT;
            sql_con.Close();
        }
        private void LoadDataToReportTotale()
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            //string CommandText = "select Matricule,Tare from Camion";
            string CommandText = "select NomProduit AS AGREGATS,SUM(Cast(NET as float))/1000 AS 'NET Tonne', ROUND(SUM(NET/Density)/1000,2) AS 'NET M3'" +
                "from (select NomProduit, Density, NET " +
                "from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                "inner join Camion C on Ticket.IdCamion = C.IdCamion "+
                "where DateE between '" + dt1 + "' and '" + dt2 + "') group by AGREGATS order by AGREGATS";

            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dgv_report_total.DataSource = DT;
            sql_con.Close();
        }
        private DataTable getDataTotalCredit()
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select NomProduit AS AGREGATS,SUM(Cast(NET as float))/1000  AS 'NET TONNE', ROUND(SUM(NET/Density)/1000,2) AS 'NET M3'" +
                "from (select NomProduit, Density, NET " +
                "from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                "inner join Camion C on Ticket.IdCamion = C.IdCamion " +
                "where DateE between '" + dt1 + "' and '" + dt2 + "' and Credit=1) group by AGREGATS order by AGREGATS";

            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            return DT;
        }
        private DataTable getDataTotaleEspece()
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select NomProduit AS AGREGATS,SUM(Cast(NET as float))/1000  AS 'NET TONNE', ROUND(SUM(NET/Density)/1000,2) AS 'NET M3'" +
                "from (select NomProduit, Density, NET " +
                "from Ticket inner join Produit P on Ticket.IdProduit = P.IdProduit " +
                "inner join Camion C on Ticket.IdCamion = C.IdCamion " +
                "where DateE between '" + dt1 + "' and '" + dt2 + "' and Credit=0) group by AGREGATS order by AGREGATS";

            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            return DT;
        }
        private DataTable getObservation()
        {
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            SQLiteConnection sql_con = new SQLiteConnection(Properties.Settings.Default.StringConnection);
            sql_con.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select Observation.IdTicket as 'N° Bon', Observ from Ticket inner join Observation on Ticket.IdTicket = Observation.IdTicket " +
                "where dateE between '"+dt1+"' and '"+dt2+"'";

            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            return DT;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt1 = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            LoadDataToReport();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dt2 = DateTime.Parse(dateTimePicker2.Text).AddDays(1).ToString("yyyy-MM-dd");
            LoadDataToReport();
        }

        private void getRangOfTime()
        {
            dt1 = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            dt2 = DateTime.Parse(dateTimePicker2.Text).AddDays(1).ToString("yyyy-MM-dd");
        }
        
        //Button export report Click 
        private void btn_export_Click(object sender, EventArgs e)
        {
            exportReport();
        }

        private void exportReport()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workBook = app.Workbooks.Add();
            Excel.Worksheet workSheet = null;

            getRangOfTime();

            workSheet = workBook.Worksheets[1];
            workSheet = workBook.ActiveSheet;
            workSheet.Name = "Report";
            int ligne = 0;
            Excel.Range range;

            //Repport Details
            for (int i = 1; i < dgv_report_details.ColumnCount + 1; i++)
            {
                workSheet.Cells[1, i] = dgv_report_details.Columns[i - 1].HeaderText;
                workSheet.Cells[1, i].EntireRow.Font.Bold = true;
                workSheet.Cells[1, i].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            for (int i = 0; i < dgv_report_details.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_report_details.Columns.Count; j++)
                {
                    var value = dgv_report_details.Rows[i].Cells[j].Value;
                  
                    if (Convert.ToString(value).Equals("True"))
                    {
                        value = "Credit";
                    }
                    else if (Convert.ToString(value).Equals("False"))
                    {
                        value = "Espece";
                    }

                    workSheet.Cells[i + 2, j + 1] = value ;
                    workSheet.Cells[i + 1, j + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }
            ligne += dgv_report_details.Rows.Count;
            ligne += 5;

            //Totale Product
            if (Properties.Settings.Default.TotalTotal)
            {
                workSheet.Cells[ligne - 1, 5] = "TOTALE";
                workSheet.Cells[ligne - 1, 5].EntireRow.Font.Bold = true;
                workSheet.Range[workSheet.Cells[ligne - 1, 5], workSheet.Cells[ligne - 1, 7]].Merge();

                for (int i = 1; i < dgv_report_total.ColumnCount + 1; i++)
                {
                    workSheet.Cells[ligne, i + 4] = dgv_report_total.Columns[i - 1].HeaderText;
                    workSheet.Cells[ligne, i + 4].EntireRow.Font.Bold = true;
                    workSheet.Cells[ligne, i + 4].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                for (int i = 0; i < dgv_report_total.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_report_total.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 1 + ligne, j + 5] = dgv_report_total.Rows[i].Cells[j].Value;
                        workSheet.Cells[i + ligne, j + 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
                ligne += dgv_report_total.Rows.Count;
                ligne += 3;
            }

            //Totale Credit
            if (Properties.Settings.Default.TotalCredit)
            {
                workSheet.Cells[ligne - 1, 5] = "TOTALE Credit";
                workSheet.Cells[ligne - 1, 5].EntireRow.Font.Bold = true;
                workSheet.Range[workSheet.Cells[ligne - 1, 5], workSheet.Cells[ligne - 1, 7]].Merge();

                DataTable dtblCredit = getDataTotalCredit();
                for (int culomn = 0; culomn < dtblCredit.Columns.Count; culomn++)
                {
                    workSheet.Cells[ligne, culomn + 5] = dtblCredit.Columns[culomn].ColumnName.ToUpper();
                    workSheet.Cells[ligne, culomn + 5].EntireRow.Font.Bold = true;
                    workSheet.Cells[ligne, culomn + 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
                for (int row = 0; row < dtblCredit.Rows.Count; row++)
                {
                    for (int column = 0; column < dtblCredit.Columns.Count; column++)
                    {
                        int inRow = ligne + row + 1;
                        int inColumn = column + 5;
                        workSheet.Cells[inRow, inColumn] = dtblCredit.Rows[row].ItemArray[column];
                        workSheet.Cells[inRow, inColumn].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
                ligne += dtblCredit.Rows.Count;
                ligne += 4;
            }

            //Totale ESPECE
            if (Properties.Settings.Default.TotalEspece)
            {
                workSheet.Cells[ligne - 1, 5] = "TOTALE Espece";
                workSheet.Cells[ligne - 1, 5].EntireRow.Font.Bold = true;
                workSheet.Range[workSheet.Cells[ligne - 1, 5], workSheet.Cells[ligne - 1, 7]].Merge();

                DataTable dtblEspece = getDataTotaleEspece();
                for (int culomn = 0; culomn < dtblEspece.Columns.Count; culomn++)
                {
                    workSheet.Cells[ligne, culomn + 5] = dtblEspece.Columns[culomn].ColumnName.ToUpper();
                    workSheet.Cells[ligne, culomn + 5].EntireRow.Font.Bold = true;
                    workSheet.Cells[ligne, culomn + 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
                for (int row = 0; row < dtblEspece.Rows.Count; row++)
                {
                    for (int column = 0; column < dtblEspece.Columns.Count; column++)
                    {
                        int inRow = ligne + row + 1;
                        int inColumn = column + 5;
                        workSheet.Cells[inRow, inColumn] = dtblEspece.Rows[row].ItemArray[column];
                        workSheet.Cells[inRow, inColumn].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
                ligne += dtblEspece.Rows.Count;
                ligne += 3;
            }

            //Observation
            if (Properties.Settings.Default.Observ)
            {
                workSheet.Cells[ligne - 1, 5] = "Observation";
                workSheet.Cells[ligne - 1, 5].EntireRow.Font.Bold = true;
                workSheet.Range[workSheet.Cells[ligne - 1, 5], workSheet.Cells[ligne - 1, 7]].Merge();

                DataTable dtblObsrv = getObservation();
                for (int culomn = 0; culomn < dtblObsrv.Columns.Count; culomn++)
                {
                    workSheet.Cells[ligne, culomn + 5] = dtblObsrv.Columns[culomn].ColumnName.ToUpper();
                    workSheet.Cells[ligne, culomn + 5].EntireRow.Font.Bold = true;
                    workSheet.Cells[ligne, culomn + 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
                for (int row = 0; row < dtblObsrv.Rows.Count; row++)
                {
                    for (int column = 0; column < dtblObsrv.Columns.Count; column++)
                    {
                        int inRow = ligne + row + 1;
                        int inColumn = column + 5;
                        workSheet.Cells[inRow, inColumn] = dtblObsrv.Rows[row].ItemArray[column];
                        workSheet.Cells[inRow, inColumn].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
            }
            


            //set Values in center cells
            Excel.Range c1 = workSheet.Cells[1, 1];
            Excel.Range c2 = workSheet.Cells[ligne + 50, 11];
            range = workSheet.get_Range(c1, c2);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Save the Repport
            var saveFileDialoge = new SaveFileDialog();
            DateTime date2 = DateTime.Parse(dateTimePicker2.Text);
            saveFileDialoge.FileName = dt1 + " à " + date2.ToString("yyyy-MM-dd");
            saveFileDialoge.DefaultExt = ".xlsx";

            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workBook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing);
            }
            app.Quit();
            this.Close();
        }
    }
}