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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
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
            chartArea9.Name = "ChartArea1";
            this.categoryChart.ChartAreas.Add(chartArea9);
            this.categoryChart.Location = new System.Drawing.Point(319, 0);
            this.categoryChart.Name = "categoryChart";
            this.categoryChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.categoryChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111)))))};
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Name = "Series1";
            this.categoryChart.Series.Add(series3);
            this.categoryChart.Size = new System.Drawing.Size(811, 806);
            this.categoryChart.TabIndex = 0;
            this.categoryChart.Text = "chart1";
            // 
            // categoryBtn
            // 
            this.categoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.categoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categoryBtn.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.categoryBtn.Location = new System.Drawing.Point(30, 50);
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
            this.monthBtn.Location = new System.Drawing.Point(30, 187);
            this.monthBtn.Name = "monthBtn";
            this.monthBtn.Size = new System.Drawing.Size(283, 90);
            this.monthBtn.TabIndex = 3;
            this.monthBtn.Text = "MONTH";
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
            this.paidToBtn.Location = new System.Drawing.Point(32, 330);
            this.paidToBtn.Name = "paidToBtn";
            this.paidToBtn.Size = new System.Drawing.Size(283, 90);
            this.paidToBtn.TabIndex = 4;
            this.paidToBtn.Text = "PAID TO";
            this.paidToBtn.UseVisualStyleBackColor = false;
            this.paidToBtn.Click += new System.EventHandler(this.paidToBtn_Click);
            // 
            // monthChart
            // 
            this.monthChart.BackColor = System.Drawing.Color.Transparent;
            chartArea10.Name = "ChartArea1";
            this.monthChart.ChartAreas.Add(chartArea10);
            this.monthChart.Location = new System.Drawing.Point(319, 0);
            this.monthChart.Name = "monthChart";
            this.monthChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.monthChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DeepSkyBlue};
            this.monthChart.Size = new System.Drawing.Size(814, 806);
            this.monthChart.TabIndex = 5;
            this.monthChart.Text = "chart1";
            // 
            // paidToChart
            // 
            this.paidToChart.BackColor = System.Drawing.Color.Transparent;
            this.paidToChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.paidToChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.paidToChart.BorderlineWidth = 5;
            chartArea11.Name = "ChartArea1";
            this.paidToChart.ChartAreas.Add(chartArea11);
            legend5.AutoFitMinFontSize = 10;
            legend5.DockedToChartArea = "ChartArea1";
            legend5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.IsTextAutoFit = false;
            legend5.Name = "Legend1";
            this.paidToChart.Legends.Add(legend5);
            this.paidToChart.Location = new System.Drawing.Point(319, 0);
            this.paidToChart.Name = "paidToChart";
            this.paidToChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.paidToChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111)))))};
            this.paidToChart.Size = new System.Drawing.Size(814, 806);
            this.paidToChart.TabIndex = 6;
            this.paidToChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(319, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(804, 782);
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
            this.backBtn.Location = new System.Drawing.Point(32, 633);
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
            this.paidFromBtn.Location = new System.Drawing.Point(32, 468);
            this.paidFromBtn.Name = "paidFromBtn";
            this.paidFromBtn.Size = new System.Drawing.Size(283, 90);
            this.paidFromBtn.TabIndex = 9;
            this.paidFromBtn.Text = "PAID FROM";
            this.paidFromBtn.UseVisualStyleBackColor = false;
            this.paidFromBtn.Click += new System.EventHandler(this.paidFromBtn_Click);
            // 
            // paidFromChart
            // 
            this.paidFromChart.BackColor = System.Drawing.Color.Transparent;
            this.paidFromChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.paidFromChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.paidFromChart.BorderlineWidth = 5;
            chartArea12.Name = "ChartArea1";
            this.paidFromChart.ChartAreas.Add(chartArea12);
            legend6.AutoFitMinFontSize = 10;
            legend6.DockedToChartArea = "ChartArea1";
            legend6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend6.IsTextAutoFit = false;
            legend6.Name = "Legend1";
            this.paidFromChart.Legends.Add(legend6);
            this.paidFromChart.Location = new System.Drawing.Point(319, 0);
            this.paidFromChart.Name = "paidFromChart";
            this.paidFromChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.paidFromChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(71)))), ((int)(((byte)(50))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(88)))), ((int)(((byte)(62))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(122)))), ((int)(((byte)(101))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(179)))), ((int)(((byte)(195))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(157)))), ((int)(((byte)(192))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(132)))), ((int)(((byte)(166))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(88)))), ((int)(((byte)(111)))))};
            this.paidFromChart.Size = new System.Drawing.Size(814, 806);
            this.paidFromChart.TabIndex = 10;
            this.paidFromChart.Text = "chart1";
            // 
            // StatsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1135, 803);
            this.Controls.Add(this.paidFromBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.paidToBtn);
            this.Controls.Add(this.monthBtn);
            this.Controls.Add(this.categoryBtn);
            this.Controls.Add(this.monthChart);
            this.Controls.Add(this.categoryChart);
            this.Controls.Add(this.paidToChart);
            this.Controls.Add(this.paidFromChart);
            this.Controls.Add(this.label1);
            this.Name = "StatsWindow";
            this.Text = "StatsWindow";
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
    }
}