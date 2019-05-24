using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasemBeniSanssen.Classes
{
    class Security
    {
        DateTime currDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        DateTime expDate = Convert.ToDateTime("21/12/2018");
        double leftDays;

        public Security() {
            TimeSpan t = expDate - currDate;
            leftDays = t.TotalDays;
        }

        public void expirationDate()
        {
            if (leftDays > 0)
            {
                if (Properties.Settings.Default.LeftsDays < leftDays)
                {
                    MessageBox.Show("la date est incorrect ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Environment.Exit(Environment.ExitCode);
                }
                MessageBox.Show("il vous reste " + leftDays + " jours", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                Properties.Settings.Default.LeftsDays = leftDays;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Contacter le Développeur", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
