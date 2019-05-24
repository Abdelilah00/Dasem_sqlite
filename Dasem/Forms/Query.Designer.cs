namespace DasemBeniSanssen.Forms
{
    partial class Query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query));
            this.btn_execute_query_dgv = new System.Windows.Forms.Button();
            this.dgv_query = new System.Windows.Forms.DataGridView();
            this.rtxb_query_dgv = new System.Windows.Forms.RichTextBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_execute_query = new System.Windows.Forms.Button();
            this.rtxb_query = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_execute_query_dgv
            // 
            this.btn_execute_query_dgv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_execute_query_dgv.Location = new System.Drawing.Point(151, 114);
            this.btn_execute_query_dgv.Name = "btn_execute_query_dgv";
            this.btn_execute_query_dgv.Size = new System.Drawing.Size(100, 23);
            this.btn_execute_query_dgv.TabIndex = 0;
            this.btn_execute_query_dgv.Text = "Execute Query ";
            this.btn_execute_query_dgv.UseVisualStyleBackColor = true;
            this.btn_execute_query_dgv.Click += new System.EventHandler(this.btn_execute_query_Click);
            // 
            // dgv_query
            // 
            this.dgv_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_query.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_query.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_query.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_query.Location = new System.Drawing.Point(12, 143);
            this.dgv_query.MultiSelect = false;
            this.dgv_query.Name = "dgv_query";
            this.dgv_query.ReadOnly = true;
            this.dgv_query.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_query.Size = new System.Drawing.Size(776, 262);
            this.dgv_query.TabIndex = 2;
            // 
            // rtxb_query_dgv
            // 
            this.rtxb_query_dgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxb_query_dgv.Location = new System.Drawing.Point(12, 12);
            this.rtxb_query_dgv.Name = "rtxb_query_dgv";
            this.rtxb_query_dgv.Size = new System.Drawing.Size(383, 96);
            this.rtxb_query_dgv.TabIndex = 3;
            this.rtxb_query_dgv.Text = "";
            // 
            // btn_export
            // 
            this.btn_export.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_export.Location = new System.Drawing.Point(344, 411);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(100, 23);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_execute_query
            // 
            this.btn_execute_query.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_execute_query.Location = new System.Drawing.Point(554, 114);
            this.btn_execute_query.Name = "btn_execute_query";
            this.btn_execute_query.Size = new System.Drawing.Size(100, 23);
            this.btn_execute_query.TabIndex = 5;
            this.btn_execute_query.Text = "Execute Query";
            this.btn_execute_query.UseVisualStyleBackColor = true;
            this.btn_execute_query.Click += new System.EventHandler(this.btn_execute_query_Click_1);
            // 
            // rtxb_query
            // 
            this.rtxb_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxb_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxb_query.Location = new System.Drawing.Point(405, 12);
            this.rtxb_query.Name = "rtxb_query";
            this.rtxb_query.Size = new System.Drawing.Size(383, 96);
            this.rtxb_query.TabIndex = 6;
            this.rtxb_query.Text = "";
            // 
            // Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.rtxb_query);
            this.Controls.Add(this.btn_execute_query);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.rtxb_query_dgv);
            this.Controls.Add(this.dgv_query);
            this.Controls.Add(this.btn_execute_query_dgv);
            this.MinimumSize = new System.Drawing.Size(816, 483);
            this.Name = "Query";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_execute_query_dgv;
        private System.Windows.Forms.DataGridView dgv_query;
        private System.Windows.Forms.RichTextBox rtxb_query_dgv;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_execute_query;
        private System.Windows.Forms.RichTextBox rtxb_query;
    }
}