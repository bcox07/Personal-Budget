namespace Personal_Budget
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.personalBudgetLbl = new System.Windows.Forms.Label();
            this.paymentBtn = new System.Windows.Forms.Button();
            this.incomeBtn = new System.Windows.Forms.Button();
            this.statsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personalBudgetLbl
            // 
            this.personalBudgetLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.personalBudgetLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.personalBudgetLbl.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalBudgetLbl.ForeColor = System.Drawing.Color.White;
            this.personalBudgetLbl.Location = new System.Drawing.Point(12, 16);
            this.personalBudgetLbl.Name = "personalBudgetLbl";
            this.personalBudgetLbl.Size = new System.Drawing.Size(412, 136);
            this.personalBudgetLbl.TabIndex = 0;
            this.personalBudgetLbl.Text = "PERSONAL BUDGET";
            this.personalBudgetLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentBtn
            // 
            this.paymentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paymentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paymentBtn.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.paymentBtn.Location = new System.Drawing.Point(12, 159);
            this.paymentBtn.Name = "paymentBtn";
            this.paymentBtn.Size = new System.Drawing.Size(412, 83);
            this.paymentBtn.TabIndex = 2;
            this.paymentBtn.Text = "PAYMENTS";
            this.paymentBtn.UseVisualStyleBackColor = false;
            this.paymentBtn.Click += new System.EventHandler(this.paymentBtn_Click);
            // 
            // incomeBtn
            // 
            this.incomeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.incomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.incomeBtn.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incomeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.incomeBtn.Location = new System.Drawing.Point(12, 248);
            this.incomeBtn.Name = "incomeBtn";
            this.incomeBtn.Size = new System.Drawing.Size(412, 83);
            this.incomeBtn.TabIndex = 3;
            this.incomeBtn.Text = "INCOME\r\n";
            this.incomeBtn.UseVisualStyleBackColor = false;
            this.incomeBtn.Click += new System.EventHandler(this.incomeBtn_Click);
            // 
            // statsBtn
            // 
            this.statsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.statsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statsBtn.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.statsBtn.Location = new System.Drawing.Point(12, 337);
            this.statsBtn.Name = "statsBtn";
            this.statsBtn.Size = new System.Drawing.Size(412, 83);
            this.statsBtn.TabIndex = 4;
            this.statsBtn.Text = "STATISTICS";
            this.statsBtn.UseVisualStyleBackColor = false;
            this.statsBtn.Click += new System.EventHandler(this.statsBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(436, 432);
            this.Controls.Add(this.statsBtn);
            this.Controls.Add(this.incomeBtn);
            this.Controls.Add(this.paymentBtn);
            this.Controls.Add(this.personalBudgetLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label personalBudgetLbl;
        private System.Windows.Forms.Button paymentBtn;
        private System.Windows.Forms.Button incomeBtn;
        private System.Windows.Forms.Button statsBtn;
    }
}