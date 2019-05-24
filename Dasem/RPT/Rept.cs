using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DasemBeniSanssen.RPT
{
    public partial class Rept : Form
    {
        TicketDataSet TDS = new TicketDataSet();

        public Rept()
        {
            InitializeComponent();
        }
        private void Rept_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("TicketDataSet", TDS.Tables[0]);
            reportViewer1.LocalReport.ReportPath = "Report.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();                
        }

        public void setTicketDataSet(TicketDataSet TDS)
        {
            this.TDS = TDS;
        }  
    }
}
