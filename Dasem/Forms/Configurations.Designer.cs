namespace DasemBeniSanssen.Forms
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_annuler = new System.Windows.Forms.Button();
            this.cb_save_matricule = new System.Windows.Forms.CheckBox();
            this.cb_show_splash_dgv = new System.Windows.Forms.CheckBox();
            this.cb_auto_matricule = new System.Windows.Forms.CheckBox();
            this.cb_login_validation = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_observ = new System.Windows.Forms.CheckBox();
            this.cb_total_espece = new System.Windows.Forms.CheckBox();
            this.cb_total = new System.Windows.Forms.CheckBox();
            this.cb_total_credit = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(66, 433);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(88, 26);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_annuler
            // 
            this.btn_annuler.Location = new System.Drawing.Point(161, 433);
            this.btn_annuler.Margin = new System.Windows.Forms.Padding(4);
            this.btn_annuler.Name = "btn_annuler";
            this.btn_annuler.Size = new System.Drawing.Size(88, 26);
            this.btn_annuler.TabIndex = 1;
            this.btn_annuler.Text = "Annuler";
            this.btn_annuler.UseVisualStyleBackColor = true;
            this.btn_annuler.Click += new System.EventHandler(this.btn_annuler_Click);
            // 
            // cb_save_matricule
            // 
            this.cb_save_matricule.AutoSize = true;
            this.cb_save_matricule.Location = new System.Drawing.Point(6, 39);
            this.cb_save_matricule.Margin = new System.Windows.Forms.Padding(4);
            this.cb_save_matricule.Name = "cb_save_matricule";
            this.cb_save_matricule.Size = new System.Drawing.Size(168, 19);
            this.cb_save_matricule.TabIndex = 3;
            this.cb_save_matricule.Text = "auto mise à jour matricule";
            this.cb_save_matricule.UseVisualStyleBackColor = true;
            // 
            // cb_show_splash_dgv
            // 
            this.cb_show_splash_dgv.AutoSize = true;
            this.cb_show_splash_dgv.Location = new System.Drawing.Point(41, 41);
            this.cb_show_splash_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.cb_show_splash_dgv.Name = "cb_show_splash_dgv";
            this.cb_show_splash_dgv.Size = new System.Drawing.Size(181, 19);
            this.cb_show_splash_dgv.TabIndex = 7;
            this.cb_show_splash_dgv.Text = "Afficher le journale de pesee";
            this.cb_show_splash_dgv.UseVisualStyleBackColor = true;
            // 
            // cb_auto_matricule
            // 
            this.cb_auto_matricule.AutoSize = true;
            this.cb_auto_matricule.Location = new System.Drawing.Point(7, 66);
            this.cb_auto_matricule.Margin = new System.Windows.Forms.Padding(4);
            this.cb_auto_matricule.Name = "cb_auto_matricule";
            this.cb_auto_matricule.Size = new System.Drawing.Size(154, 19);
            this.cb_auto_matricule.TabIndex = 5;
            this.cb_auto_matricule.Text = "auto complite matricule";
            this.cb_auto_matricule.UseVisualStyleBackColor = true;
            // 
            // cb_login_validation
            // 
            this.cb_login_validation.AutoSize = true;
            this.cb_login_validation.Location = new System.Drawing.Point(41, 68);
            this.cb_login_validation.Margin = new System.Windows.Forms.Padding(4);
            this.cb_login_validation.Name = "cb_login_validation";
            this.cb_login_validation.Size = new System.Drawing.Size(168, 19);
            this.cb_login_validation.TabIndex = 8;
            this.cb_login_validation.Text = "validation de la connexion";
            this.cb_login_validation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_auto_matricule);
            this.groupBox1.Controls.Add(this.cb_save_matricule);
            this.groupBox1.Location = new System.Drawing.Point(66, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(182, 113);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_show_splash_dgv);
            this.groupBox3.Controls.Add(this.cb_login_validation);
            this.groupBox3.Location = new System.Drawing.Point(29, 302);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(255, 113);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Autre";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_observ);
            this.groupBox4.Controls.Add(this.cb_total_espece);
            this.groupBox4.Controls.Add(this.cb_total);
            this.groupBox4.Controls.Add(this.cb_total_credit);
            this.groupBox4.Location = new System.Drawing.Point(50, 154);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(206, 140);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rapport";
            // 
            // cb_observ
            // 
            this.cb_observ.AutoSize = true;
            this.cb_observ.Location = new System.Drawing.Point(43, 107);
            this.cb_observ.Margin = new System.Windows.Forms.Padding(4);
            this.cb_observ.Name = "cb_observ";
            this.cb_observ.Size = new System.Drawing.Size(157, 19);
            this.cb_observ.TabIndex = 10;
            this.cb_observ.Text = "Ajouter les Observations";
            this.cb_observ.UseVisualStyleBackColor = true;
            // 
            // cb_total_espece
            // 
            this.cb_total_espece.AutoSize = true;
            this.cb_total_espece.Location = new System.Drawing.Point(43, 80);
            this.cb_total_espece.Margin = new System.Windows.Forms.Padding(4);
            this.cb_total_espece.Name = "cb_total_espece";
            this.cb_total_espece.Size = new System.Drawing.Size(138, 19);
            this.cb_total_espece.TabIndex = 9;
            this.cb_total_espece.Text = "Ajouter Total Espece";
            this.cb_total_espece.UseVisualStyleBackColor = true;
            // 
            // cb_total
            // 
            this.cb_total.AutoSize = true;
            this.cb_total.Location = new System.Drawing.Point(43, 26);
            this.cb_total.Margin = new System.Windows.Forms.Padding(4);
            this.cb_total.Name = "cb_total";
            this.cb_total.Size = new System.Drawing.Size(94, 19);
            this.cb_total.TabIndex = 7;
            this.cb_total.Text = "Ajouter Total";
            this.cb_total.UseVisualStyleBackColor = true;
            // 
            // cb_total_credit
            // 
            this.cb_total_credit.AutoSize = true;
            this.cb_total_credit.Location = new System.Drawing.Point(43, 53);
            this.cb_total_credit.Margin = new System.Windows.Forms.Padding(4);
            this.cb_total_credit.Name = "cb_total_credit";
            this.cb_total_credit.Size = new System.Drawing.Size(129, 19);
            this.cb_total_credit.TabIndex = 8;
            this.cb_total_credit.Text = "Ajouter Total Credit";
            this.cb_total_credit.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 472);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_annuler);
            this.Controls.Add(this.btn_save);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_annuler;
        private System.Windows.Forms.CheckBox cb_save_matricule;
        private System.Windows.Forms.CheckBox cb_show_splash_dgv;
        private System.Windows.Forms.CheckBox cb_auto_matricule;
        private System.Windows.Forms.CheckBox cb_login_validation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cb_total_espece;
        private System.Windows.Forms.CheckBox cb_total;
        private System.Windows.Forms.CheckBox cb_total_credit;
        private System.Windows.Forms.CheckBox cb_observ;
    }
}