using System;
using System.Drawing;
using System.Windows.Forms;
using DasemBeniSanssen.Classes;

namespace DasemBeniSanssen.Forms
{
    public partial class Login : Form
    {
        Sqlite db = new Sqlite();

        public Login()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            txb_pass_word.PasswordChar = '*';
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (loginIsEmpty() && Properties.Settings.Default.LoginValidation)
            {
                MessageBox.Show("please Complet all records", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (Properties.Settings.Default.LoginValidation && !db.LoginUserSecssfuuly(txb_user.Text, txb_pass_word.Text))
            {
                MessageBox.Show("User or PassWord invalid "+ db.LoginUserSecssfuuly(txb_user.Text, txb_pass_word.Text), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            {
                Forms.Splash splash = new Forms.Splash();
                splash.Show();
                Hide();
            }
        }

        private bool loginIsEmpty()
        {
            if (String.IsNullOrEmpty(txb_user.Text)) return true;
            else if (String.IsNullOrEmpty(txb_pass_word.Text)) return true;
            else return false;
        }

    }
}