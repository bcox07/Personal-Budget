using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Personal_Budget
{
    class ChartCreation
    {
        private static Color autumn = Color.FromArgb(118, 54, 38);
        private static Color mist = Color.FromArgb(144, 175, 197);
        private static Color stone = Color.FromArgb(51, 107, 135);
        public static void FillChart(List<Category> categories, Chart chart, string series)
        {
            chart.Series.Clear();
            chart.Series.Add(series);
            int i = 0;
            foreach (Category category in categories)
            {
                chart.Series[series].Points.AddXY(category.Name, category.Cost);
                chart.Series[series].Points[i].Label = category.Name;
                category.Cost = String.Format("{0:#.00}", Convert.ToDecimal(category.Cost));
                category.Cost = "$" + category.Cost;
                chart.Series[series].Points[i].LegendText = category.Cost;
                chart.Series[series].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                chart.Series[series].LabelForeColor = Color.White;
                chart.Series[series].Points[i].ToolTip = category.Cost;
                i++;
            }

            chart.Series[series].ChartType = SeriesChartType.Doughnut;
            chart.Series[series].IsVisibleInLegend = false;
            chart.BackColor = Color.Transparent;
            chart.ChartAreas[0].BackColor = Color.Transparent;

        }

        public static void FillMonthChart(Chart chart, List<Category> categories, string series)
        {
            int i = 0;
            foreach (Category month in categories)
            {
                chart.Series[series].Points.AddXY(month.Name, month.Cost);
                chart.Series[series].Points[i].Label = month.Cost;
                chart.Series[series].Points[i].Font = new Font("Arial", 12, FontStyle.Bold);
                i++;
            }
        }

        public static void CustomizeMonthChart(Chart chart, String cost, String income, String net)
        {
            chart.Series.Clear();
            chart.Series.Add(cost);
            chart.Series[cost].ChartType = SeriesChartType.Line;
            chart.Series[cost].BorderWidth = 8;
            chart.Series[cost].LabelForeColor = Color.White;
            chart.Series[cost].Color = autumn;

            chart.Series.Add(income);
            chart.Series[income].ChartType = SeriesChartType.Line;
            chart.Series[income].BorderWidth = 8;
            chart.Series[income].Color = Color.FromArgb(146, 156, 80); ;
            chart.Series[income].LabelForeColor = Color.White;

            chart.Series.Add(net);
            chart.Series[net].ChartType = SeriesChartType.Line;
            chart.Series[net].BorderWidth = 8;
            chart.Series[net].Color = mist;
            chart.Series[net].LabelForeColor = Color.White;


            chart.ChartAreas[0].BackColor = stone;

            chart.ChartAreas[0].AxisX.LineColor = mist;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = mist;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 3;
            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = mist;
            chart.ChartAreas[0].AxisX.MajorTickMark.LineWidth = 3;
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = mist;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            chart.ChartAreas[0].AxisY.LineColor = mist;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = mist;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 3;
            chart.ChartAreas[0].AxisY.MajorTickMark.LineColor = mist;
            chart.ChartAreas[0].AxisY.MajorTickMark.LineWidth = 3;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = mist;
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 14, FontStyle.Bold);
        }
    }
}
