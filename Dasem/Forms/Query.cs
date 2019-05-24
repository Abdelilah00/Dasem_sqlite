using System;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;
using Excel = Microsoft.Office.Interop.Excel;

namespace DasemBeniSanssen.Forms
{
    public partial class Query : Form
    {
        Sqlite db = new Sqlite();
        string query;
        public Query()
        {
            InitializeComponent();
        }

        private void btn_execute_query_Click(object sender, EventArgs e)
        {
            query = rtxb_query_dgv.Text;
            try
            {
                db.LoadDataToGradeView(dgv_query, query);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_export_Click(object sender, EventArgs e)
        {
            export();
        }

        private void export()
        {

            Excel._Application app = new Excel.Application();
            Excel.Workbook workBook = app.Workbooks.Add();
            Excel.Worksheet workSheet = null;


            //WorkSheet Repport Details
            workSheet = workBook.Worksheets[1];
            workSheet = workBook.ActiveSheet;
            workSheet.Name = "Query";


            for (int i = 1; i < dgv_query.ColumnCount + 1; i++)
            {
                workSheet.Cells[1, i] = dgv_query.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dgv_query.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_query.Columns.Count; j++)
                {
                    var value = dgv_query.Rows[i].Cells[j].Value;
                    workSheet.Cells[i + 2, j + 1] = value;
                }
            }
   
            //Save the Repport
            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Query Result";
            saveFileDialoge.DefaultExt = ".xlsx";

            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workBook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing);
            }
            app.Quit();
            this.Close();
        }

        private void btn_execute_query_Click_1(object sender, EventArgs e)
        {
            query = rtxb_query.Text;
            try
            {
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
