namespace Personal_Budget
{
    partial class StatsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsWindow));
            this.categoryBtn = new System.Windows.Forms.Button();
            this.monthBtn = new System.Windows.Forms.Button();
            this.paidToBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.paidFromBtn = new System.Windows.Forms.Button();
            this.monthChooser = new System.Windows.Forms.ComboBox();
            this.yearChooser = new System.Windows.Forms.ComboBox();
            this.monthChart = new System.Windows.Forms.Integration.ElementHost();
            this.monthLiveChart = new LiveCharts.Wpf.CartesianChart();
            this.categoryChart1 = new System.Windows.Forms.Integration.ElementHost();
            this.categoryLiveChart = new LiveCharts.Wpf.PieChart();
            this.incomeChart1 = new System.Windows.Forms.Integration.ElementHost();
            this.incomeLiveChart = new LiveCharts.Wpf.PieChart();
            this.paymentChart1 = new System.Windows.Forms.Integration.ElementHost();
            this.paymentLiveChart = new LiveCharts.Wpf.PieChart();
            this.SuspendLayout();
            // 
            // categoryBtn
            // 
            this.categoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.categoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categoryBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.categoryBtn.Location = new System.Drawing.Point(34, 42);
            this.categoryBtn.Name = "categoryBtn";
            this.categoryBtn.Size = new System.Drawing.Size(283, 90);
            this.categoryBtn.TabIndex = 1;
            this.categoryBtn.Text = "CATEGORY";
            this.categoryBtn.UseVisualStyleBackColor = false;
            this.categoryBtn.Click += new System.EventHandler(this.categoryBtn_Click);
            // 
            // monthBtn
            // 
            this.monthBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.monthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.monthBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.monthBtn.Location = new System.Drawing.Point(34, 178);
            this.monthBtn.Name = "monthBtn";
            this.monthBtn.Size = new System.Drawing.Size(283, 90);
            this.monthBtn.TabIndex = 3;
            this.monthBtn.Text = "MONTHLY";
            this.monthBtn.UseVisualStyleBackColor = false;
            this.monthBtn.Click += new System.EventHandler(this.monthBtn_Click);
            // 
            // paidToBtn
            // 
            this.paidToBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paidToBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paidToBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paidToBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidToBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.paidToBtn.Location = new System.Drawing.Point(34, 322);
            this.paidToBtn.Name = "paidToBtn";
            this.paidToBtn.Size = new System.Drawing.Size(283, 90);
            this.paidToBtn.TabIndex = 4;
            this.paidToBtn.Text = "PAYMENTS";
            this.paidToBtn.UseVisualStyleBackColor = false;
            this.paidToBtn.Click += new System.EventHandler(this.paidToBtn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(319, -38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2229, 1443);
            this.label1.TabIndex = 7;
            this.label1.Text = "Click A Button To Display Stats";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.backBtn.Location = new System.Drawing.Point(36, 1229);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(281, 120);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // paidFromBtn
            // 
            this.paidFromBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.paidFromBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paidFromBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.paidFromBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidFromBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.paidFromBtn.Location = new System.Drawing.Point(34, 472);
            this.paidFromBtn.Name = "paidFromBtn";
            this.paidFromBtn.Size = new System.Drawing.Size(283, 90);
            this.paidFromBtn.TabIndex = 9;
            this.paidFromBtn.Text = "INCOME";
            this.paidFromBtn.UseVisualStyleBackColor = false;
            this.paidFromBtn.Click += new System.EventHandler(this.paidFromBtn_Click);
            // 
            // monthChooser
            // 
            this.monthChooser.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthChooser.FormattingEnabled = true;
            this.monthChooser.Location = new System.Drawing.Point(1330, 680);
            this.monthChooser.Name = "monthChooser";
            this.monthChooser.Size = new System.Drawing.Size(189, 49);
            this.monthChooser.TabIndex = 11;
            this.monthChooser.SelectedIndexChanged += new System.EventHandler(this.monthChooser_SelectedIndexChanged);
            // 
            // yearChooser
            // 
            this.yearChooser.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearChooser.FormattingEnabled = true;
            this.yearChooser.Location = new System.Drawing.Point(1818, 81);
            this.yearChooser.Name = "yearChooser";
            this.yearChooser.Size = new System.Drawing.Size(189, 49);
            this.yearChooser.TabIndex = 12;
            this.yearChooser.SelectedIndexChanged += new System.EventHandler(this.yearChooser_SelectedIndexChanged_1);
            // 
            // monthChart
            // 
            this.monthChart.Location = new System.Drawing.Point(377, 22);
            this.monthChart.Name = "monthChart";
            this.monthChart.Size = new System.Drawing.Size(2171, 1313);
            this.monthChart.TabIndex = 13;
            this.monthChart.Text = "elementHost1";
            this.monthChart.Child = this.monthLiveChart;
            // 
            // categoryChart1
            // 
            this.categoryChart1.Location = new System.Drawing.Point(703, 22);
            this.categoryChart1.Name = "categoryChart1";
            this.categoryChart1.Size = new System.Drawing.Size(1521, 1340);
            this.categoryChart1.TabIndex = 14;
            this.categoryChart1.Text = "elementHost1";
            this.categoryChart1.Child = this.categoryLiveChart;
            // 
            // incomeChart1
            // 
            this.incomeChart1.Location = new System.Drawing.Point(703, 22);
            this.incomeChart1.Name = "incomeChart1";
            this.incomeChart1.Size = new System.Drawing.Size(1521, 1340);
            this.incomeChart1.TabIndex = 15;
            this.incomeChart1.Text = "elementHost2";
            this.incomeChart1.Child = this.incomeLiveChart;
            // 
            // paymentChart1
            // 
            this.paymentChart1.Location = new System.Drawing.Point(703, 22);
            this.paymentChart1.Name = "paymentChart1";
            this.paymentChart1.Size = new System.Drawing.Size(1521, 1340);
            this.paymentChart1.TabIndex = 16;
            this.paymentChart1.Text = "elementHost3";
            this.paymentChart1.Child = this.paymentLiveChart;
            // 
            // StatsWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(2544, 1401);
            this.ControlBox = false;
            this.Controls.Add(this.yearChooser);
            this.Controls.Add(this.monthChooser);
            this.Controls.Add(this.paidFromBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.paidToBtn);
            this.Controls.Add(this.monthBtn);
            this.Controls.Add(this.categoryBtn);
            this.Controls.Add(this.paymentChart1);
            this.Controls.Add(this.incomeChart1);
            this.Controls.Add(this.categoryChart1);
            this.Controls.Add(this.monthChart);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatsWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button categoryBtn;
        private System.Windows.Forms.Button monthBtn;
        private System.Windows.Forms.Button paidToBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button paidFromBtn;
        private System.Windows.Forms.ComboBox monthChooser;
        private System.Windows.Forms.ComboBox yearChooser;
        private System.Windows.Forms.Integration.ElementHost monthChart;
        private LiveCharts.Wpf.CartesianChart monthLiveChart;
        private System.Windows.Forms.Integration.ElementHost categoryChart1;
        private LiveCharts.Wpf.PieChart categoryLiveChart;
        private System.Windows.Forms.Integration.ElementHost incomeChart1;
        private System.Windows.Forms.Integration.ElementHost paymentChart1;
        private LiveCharts.Wpf.PieChart paymentLiveChart;
        private LiveCharts.Wpf.PieChart incomeLiveChart;
    }
}