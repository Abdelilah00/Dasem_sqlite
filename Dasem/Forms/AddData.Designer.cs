namespace DasemBeniSanssen.Forms
{
    partial class AddData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddData));
            this.cb_config = new System.Windows.Forms.ComboBox();
            this.dgv_config = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_modifier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_config
            // 
            this.cb_config.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cb_config.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_config.FormattingEnabled = true;
            this.cb_config.Items.AddRange(new object[] {
            "Produit",
            "Client",
            "Camion"});
            this.cb_config.Location = new System.Drawing.Point(122, 12);
            this.cb_config.Name = "cb_config";
            this.cb_config.Size = new System.Drawing.Size(203, 23);
            this.cb_config.TabIndex = 0;
            this.cb_config.SelectedIndexChanged += new System.EventHandler(this.cb_config_SelectedIndexChanged);
            // 
            // dgv_config
            // 
            this.dgv_config.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_config.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_config.Location = new System.Drawing.Point(12, 48);
            this.dgv_config.MultiSelect = false;
            this.dgv_config.Name = "dgv_config";
            this.dgv_config.ReadOnly = true;
            this.dgv_config.Size = new System.Drawing.Size(422, 415);
            this.dgv_config.TabIndex = 1;
            this.dgv_config.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_config_CellClick);
            this.dgv_config.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_config_CellDoubleClick);
            this.dgv_config.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_config_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 8;
            // 
            // btn_modifier
            // 
            this.btn_modifier.Location = new System.Drawing.Point(182, 469);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(75, 23);
            this.btn_modifier.TabIndex = 9;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = true;
            this.btn_modifier.Click += new System.EventHandler(this.btn_modifier_Click);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(443, 500);
            this.Controls.Add(this.btn_modifier);
            this.Controls.Add(this.cb_config);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_config);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(459, 514);
            this.Name = "AddData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tables";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_config;
        private System.Windows.Forms.DataGridView dgv_config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_modifier;
    }
}