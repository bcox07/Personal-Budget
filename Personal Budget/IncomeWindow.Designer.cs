namespace Personal_Budget
{
    partial class IncomeWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeWindow));
            this.dateLbl = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.IDLbl = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.paymentLbl = new System.Windows.Forms.Label();
            this.paidFromLbl = new System.Windows.Forms.Label();
            this.transactionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.paymentBox = new System.Windows.Forms.TextBox();
            this.incomeGridView = new System.Windows.Forms.DataGridView();
            this.transactionBtn = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.recipientBox = new System.Windows.Forms.ComboBox();
            this.categoryLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.incomeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.dateLbl.Location = new System.Drawing.Point(76, 239);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(76, 31);
            this.dateLbl.TabIndex = 31;
            this.dateLbl.Text = "Date";
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.deleteBtn.Location = new System.Drawing.Point(175, 364);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(211, 70);
            this.deleteBtn.TabIndex = 29;
            this.deleteBtn.Text = "DELETE";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // IDLbl
            // 
            this.IDLbl.AutoSize = true;
            this.IDLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.IDLbl.Location = new System.Drawing.Point(5, 35);
            this.IDLbl.Name = "IDLbl";
            this.IDLbl.Size = new System.Drawing.Size(147, 31);
            this.IDLbl.TabIndex = 28;
            this.IDLbl.Text = "Income ID";
            // 
            // IDBox
            // 
            this.IDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDBox.Location = new System.Drawing.Point(159, 35);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(216, 31);
            this.IDBox.TabIndex = 27;
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.updateBtn.Location = new System.Drawing.Point(176, 288);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(210, 70);
            this.updateBtn.TabIndex = 26;
            this.updateBtn.Text = "UPDATE";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // paymentLbl
            // 
            this.paymentLbl.AutoSize = true;
            this.paymentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paymentLbl.Location = new System.Drawing.Point(24, 192);
            this.paymentLbl.Name = "paymentLbl";
            this.paymentLbl.Size = new System.Drawing.Size(128, 31);
            this.paymentLbl.TabIndex = 25;
            this.paymentLbl.Text = "Payment";
            // 
            // paidFromLbl
            // 
            this.paidFromLbl.AutoSize = true;
            this.paidFromLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paidFromLbl.Location = new System.Drawing.Point(6, 139);
            this.paidFromLbl.Name = "paidFromLbl";
            this.paidFromLbl.Size = new System.Drawing.Size(147, 31);
            this.paidFromLbl.TabIndex = 24;
            this.paidFromLbl.Text = "Paid From";
            // 
            // transactionDatePicker
            // 
            this.transactionDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionDatePicker.Location = new System.Drawing.Point(159, 240);
            this.transactionDatePicker.Name = "transactionDatePicker";
            this.transactionDatePicker.Size = new System.Drawing.Size(216, 31);
            this.transactionDatePicker.TabIndex = 23;
            // 
            // paymentBox
            // 
            this.paymentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBox.Location = new System.Drawing.Point(159, 192);
            this.paymentBox.Name = "paymentBox";
            this.paymentBox.Size = new System.Drawing.Size(216, 31);
            this.paymentBox.TabIndex = 22;
            // 
            // incomeGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(221)))), ((int)(((byte)(219)))));
            this.incomeGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.incomeGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.incomeGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.incomeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.incomeGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.incomeGridView.Location = new System.Drawing.Point(392, 12);
            this.incomeGridView.Name = "incomeGridView";
            this.incomeGridView.Size = new System.Drawing.Size(490, 422);
            this.incomeGridView.TabIndex = 20;
            this.incomeGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.incomeGridView_CellClick);
            // 
            // transactionBtn
            // 
            this.transactionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.transactionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.transactionBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.transactionBtn.Location = new System.Drawing.Point(11, 288);
            this.transactionBtn.Name = "transactionBtn";
            this.transactionBtn.Size = new System.Drawing.Size(159, 70);
            this.transactionBtn.TabIndex = 19;
            this.transactionBtn.Text = "ADD";
            this.transactionBtn.UseVisualStyleBackColor = false;
            this.transactionBtn.Click += new System.EventHandler(this.transactionBtn_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backButton.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.backButton.Location = new System.Drawing.Point(12, 364);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(158, 70);
            this.backButton.TabIndex = 32;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // categoryBox
            // 
            this.categoryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(159, 85);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(216, 33);
            this.categoryBox.TabIndex = 33;
            this.categoryBox.SelectedIndexChanged += new System.EventHandler(this.categoryBox_SelectedIndexChanged);
            // 
            // recipientBox
            // 
            this.recipientBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientBox.FormattingEnabled = true;
            this.recipientBox.Location = new System.Drawing.Point(159, 139);
            this.recipientBox.Name = "recipientBox";
            this.recipientBox.Size = new System.Drawing.Size(216, 33);
            this.recipientBox.TabIndex = 34;
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.categoryLbl.Location = new System.Drawing.Point(19, 85);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(133, 31);
            this.categoryLbl.TabIndex = 35;
            this.categoryLbl.Text = "Category";
            // 
            // IncomeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(898, 449);
            this.ControlBox = false;
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.recipientBox);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.IDLbl);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.paymentLbl);
            this.Controls.Add(this.paidFromLbl);
            this.Controls.Add(this.transactionDatePicker);
            this.Controls.Add(this.paymentBox);
            this.Controls.Add(this.incomeGridView);
            this.Controls.Add(this.transactionBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncomeWindow";
            this.Text = "Income";
            this.Load += new System.EventHandler(this.IncomeWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incomeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label IDLbl;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label paymentLbl;
        private System.Windows.Forms.Label paidFromLbl;
        private System.Windows.Forms.DateTimePicker transactionDatePicker;
        private System.Windows.Forms.TextBox paymentBox;
        private System.Windows.Forms.DataGridView incomeGridView;
        private System.Windows.Forms.Button transactionBtn;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.ComboBox recipientBox;
        private System.Windows.Forms.Label categoryLbl;
    }
}