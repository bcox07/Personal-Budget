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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsWindow));
            this.categoryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.categoryBtn = new System.Windows.Forms.Button();
            this.monthBtn = new System.Windows.Forms.Button();
            this.paidToBtn = new System.Windows.Forms.Button();
            this.monthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.paidToChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.paidFromBtn = new System.Windows.Forms.Button();
            this.paidFromChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monthChooser = new System.Windows.Forms.ComboBox();
            this.yearChooser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.categoryChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidToChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidFromChart)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryChart
            // 
            this.categoryChart.BackColor = System.Drawing.Color.Transparent;
            this.categoryChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.categoryChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.categoryChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.categoryChart.ChartAreas.Add(chartArea1);
            this.categoryChart.IsSoftShadows = false;
            this.categoryChart.Location = new System.Drawing.Point(309, -50);
            this.categoryChart.Name = "categoryChart";
            this.categoryChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.categoryChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(156)))), ((int)(((byte)(80))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(181)))), ((int)(((byte)(106))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(206)))), ((int)(((byte)(155))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(189)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Name = "Series1";
            this.categoryChart.Series.Add(series1);
            this.categoryChart.Size = new System.Drawing.Size(2304, 1480);
            this.categoryChart.TabIndex = 0;
            this.categoryChart.Text = "chart1";
            // 
            // categoryBtn
            // 
            this.categoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.categoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categoryBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.categoryBtn.Location = new System.Drawing.Point(32, 42);
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
            this.monthBtn.Location = new System.Drawing.Point(32, 179);
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
            // monthChart
            // 
            this.monthChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.monthChart.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.monthChart.Legends.Add(legend1);
            this.monthChart.Location = new System.Drawing.Point(247, -12);
            this.monthChart.Name = "monthChart";
            this.monthChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.monthChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DeepSkyBlue};
            this.monthChart.Size = new System.Drawing.Size(2345, 1416);
            this.monthChart.TabIndex = 5;
            this.monthChart.Text = "chart1";
            // 
            // paidToChart
            // 
            this.paidToChart.BackColor = System.Drawing.Color.Transparent;
            this.paidToChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.paidToChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.paidToChart.BorderlineWidth = 5;
            chartArea3.Name = "ChartArea1";
            this.paidToChart.ChartAreas.Add(chartArea3);
            this.paidToChart.Location = new System.Drawing.Point(309, -49);
            this.paidToChart.Name = "paidToChart";
            this.paidToChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.paidToChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(156)))), ((int)(((byte)(80))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(181)))), ((int)(((byte)(106))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195)))))};
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Name = "Series1";
            this.paidToChart.Series.Add(series2);
            this.paidToChart.Size = new System.Drawing.Size(2304, 1480);
            this.paidToChart.TabIndex = 6;
            this.paidToChart.Text = "chart1";
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
            // paidFromChart
            // 
            this.paidFromChart.BackColor = System.Drawing.Color.Transparent;
            this.paidFromChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.paidFromChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.paidFromChart.BorderlineWidth = 5;
            chartArea4.Name = "ChartArea1";
            this.paidFromChart.ChartAreas.Add(chartArea4);
            this.paidFromChart.Location = new System.Drawing.Point(309, -49);
            this.paidFromChart.Name = "paidFromChart";
            this.paidFromChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.paidFromChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(156)))), ((int)(((byte)(80))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(181)))), ((int)(((byte)(106))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195)))))};
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Name = "Series1";
            this.paidFromChart.Series.Add(series3);
            this.paidFromChart.Size = new System.Drawing.Size(2304, 1480);
            this.paidFromChart.TabIndex = 10;
            this.paidFromChart.Text = "chart1";
            // 
            // monthChooser
            // 
            this.monthChooser.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthChooser.FormattingEnabled = true;
            this.monthChooser.Location = new System.Drawing.Point(1370, 661);
            this.monthChooser.Name = "monthChooser";
            this.monthChooser.Size = new System.Drawing.Size(189, 49);
            this.monthChooser.TabIndex = 11;
            this.monthChooser.SelectedIndexChanged += new System.EventHandler(this.monthChooser_SelectedIndexChanged);
            // 
            // yearChooser
            // 
            this.yearChooser.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearChooser.FormattingEnabled = true;
            this.yearChooser.Location = new System.Drawing.Point(1285, 12);
            this.yearChooser.Name = "yearChooser";
            this.yearChooser.Size = new System.Drawing.Size(189, 49);
            this.yearChooser.TabIndex = 12;
            this.yearChooser.SelectedIndexChanged += new System.EventHandler(this.yearChooser_SelectedIndexChanged_1);
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
            this.Controls.Add(this.categoryChart);
            this.Controls.Add(this.paidToChart);
            this.Controls.Add(this.paidFromChart);
            this.Controls.Add(this.monthChart);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidToChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paidFromChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart categoryChart;
        private System.Windows.Forms.Button categoryBtn;
        private System.Windows.Forms.Button monthBtn;
        private System.Windows.Forms.Button paidToBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart monthChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart paidToChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button paidFromBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart paidFromChart;
        private System.Windows.Forms.ComboBox monthChooser;
        private System.Windows.Forms.ComboBox yearChooser;
    }
}