using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Personal_Budget
{
    public partial class StatsWindow : Form
    {
        static Connection dbConnection = new Connection();
        SqlConnection connection = new SqlConnection(dbConnection.getConnection());

        Boolean categoryCreated, monthCreated, paidToCreated, paidFromCreated;
        public StatsWindow()
        {
            InitializeComponent();
        }

        private void StatsWindow_Load(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = false;
            paidToChart.Visible = false;
            paidFromChart.Visible = false;

            Color autumn = Color.FromArgb(118, 54, 38);
            Color mist = Color.FromArgb(144, 175, 197);
            Color stone = Color.FromArgb(51, 107, 135);

            SqlCommand cmd, cmd2;
            SqlDataReader reader, reader2;

            //Category chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            int numCategories = 0;
            String temp;

            connection.Open();
            cmd = new SqlCommand("SELECT COUNT(DISTINCT Category) AS NumCategories FROM BUDGET", connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            temp = String.Format("{0}", reader["NumCategories"]);
            numCategories = Convert.ToInt32(temp);
            connection.Close();

            String[] category = new string[15];
            String[] categoryCost = new String[numCategories];

            connection.Open();
            cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY Category ORDER BY TotalPayment DESC", connection);
            reader = cmd.ExecuteReader();

            int j = 0;
            while (reader.Read())
            {
                category[j] = String.Format("{0}", reader["Category"]);
                j++;
            }
            connection.Close();

            String categorySeries = "Category";
            categoryChart.Series.Add(categorySeries);
            categoryChart.Series[categorySeries].ChartType = SeriesChartType.Pie;
            categoryChart.Series[categorySeries].IsVisibleInLegend = false;
            categoryChart.BackColor = Color.Transparent;
            categoryChart.ChartAreas[0].BackColor = Color.Transparent;

            for (int i = 0; i < numCategories; i++)
            {
                cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET WHERE CATEGORY = @Category GROUP BY Category ORDER BY TotalPayment DESC", connection);
                cmd.Parameters.AddWithValue("@Category", category[i]);

                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();

                categoryCost[i] = String.Format("{0}", reader["TotalPayment"]);
                connection.Close();


                categoryChart.Series[categorySeries].Points.AddXY(category[i], categoryCost[i]);
                categoryChart.Series[categorySeries].Points[i].Label = category[i];
                categoryCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(categoryCost[i]));
                categoryCost[i] = "$" + categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].LegendText = categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                categoryChart.Series[categorySeries].LabelForeColor = Color.White;
                categoryChart.Series[categorySeries].Points[i].ToolTip = categoryCost[i];
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Month chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            String[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            String[] monthCost = new String[12];
            String[] monthIncome = new String[12];
            String[] net = new String[12];

            String monthPaymentSeries = "Cost";
            String monthIncomeSeries = "Income";
            String netSeries = "Net";


            monthChart.Series.Add(monthPaymentSeries);
            monthChart.Series[monthPaymentSeries].ChartType = SeriesChartType.Line;
            monthChart.Series[monthPaymentSeries].BorderWidth = 8;
            monthChart.Series[monthPaymentSeries].LabelForeColor = Color.White;
            monthChart.Series[monthPaymentSeries].Color = autumn;

            monthChart.Series.Add(monthIncomeSeries);
            monthChart.Series[monthIncomeSeries].ChartType = SeriesChartType.Line;
            monthChart.Series[monthIncomeSeries].BorderWidth = 8;
            monthChart.Series[monthIncomeSeries].Color = stone;
            monthChart.Series[monthIncomeSeries].LabelForeColor = Color.White;

            monthChart.Series.Add(netSeries);
            monthChart.Series[netSeries].ChartType = SeriesChartType.Line;
            monthChart.Series[netSeries].BorderWidth = 8;
            monthChart.Series[netSeries].Color = Color.Gray;
            monthChart.Series[netSeries].LabelForeColor = Color.White;

            monthChart.ChartAreas[0].BackColor = mist;

            int currMonthNum = Convert.ToInt32(DateTime.Now.ToString("MM"));


            for (int i = 0; i < currMonthNum; i++)
            {
                cmd = new SqlCommand("SELECT TransactionMonth, SUM(Payment) AS TotalPayment FROM BUDGET WHERE TransactionMonth = @Month GROUP BY TransactionMonth", connection);
                cmd.Parameters.AddWithValue("@Month", month[i]);

                cmd2 = new SqlCommand("SELECT TransactionMonth, SUM(Payment) AS TotalIncome FROM INCOME WHERE TransactionMonth = @Month GROUP BY TransactionMonth", connection);
                cmd2.Parameters.AddWithValue("@Month", month[i]);

                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();
                try
                {
                    monthCost[i] = String.Format("{0}", reader["TotalPayment"]);
                }
                catch (InvalidOperationException)
                {
                    monthCost[i] = "0";
                }
                connection.Close();

                connection.Open();
                cmd2.ExecuteNonQuery();
                reader2 = cmd2.ExecuteReader();
                reader2.Read();
                try
                {
                    monthIncome[i] = String.Format("{0}", reader2["TotalIncome"]);
                }
                catch (InvalidOperationException)
                {
                    monthIncome[i] = "0";
                }
                connection.Close();

                net[i] = (Convert.ToDouble(monthIncome[i]) - Convert.ToDouble(monthCost[i])).ToString();

                monthChart.Series[monthPaymentSeries].Points.AddXY(month[i], monthCost[i]);
                monthChart.Series[monthIncomeSeries].Points.AddXY(month[i], monthIncome[i]);
                monthChart.Series[netSeries].Points.AddXY(month[i], net[i]);

                monthCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(monthCost[i]));
                monthCost[i] = "$" + monthCost[i];

                monthIncome[i] = String.Format("{0:#.00}", Convert.ToDecimal(monthIncome[i]));
                monthIncome[i] = "$" + monthIncome[i];

                net[i] = String.Format("{0:#.00}", Convert.ToDecimal(net[i]));
                net[i] = "$" + net[i];

                monthChart.Series[monthPaymentSeries].Points[i].Label = monthCost[i];
                monthChart.Series[monthIncomeSeries].Points[i].Label = monthIncome[i];
                monthChart.Series[netSeries].Points[i].Label = net[i];

                monthChart.Series[monthPaymentSeries].Points[i].Font = monthChart.Series[monthIncomeSeries].Points[i].Font = monthChart.Series[netSeries].Points[i].Font = new Font("Arial", 12, FontStyle.Bold);
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            //Create PaidTo chart
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            int numPaidTo = 8;
            String[] paidTo = new string[100];

            connection.Open();
            cmd = new SqlCommand("SELECT TOP 8 PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
            reader = cmd.ExecuteReader();

            j = 0;
            while (reader.Read())
            {
                paidTo[j] = String.Format("{0}", reader["PaidTo"]);
                j++;
            }
            connection.Close();



            String[] paidToCost = new String[numPaidTo];

            String paidToSeries = "Paid To";
            paidToChart.Series.Add(paidToSeries);
            paidToChart.Series[paidToSeries].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            paidToChart.ChartAreas[0].BackColor = Color.Transparent;
            paidToChart.Series[paidToSeries].IsVisibleInLegend = false;

            for (int i = 0; i < numPaidTo; i++)
            {
                cmd = new SqlCommand("SELECT TOP 8 PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET WHERE PaidTo = @PaidTo GROUP BY PaidTo", connection);
                cmd.Parameters.AddWithValue("@PaidTo", paidTo[i]);

                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();

                paidToCost[i] = String.Format("{0}", reader["TotalPayment"]);
                connection.Close();

                paidToChart.Series[paidToSeries].Points.AddXY(paidTo[i], paidToCost[i]);
                paidToChart.Series[paidToSeries].Points[i].Label = paidTo[i];
                paidToCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(paidToCost[i]));
                paidToCost[i] = "$" + paidToCost[i];
                paidToChart.Series[paidToSeries].Points[i].LegendText = paidToCost[i];
                paidToChart.Series[paidToSeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                paidToChart.Series[paidToSeries].LabelForeColor = Color.White;
                paidToChart.Series[paidToSeries].Points[i].ToolTip = paidToCost[i];

            }
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        }
        private void paidToBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = false;
            paidToChart.Visible = true;
            paidFromChart.Visible = false;

            if (paidToCreated == false)
            {
               
            }
            paidToCreated = true;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MainMenu>().Count() == 1)
            {
                Application.OpenForms.OfType<MainMenu>().First().Show();
                this.Close();
            }
            else if (Application.OpenForms.OfType<MainMenu>().Count() > 1)
            {
                Application.OpenForms.OfType<MainMenu>().First().Close();
            }
        }

        private void paidFromBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = false;
            paidToChart.Visible = false;
            paidFromChart.Visible = true;

            if (paidFromCreated == false)
            {
                int numPaidFrom = 0;
                String temp;

                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT PaidFrom) AS NumPaidFrom FROM INCOME", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                temp = String.Format("{0}", reader["NumPaidFrom"]);
                numPaidFrom = Convert.ToInt32(temp);
                connection.Close();
                String[] paidFrom = new string[15];
                String[] paidFromCost = new String[numPaidFrom];

                connection.Open();
                cmd = new SqlCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                reader = cmd.ExecuteReader();

                int j = 0;
                while (reader.Read())
                {
                    paidFrom[j] = String.Format("{0}", reader["PaidFrom"]);
                    j++;
                }
                connection.Close();

                String paidFromSeries = "Paid From";
                paidFromChart.Series.Add(paidFromSeries);
                paidFromChart.Series[paidFromSeries].ChartType = SeriesChartType.Pie;
                paidFromChart.ChartAreas[0].BackColor = Color.Transparent;
                paidFromChart.Series[paidFromSeries].IsVisibleInLegend = false;


                for (int i = 0; i < numPaidFrom; i++)
                {
                    cmd = new SqlCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                    cmd.Parameters.AddWithValue("@PaidFrom", paidFrom[i]);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    paidFromCost[i] = String.Format("{0}", reader["TotalPayment"]);
                    connection.Close();


                    paidFromChart.Series[paidFromSeries].Points.AddXY(paidFrom[i], paidFromCost[i]);
                    paidFromChart.Series[paidFromSeries].Points[i].Label = paidFrom[i];
                    paidFromCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(paidFromCost[i]));
                    paidFromCost[i] = "$" + paidFromCost[i];
                    paidFromChart.Series[paidFromSeries].Points[i].LegendText = paidFromCost[i];
                    paidFromChart.Series[paidFromSeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                    paidFromChart.Series[paidFromSeries].LabelForeColor = Color.White;
                    paidFromChart.Series[paidFromSeries].Points[i].ToolTip = paidFromCost[i];


                }
            }
            paidFromCreated = true;
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = true;
            paidToChart.Visible = false;
            paidFromChart.Visible = false;
        }
               
        private void monthBtn_Click(object sender, EventArgs e)
        {
            categoryChart.Visible = false;
            monthChart.Visible = true;
            paidToChart.Visible = false;
            paidFromChart.Visible = false; 
        }
    }
}
