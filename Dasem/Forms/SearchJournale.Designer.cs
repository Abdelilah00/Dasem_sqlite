namespace DasemBeniSanssen.Forms
{
    partial class SearchJournale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchJournale));
            this.dgv_journal = new System.Windows.Forms.DataGridView();
            this.btn_print_ticket = new System.Windows.Forms.Button();
            this.btn_search_ticket = new System.Windows.Forms.Button();
            this.txb_id_ticket = new System.Windows.Forms.TextBox();
            this.txb_matricule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_update_ticket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_journal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_journal
            // 
            this.dgv_journal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_journal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_journal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_journal.Location = new System.Drawing.Point(12, 125);
            this.dgv_journal.MultiSelect = false;
            this.dgv_journal.Name = "dgv_journal";
            this.dgv_journal.ReadOnly = true;
            this.dgv_journal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_journal.Size = new System.Drawing.Size(901, 328);
            this.dgv_journal.TabIndex = 0;
            this.dgv_journal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_journal_CellClick);
            this.dgv_journal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_journal_KeyUp);
            // 
            // btn_print_ticket
            // 
            this.btn_print_ticket.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_print_ticket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print_ticket.Location = new System.Drawing.Point(373, 459);
            this.btn_print_ticket.Name = "btn_print_ticket";
            this.btn_print_ticket.Size = new System.Drawing.Size(75, 23);
            this.btn_print_ticket.TabIndex = 1;
            this.btn_print_ticket.Text = "Imprimer";
            this.btn_print_ticket.UseVisualStyleBackColor = true;
            this.btn_print_ticket.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_search_ticket
            // 
            this.btn_search_ticket.Location = new System.Drawing.Point(163, 78);
            this.btn_search_ticket.Name = "btn_search_ticket";
            this.btn_search_ticket.Size = new System.Drawing.Size(89, 23);
            this.btn_search_ticket.TabIndex = 2;
            this.btn_search_ticket.Text = "Rehercher";
            this.btn_search_ticket.UseVisualStyleBackColor = true;
            this.btn_search_ticket.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txb_id_ticket
            // 
            this.txb_id_ticket.Location = new System.Drawing.Point(108, 17);
            this.txb_id_ticket.Name = "txb_id_ticket";
            this.txb_id_ticket.Size = new System.Drawing.Size(100, 20);
            this.txb_id_ticket.TabIndex = 3;
            // 
            // txb_matricule
            // 
            this.txb_matricule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txb_matricule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txb_matricule.Location = new System.Drawing.Point(108, 43);
            this.txb_matricule.Name = "txb_matricule";
            this.txb_matricule.Size = new System.Drawing.Size(100, 20);
            this.txb_matricule.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "N° PESEE :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Matricule :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(247, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(247, 43);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "à :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "De :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_search_ticket);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_matricule);
            this.groupBox1.Controls.Add(this.txb_id_ticket);
            this.groupBox1.Location = new System.Drawing.Point(268, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 107);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket";
            // 
            // btn_update_ticket
            // 
            this.btn_update_ticket.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_update_ticket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_update_ticket.Location = new System.Drawing.Point(454, 459);
            this.btn_update_ticket.Name = "btn_update_ticket";
            this.btn_update_ticket.Size = new System.Drawing.Size(75, 23);
            this.btn_update_ticket.TabIndex = 12;
            this.btn_update_ticket.Text = "Mise à Jour";
            this.btn_update_ticket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update_ticket.UseVisualStyleBackColor = true;
            this.btn_update_ticket.Click += new System.EventHandler(this.btn_update_ticket_Click);
            // 
            // SearchJournale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(925, 488);
            this.Controls.Add(this.btn_update_ticket);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_print_ticket);
            this.Controls.Add(this.dgv_journal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(941, 512);
            this.Name = "SearchJournale";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Journale De Pesee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchJournale_FormClosed);
            this.Load += new System.EventHandler(this.SearchJournale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_journal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_journal;
        private System.Windows.Forms.Button btn_print_ticket;
        private System.Windows.Forms.Button btn_search_ticket;
        private System.Windows.Forms.TextBox txb_id_ticket;
        private System.Windows.Forms.TextBox txb_matricule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_update_ticket;
    }
}