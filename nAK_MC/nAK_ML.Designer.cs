namespace nAK_MC
{
    partial class nAK_MC
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.start_btn = new System.Windows.Forms.Button();
            this.AC_Manager = new System.Windows.Forms.ListBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.rmv_btn = new System.Windows.Forms.Button();
            this.sr_cB = new System.Windows.Forms.ComboBox();
            this.startv2_btn = new System.Windows.Forms.Button();
            this.user_tB = new System.Windows.Forms.TextBox();
            this.pw_tB = new System.Windows.Forms.TextBox();
            this.path_tB = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(503, 396);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // AC_Manager
            // 
            this.AC_Manager.FormattingEnabled = true;
            this.AC_Manager.Location = new System.Drawing.Point(12, 12);
            this.AC_Manager.Name = "AC_Manager";
            this.AC_Manager.Size = new System.Drawing.Size(246, 407);
            this.AC_Manager.TabIndex = 1;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(264, 64);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(75, 23);
            this.add_btn.TabIndex = 2;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // rmv_btn
            // 
            this.rmv_btn.Location = new System.Drawing.Point(503, 64);
            this.rmv_btn.Name = "rmv_btn";
            this.rmv_btn.Size = new System.Drawing.Size(75, 23);
            this.rmv_btn.TabIndex = 3;
            this.rmv_btn.Text = "Remove";
            this.rmv_btn.UseVisualStyleBackColor = true;
            this.rmv_btn.Click += new System.EventHandler(this.rmv_btn_Click);
            // 
            // sr_cB
            // 
            this.sr_cB.FormattingEnabled = true;
            this.sr_cB.Items.AddRange(new object[] {
            "US",
            "DE",
            "FR",
            "ES"});
            this.sr_cB.Location = new System.Drawing.Point(476, 12);
            this.sr_cB.Name = "sr_cB";
            this.sr_cB.Size = new System.Drawing.Size(103, 21);
            this.sr_cB.TabIndex = 4;
            this.sr_cB.Text = "Serverselection";
            // 
            // startv2_btn
            // 
            this.startv2_btn.Location = new System.Drawing.Point(503, 367);
            this.startv2_btn.Name = "startv2_btn";
            this.startv2_btn.Size = new System.Drawing.Size(75, 23);
            this.startv2_btn.TabIndex = 5;
            this.startv2_btn.Text = "Start (All)";
            this.startv2_btn.UseVisualStyleBackColor = true;
            this.startv2_btn.Click += new System.EventHandler(this.startv2_btn_Click);
            // 
            // user_tB
            // 
            this.user_tB.Location = new System.Drawing.Point(264, 12);
            this.user_tB.Name = "user_tB";
            this.user_tB.Size = new System.Drawing.Size(100, 20);
            this.user_tB.TabIndex = 6;
            // 
            // pw_tB
            // 
            this.pw_tB.Location = new System.Drawing.Point(370, 12);
            this.pw_tB.Name = "pw_tB";
            this.pw_tB.Size = new System.Drawing.Size(100, 20);
            this.pw_tB.TabIndex = 7;
            // 
            // path_tB
            // 
            this.path_tB.Location = new System.Drawing.Point(264, 38);
            this.path_tB.Name = "path_tB";
            this.path_tB.Size = new System.Drawing.Size(315, 20);
            this.path_tB.TabIndex = 8;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(264, 367);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 9;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Restore";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.restore_btn_Click);
            // 
            // nAK_MC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(588, 425);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.path_tB);
            this.Controls.Add(this.pw_tB);
            this.Controls.Add(this.user_tB);
            this.Controls.Add(this.startv2_btn);
            this.Controls.Add(this.sr_cB);
            this.Controls.Add(this.rmv_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.AC_Manager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nAK_MC";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "nAK_MultiLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.ListBox AC_Manager;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button rmv_btn;
        private System.Windows.Forms.ComboBox sr_cB;
        private System.Windows.Forms.Button startv2_btn;
        private System.Windows.Forms.TextBox user_tB;
        private System.Windows.Forms.TextBox pw_tB;
        private System.Windows.Forms.TextBox path_tB;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button button2;
    }
}

