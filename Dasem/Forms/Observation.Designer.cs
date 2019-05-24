namespace DasemBeniSanssen.Forms
{
    partial class Observation
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
            this.txb_id_ticket = new System.Windows.Forms.TextBox();
            this.rtxb_remarque = new System.Windows.Forms.RichTextBox();
            this.bnt_add_to_observation = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_id_ticket
            // 
            this.txb_id_ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_id_ticket.Location = new System.Drawing.Point(99, 19);
            this.txb_id_ticket.Name = "txb_id_ticket";
            this.txb_id_ticket.Size = new System.Drawing.Size(144, 26);
            this.txb_id_ticket.TabIndex = 0;
            // 
            // rtxb_remarque
            // 
            this.rtxb_remarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxb_remarque.Location = new System.Drawing.Point(99, 54);
            this.rtxb_remarque.Name = "rtxb_remarque";
            this.rtxb_remarque.Size = new System.Drawing.Size(360, 113);
            this.rtxb_remarque.TabIndex = 1;
            this.rtxb_remarque.Text = "";
            // 
            // bnt_add_to_observation
            // 
            this.bnt_add_to_observation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt_add_to_observation.Location = new System.Drawing.Point(261, 181);
            this.bnt_add_to_observation.Name = "bnt_add_to_observation";
            this.bnt_add_to_observation.Size = new System.Drawing.Size(87, 33);
            this.bnt_add_to_observation.TabIndex = 2;
            this.bnt_add_to_observation.Text = "Ajouter";
            this.bnt_add_to_observation.UseVisualStyleBackColor = true;
            this.bnt_add_to_observation.Click += new System.EventHandler(this.bnt_add_to_observation_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(155, 181);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(88, 33);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "Annuler";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "N° Ticket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Remarque";
            // 
            // Observation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(475, 226);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.bnt_add_to_observation);
            this.Controls.Add(this.rtxb_remarque);
            this.Controls.Add(this.txb_id_ticket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Observation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Observation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_id_ticket;
        private System.Windows.Forms.RichTextBox rtxb_remarque;
        private System.Windows.Forms.Button bnt_add_to_observation;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}