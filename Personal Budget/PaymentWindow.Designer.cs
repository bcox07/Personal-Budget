namespace Personal_Budget
{
    partial class PaymentWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentWindow));
            this.transactionBtn = new System.Windows.Forms.Button();
            this.budgetGridView = new System.Windows.Forms.DataGridView();
            this.paymentAcctBox = new System.Windows.Forms.TextBox();
            this.paidToBox = new System.Windows.Forms.TextBox();
            this.paymentBox = new System.Windows.Forms.TextBox();
            this.transactionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.accountLabel = new System.Windows.Forms.Label();
            this.paidToLbl = new System.Windows.Forms.Label();
            this.paymentLbl = new System.Windows.Forms.Label();
            this.categoryLbl = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.IDLbl = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dateLbl = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.budgetGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionBtn
            // 
            this.transactionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.transactionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.transactionBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.transactionBtn.Location = new System.Drawing.Point(12, 447);
            this.transactionBtn.Name = "transactionBtn";
            this.transactionBtn.Size = new System.Drawing.Size(215, 70);
            this.transactionBtn.TabIndex = 0;
            this.transactionBtn.Text = "ADD";
            this.transactionBtn.UseVisualStyleBackColor = false;
            this.transactionBtn.Click += new System.EventHandler(this.transactionBtn_Click);
            // 
            // budgetGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(221)))), ((int)(((byte)(219)))));
            this.budgetGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.budgetGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.budgetGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.budgetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.budgetGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.budgetGridView.Location = new System.Drawing.Point(454, 12);
            this.budgetGridView.Name = "budgetGridView";
            this.budgetGridView.Size = new System.Drawing.Size(720, 659);
            this.budgetGridView.TabIndex = 1;
            this.budgetGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.budgetGridView_CellClick);
            // 
            // paymentAcctBox
            // 
            this.paymentAcctBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentAcctBox.Location = new System.Drawing.Point(221, 104);
            this.paymentAcctBox.Name = "paymentAcctBox";
            this.paymentAcctBox.Size = new System.Drawing.Size(222, 31);
            this.paymentAcctBox.TabIndex = 2;
            // 
            // paidToBox
            // 
            this.paidToBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidToBox.Location = new System.Drawing.Point(221, 310);
            this.paidToBox.Name = "paidToBox";
            this.paidToBox.Size = new System.Drawing.Size(222, 31);
            this.paidToBox.TabIndex = 5;
            // 
            // paymentBox
            // 
            this.paymentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBox.Location = new System.Drawing.Point(221, 242);
            this.paymentBox.Name = "paymentBox";
            this.paymentBox.Size = new System.Drawing.Size(222, 31);
            this.paymentBox.TabIndex = 4;
            // 
            // transactionDatePicker
            // 
            this.transactionDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionDatePicker.Location = new System.Drawing.Point(221, 379);
            this.transactionDatePicker.Name = "transactionDatePicker";
            this.transactionDatePicker.Size = new System.Drawing.Size(222, 31);
            this.transactionDatePicker.TabIndex = 6;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.accountLabel.Location = new System.Drawing.Point(95, 104);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(120, 31);
            this.accountLabel.TabIndex = 8;
            this.accountLabel.Text = "Account";
            // 
            // paidToLbl
            // 
            this.paidToLbl.AutoSize = true;
            this.paidToLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidToLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paidToLbl.Location = new System.Drawing.Point(101, 310);
            this.paidToLbl.Name = "paidToLbl";
            this.paidToLbl.Size = new System.Drawing.Size(114, 31);
            this.paidToLbl.TabIndex = 9;
            this.paidToLbl.Text = "Paid To";
            // 
            // paymentLbl
            // 
            this.paymentLbl.AutoSize = true;
            this.paymentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paymentLbl.Location = new System.Drawing.Point(87, 242);
            this.paymentLbl.Name = "paymentLbl";
            this.paymentLbl.Size = new System.Drawing.Size(128, 31);
            this.paymentLbl.TabIndex = 10;
            this.paymentLbl.Text = "Payment";
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.categoryLbl.Location = new System.Drawing.Point(82, 171);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(133, 31);
            this.categoryLbl.TabIndex = 11;
            this.categoryLbl.Text = "Category";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.backBtn.Location = new System.Drawing.Point(12, 600);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(431, 71);
            this.backBtn.TabIndex = 12;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.statsBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.updateBtn.Location = new System.Drawing.Point(233, 447);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(210, 70);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "UPDATE";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // IDLbl
            // 
            this.IDLbl.AutoSize = true;
            this.IDLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.IDLbl.Location = new System.Drawing.Point(12, 35);
            this.IDLbl.Name = "IDLbl";
            this.IDLbl.Size = new System.Drawing.Size(206, 31);
            this.IDLbl.TabIndex = 15;
            this.IDLbl.Text = "Transaction ID";
            // 
            // IDBox
            // 
            this.IDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDBox.Location = new System.Drawing.Point(221, 35);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(222, 31);
            this.IDBox.TabIndex = 14;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.deleteBtn.Location = new System.Drawing.Point(233, 523);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(210, 70);
            this.deleteBtn.TabIndex = 16;
            this.deleteBtn.Text = "DELETE";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.dateLbl.Location = new System.Drawing.Point(139, 379);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(76, 31);
            this.dateLbl.TabIndex = 18;
            this.dateLbl.Text = "Date";
            // 
            // categoryBox
            // 
            this.categoryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Location = new System.Drawing.Point(221, 171);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(222, 33);
            this.categoryBox.TabIndex = 19;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.searchBtn.Location = new System.Drawing.Point(12, 523);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(215, 70);
            this.searchBtn.TabIndex = 20;
            this.searchBtn.Text = "SEARCH";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // PaymentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1187, 683);
            this.ControlBox = false;
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.IDLbl);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.paymentLbl);
            this.Controls.Add(this.paidToLbl);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.transactionDatePicker);
            this.Controls.Add(this.paymentBox);
            this.Controls.Add(this.paidToBox);
            this.Controls.Add(this.paymentAcctBox);
            this.Controls.Add(this.budgetGridView);
            this.Controls.Add(this.transactionBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentWindow";
            this.Text = "Payments";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.budgetGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button transactionBtn;
        private System.Windows.Forms.DataGridView budgetGridView;
        private System.Windows.Forms.TextBox paymentAcctBox;
        private System.Windows.Forms.TextBox paidToBox;
        private System.Windows.Forms.TextBox paymentBox;
        private System.Windows.Forms.DateTimePicker transactionDatePicker;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.Label paidToLbl;
        private System.Windows.Forms.Label paymentLbl;
        private System.Windows.Forms.Label categoryLbl;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label IDLbl;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.Button searchBtn;
    }
}

