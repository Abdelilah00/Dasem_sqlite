using System;
using System.Windows.Forms;

namespace DasemBeniSanssen.Forms
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();

        }


        private void Options_Load(object sender, EventArgs e)
        {
            cb_save_matricule.Checked = Properties.Settings.Default.AutoSaveMatricule ;
            cb_auto_matricule.Checked = Properties.Settings.Default.AutoCompiletMatricule ;
            cb_show_splash_dgv.Checked = Properties.Settings.Default.ShowSplashDGV ;
            cb_login_validation.Checked = Properties.Settings.Default.LoginValidation;
            cb_total.Checked = Properties.Settings.Default.TotalTotal;
            cb_total_credit.Checked = Properties.Settings.Default.TotalCredit;
            cb_total_espece.Checked = Properties.Settings.Default.TotalEspece;
            cb_observ.Checked = Properties.Settings.Default.Observ;
        }


        private void btn_annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSaveMatricule = cb_save_matricule.Checked;
            Properties.Settings.Default.AutoCompiletMatricule = cb_auto_matricule.Checked;
            Properties.Settings.Default.ShowSplashDGV = cb_show_splash_dgv.Checked;
            Properties.Settings.Default.LoginValidation = cb_login_validation.Checked;
            Properties.Settings.Default.TotalTotal = cb_total.Checked;
            Properties.Settings.Default.TotalEspece = cb_total_espece.Checked;
            Properties.Settings.Default.TotalCredit = cb_total_credit.Checked;
            Properties.Settings.Default.Observ = cb_observ.Checked;

            Properties.Settings.Default.Save();
            Close();
        }
    }
}
