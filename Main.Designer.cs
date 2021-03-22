namespace OpenHR
{
    partial class Main
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
            this.dgvHrInfo = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDismiss = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lbCity = new System.Windows.Forms.Label();
            this.rtbLogMain = new System.Windows.Forms.RichTextBox();
            this.lbLog = new System.Windows.Forms.Label();
            this.cbDismissed = new System.Windows.Forms.CheckBox();
            this.cbHired = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHrInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHrInfo
            // 
            this.dgvHrInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHrInfo.Location = new System.Drawing.Point(13, 106);
            this.dgvHrInfo.Name = "dgvHrInfo";
            this.dgvHrInfo.Size = new System.Drawing.Size(776, 262);
            this.dgvHrInfo.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Location = new System.Drawing.Point(13, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Aqua;
            this.btnEdit.Location = new System.Drawing.Point(108, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDismiss
            // 
            this.btnDismiss.BackColor = System.Drawing.Color.Red;
            this.btnDismiss.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDismiss.Location = new System.Drawing.Point(207, 13);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(75, 40);
            this.btnDismiss.TabIndex = 3;
            this.btnDismiss.Text = "Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = false;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Yellow;
            this.btnRefresh.Location = new System.Drawing.Point(302, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh / Clear Filter";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(536, 40);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(252, 21);
            this.cmbCity.TabIndex = 6;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(431, 19);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(58, 13);
            this.lbLastName.TabIndex = 8;
            this.lbLastName.Text = "Last Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(536, 13);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(252, 20);
            this.tbLastName.TabIndex = 9;
            this.tbLastName.TextChanged += new System.EventHandler(this.tbLastName_TextChanged);
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(431, 40);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(24, 13);
            this.lbCity.TabIndex = 10;
            this.lbCity.Text = "City";
            // 
            // rtbLogMain
            // 
            this.rtbLogMain.BackColor = System.Drawing.Color.White;
            this.rtbLogMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogMain.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.rtbLogMain.ForeColor = System.Drawing.Color.Red;
            this.rtbLogMain.Location = new System.Drawing.Point(13, 412);
            this.rtbLogMain.Name = "rtbLogMain";
            this.rtbLogMain.ReadOnly = true;
            this.rtbLogMain.Size = new System.Drawing.Size(776, 85);
            this.rtbLogMain.TabIndex = 12;
            this.rtbLogMain.Text = "";
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(13, 393);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(76, 13);
            this.lbLog.TabIndex = 13;
            this.lbLog.Text = "Application log";
            // 
            // cbDismissed
            // 
            this.cbDismissed.AutoSize = true;
            this.cbDismissed.Location = new System.Drawing.Point(536, 67);
            this.cbDismissed.Name = "cbDismissed";
            this.cbDismissed.Size = new System.Drawing.Size(73, 17);
            this.cbDismissed.TabIndex = 14;
            this.cbDismissed.Text = "Dismissed";
            this.cbDismissed.UseVisualStyleBackColor = true;
            this.cbDismissed.CheckedChanged += new System.EventHandler(this.cbDismissed_CheckedChanged);
            // 
            // cbHired
            // 
            this.cbHired.AutoSize = true;
            this.cbHired.Location = new System.Drawing.Point(715, 67);
            this.cbHired.Name = "cbHired";
            this.cbHired.Size = new System.Drawing.Size(51, 17);
            this.cbHired.TabIndex = 15;
            this.cbHired.Text = "Hired";
            this.cbHired.UseVisualStyleBackColor = true;
            this.cbHired.CheckedChanged += new System.EventHandler(this.cbHired_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.cbHired);
            this.Controls.Add(this.cbDismissed);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.rtbLogMain);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDismiss);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvHrInfo);
            this.Name = "Main";
            this.Text = "Employee Information";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHrInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHrInfo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDismiss;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.RichTextBox rtbLogMain;
        private System.Windows.Forms.Label lbLog;
        private System.Windows.Forms.CheckBox cbDismissed;
        private System.Windows.Forms.CheckBox cbHired;
    }
}

