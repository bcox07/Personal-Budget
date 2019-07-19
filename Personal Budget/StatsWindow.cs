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
using System.Threading;

namespace Personal_Budget
{
    public partial class StatsWindow : Form
    {       
        static Connection dbConnection = new Connection();
        SqlConnection connection = new SqlConnection(dbConnection.getConnection());

        SqlCommand cmd, cmd2;
        SqlDataReader reader, reader2;

        private Color autumn = Color.FromArgb(118, 54, 38);
        private Color mist = Color.FromArgb(144, 175, 197);
        private Color stone = Color.FromArgb(51, 107, 135);

        static int numPaidTo = 8;
        static int numPaidFrom = 8;

        static String[] paidTo = new string[numPaidTo];
        static String[] paidFrom = new string[numPaidFrom];
        static List<String> category = new List<String>();

        static List<String> categoryCost = new List<String>();
        static String[] paidToCost = new String[numPaidTo]; 
        static String[] paidFromCost = new string[numPaidFrom];
        
                              

        static int currMonthNum = Convert.ToInt32(DateTime.Now.ToString("MM"));
        static String[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        static String[] monthCost = new String[12];
        static String[] monthIncome = new String[12];
        static String[] net = new String[12];


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
            monthChooser.Visible = false;

            int i = 0;

            //Reset numPaidTo on window opening
            numPaidTo = 8;
            numPaidFrom = 8;

            String sMonth = DateTime.Now.ToString("MM");
            int temp = Int32.Parse(sMonth);

            paidTo = new string[numPaidTo];
            paidFrom = new string[numPaidFrom];

            categoryCost.Clear();
            paidToCost = new String[numPaidTo];
            paidFromCost = new String[numPaidFrom];


            for (i=0; i<temp; i++)
            {
                monthChooser.Items.Add(month[i]);
            }
            monthChooser.Items.Add("Total");
            monthChooser.SelectedText = "Total";


            //Fill monthCost array
            for (i = 0; i < currMonthNum; i++)
            {
                cmd = new SqlCommand("SELECT TransactionMonth, SUM(Payment) AS TotalPayment FROM BUDGET WHERE TransactionMonth = @Month GROUP BY TransactionMonth", connection);
                cmd.Parameters.AddWithValue("@Month", month[i]);


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
            }

            //Fill monthIncome array
            for (i = 0; i < currMonthNum; i++)
            {
                cmd = new SqlCommand("SELECT TransactionMonth, SUM(Payment) AS TotalIncome FROM INCOME WHERE TransactionMonth = @Month GROUP BY TransactionMonth", connection);
                cmd.Parameters.AddWithValue("@Month", month[i]);


                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();
                try
                {
                    monthIncome[i] = String.Format("{0}", reader["TotalIncome"]);
                }
                catch (InvalidOperationException)
                {
                    monthIncome[i] = "0";
                }
                connection.Close();

            }



            //Fill category array
            connection.Open();
            cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY Category ORDER BY TotalPayment DESC", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {                
                category.Add(String.Format("{0}", reader["Category"]));

            }
            connection.Close();


            //Fill paidTo and paidFrom array
            connection.Open();
            cmd = new SqlCommand("SELECT TOP 8 PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
            cmd2 = new SqlCommand("SELECT TOP 8 PaidFrom, SUM(Payment) AS TotalPayment FROM Income GROUP BY PaidFRom ORDER BY TotalPayment DESC", connection);
            reader = cmd.ExecuteReader();


            i = 0;
            while (reader.Read())
            {
                paidTo[i] = String.Format("{0}", reader["PaidTo"]);
                i++;
            }
            connection.Close();

            connection.Open();
            reader2 = cmd2.ExecuteReader();
            i = 0;
            while (reader2.Read())
            {
                paidFrom[i] = String.Format("{0}", reader2["PaidFrom"]);
                i++;
            }
            connection.Close();
            

            //Fill paidToCost array
            for (i = 0; i < numPaidTo; i++)
            {
                cmd = new SqlCommand("SELECT PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET WHERE PaidTo = @PaidTo GROUP BY PaidTo", connection);
                cmd.Parameters.AddWithValue("@PaidTo", paidTo[i]);



                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();
                paidToCost[i] = String.Format("{0}", reader["TotalPayment"]);
                connection.Close();
            }

            //Fill paidFromCost array
            for (i = 0; i < numPaidFrom; i++)
            {
                cmd2 = new SqlCommand("SELECT TOP 8 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom GROUP BY PaidFrom", connection);
                cmd2.Parameters.AddWithValue("@PaidFrom", paidFrom[i]);

                connection.Open();
                cmd2.ExecuteNonQuery();
                reader2 = cmd2.ExecuteReader();
                reader2.Read();
                paidFromCost[i] = String.Format("{0}", reader2["TotalPayment"]);
                connection.Close();
            }


            //Fill categoryCost array
            for (i = 0; i < category.Count; i++)
            {

                cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET WHERE CATEGORY = @Category GROUP BY Category", connection);
                cmd.Parameters.AddWithValue("@Category", category[i]);

                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();

                categoryCost.Add(String.Format("{0}", reader["TotalPayment"]));
                connection.Close();
            } 


            //Fill net, monthCost, and monthIncome array
            for (i = 0; i < currMonthNum; i++)
            {
                net[i] = (Convert.ToDouble(monthIncome[i]) - Convert.ToDouble(monthCost[i])).ToString();


                monthCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(monthCost[i]));
                monthCost[i] = "$" + monthCost[i];

                monthIncome[i] = String.Format("{0:#.00}", Convert.ToDecimal(monthIncome[i]));
                monthIncome[i] = "$" + monthIncome[i];

                net[i] = String.Format("{0:#.00}", Convert.ToDecimal(net[i]));
                net[i] = "$" + net[i];
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Category chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------            
            String categorySeries = "Category";
            categoryChart.Series.Add(categorySeries);

            for (i = 0; i < category.Count; i++)
            {
                categoryChart.Series[categorySeries].Points.AddXY(category[i], categoryCost[i]);
                categoryChart.Series[categorySeries].Points[i].Label = category[i];
                categoryCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(categoryCost[i]));
                categoryCost[i] = "$" + categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].LegendText = categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                categoryChart.Series[categorySeries].LabelForeColor = Color.White;
                categoryChart.Series[categorySeries].Points[i].ToolTip = categoryCost[i];
            }

            categoryChart.Series[categorySeries].ChartType = SeriesChartType.Doughnut;
            categoryChart.Series[categorySeries].IsVisibleInLegend = true;
            categoryChart.BackColor = Color.Transparent;
            categoryChart.ChartAreas[0].BackColor = Color.Transparent;

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                       
            //Month chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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

            for (i = 0; i < currMonthNum; i++)
            {
                monthChart.Series[monthPaymentSeries].Points.AddXY(month[i], monthCost[i]);
                monthChart.Series[monthIncomeSeries].Points.AddXY(month[i], monthIncome[i]);
                monthChart.Series[netSeries].Points.AddXY(month[i], net[i]);
                monthChart.Series[monthPaymentSeries].Points[i].Label = monthCost[i];
                monthChart.Series[monthIncomeSeries].Points[i].Label = monthIncome[i];
                monthChart.Series[netSeries].Points[i].Label = net[i];

                monthChart.Series[monthPaymentSeries].Points[i].Font = monthChart.Series[monthIncomeSeries].Points[i].Font = monthChart.Series[netSeries].Points[i].Font = new Font("Arial", 12, FontStyle.Bold);
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //PaidTo chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            String paidToSeries = "Paid To";
            paidToChart.Series.Add(paidToSeries);
            paidToChart.Series[paidToSeries].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            paidToChart.ChartAreas[0].BackColor = Color.Transparent;
            paidToChart.Series[paidToSeries].IsVisibleInLegend = false;

            for (i = 0; i < numPaidTo; i++)
            {
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
            //Creat PaidFrom Chart
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            String paidFromSeries = "Paid From";
            paidFromChart.Series.Add(paidFromSeries);
            paidFromChart.Series[paidFromSeries].ChartType = SeriesChartType.Doughnut;
            paidFromChart.ChartAreas[0].BackColor = Color.Transparent;
            paidFromChart.Series[paidFromSeries].IsVisibleInLegend = false;

            for (i = 0; i < numPaidFrom; i++)
            {
                paidFromChart.Series[paidFromSeries].Points.AddXY(paidFrom[i], paidFromCost[i]);
                paidFromChart.Series[paidFromSeries].Points[i].Label = paidFrom[i];
                paidFromCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(paidFromCost[i]));
                paidFromCost[i] = "$" + paidFromCost[i];
                paidFromChart.Series[paidFromSeries].Points[i].LegendText = paidFromCost[i];
                paidFromChart.Series[paidFromSeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                paidFromChart.Series[paidFromSeries].LabelForeColor = Color.White;
                paidFromChart.Series[paidFromSeries].Points[i].ToolTip = paidFromCost[i];
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            

        }
        private void paidToBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = false;
            paidToChart.Visible = true;
            paidFromChart.Visible = false;
            monthChooser.Visible = true;
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
            monthChooser.Visible = true;
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart.Visible = true;
            paidToChart.Visible = false;
            paidFromChart.Visible = false;
            monthChooser.Visible = true;
        }
               
        private void monthBtn_Click(object sender, EventArgs e)
        {
            categoryChart.Visible = false;
            monthChart.Visible = true;
            paidToChart.Visible = false;
            paidFromChart.Visible = false;
            monthChooser.Visible = false;
        }


        private void monthChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryCost.Clear();
            paidToCost = new string[8];
            paidFromCost = new string[8];

            category.Clear();
            paidTo = new String[8];
            paidFrom = new string[8];

            String temp;
            SqlConnection connection = new SqlConnection(dbConnection.getConnection());
            SqlDataReader reader;
            
            if (monthChooser.SelectedItem.Equals("Total"))
            {
                //Total Category Chart
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY Category ORDER BY TotalPayment DESC", connection);
                reader = cmd1.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    category.Add(String.Format("{0}", reader["Category"]));
                    i++;
                }
                connection.Close();

                for (i = 0; i < category.Count; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    cmd1 = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET WHERE CATEGORY = @Category GROUP BY Category ORDER BY TotalPayment DESC", connection);
                    cmd1.Parameters.AddWithValue("@Category", category[i]);

                    connection.Open();
                    cmd1.ExecuteNonQuery();
                    reader = cmd1.ExecuteReader();
                    reader.Read();

                    categoryCost.Add(String.Format("{0}", reader["TotalPayment"]));
                    connection.Close();
                }

                //Total PaidTo Chart
                connection.Open();
                cmd1 = new SqlCommand("SELECT TOP 8 PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
                reader = cmd1.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidTo[i] = String.Format("{0}", reader["PaidTo"]);
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidTo.Length; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    cmd1 = new SqlCommand("SELECT PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET WHERE PaidTo = @PaidTo GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
                    cmd1.Parameters.AddWithValue("@PaidTo", paidTo[i]);

                    connection.Open();
                    cmd1.ExecuteNonQuery();
                    reader = cmd1.ExecuteReader();
                    reader.Read();

                    paidToCost[i] = String.Format("{0}", reader["TotalPayment"]);
                    connection.Close();
                }

                //Total PaidFrom Chart
                connection.Open();
                cmd1 = new SqlCommand("SELECT TOP 8 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                reader = cmd1.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidFrom[i] = String.Format("{0}", reader["PaidFrom"]);
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidFrom.Length; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    cmd1 = new SqlCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                    cmd1.Parameters.AddWithValue("@PaidFrom", paidFrom[i]);

                    connection.Open();
                    cmd1.ExecuteNonQuery();
                    reader = cmd1.ExecuteReader();
                    reader.Read();

                    paidFromCost[i] = String.Format("{0}", reader["TotalPayment"]);
                    connection.Close();
                }

            }
            else
            {
                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //CATEGORIES
                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


                connection = new SqlConnection(dbConnection.getConnection());
                connection.Open();
                cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET WHERE TransactionMonth = @Month GROUP BY Category ORDER BY TotalPayment DESC", connection);
                cmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    category.Add(String.Format("{0}", reader["Category"]));
                }
                connection.Close();
                int i;
                for (i = 0; i < category.Count; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    cmd = new SqlCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM BUDGET WHERE CATEGORY = @Category AND TransactionMonth = @Month GROUP BY Category ORDER BY TotalPayment DESC", connection);
                    cmd.Parameters.AddWithValue("@Category", category[i]);
                    cmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    categoryCost.Add(String.Format("{0}", reader["TotalPayment"]));
                    connection.Close();
                }

                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //PAID TO
                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                //Checks size of possible people paid to
                connection = new SqlConnection(dbConnection.getConnection());
                connection.Open();
                SqlCommand paidToCmd = new SqlCommand("SELECT COUNT(DISTINCT PaidTo) AS NumPaidTo FROM BUDGET WHERE TransactionMonth = @Month", connection);
                paidToCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);


                paidToCmd.ExecuteNonQuery();
                reader = paidToCmd.ExecuteReader();
                reader.Read();


                //If PaidTo < 8, then rezise arrays to new size
                temp = String.Format("{0}", reader["NumPaidTo"]);
                numPaidTo = Convert.ToInt32(temp);
                if (numPaidTo < 8)
                {
                    paidToCost = new String[numPaidTo];
                    paidTo = new String[numPaidTo];
                }
                connection.Close();


                connection = new SqlConnection(dbConnection.getConnection());
                connection.Open();
                paidToCmd = new SqlCommand("SELECT TOP 8 PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET WHERE TransactionMonth = @Month GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
                paidToCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                paidToCmd.ExecuteNonQuery();

                reader = paidToCmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidTo[i] = String.Format("{0}", reader["PaidTo"]);
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidTo.Length; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    paidToCmd = new SqlCommand("SELECT PaidTo, SUM(Payment) AS TotalPayment FROM BUDGET WHERE PaidTo = @PaidTo AND TransactionMonth = @Month GROUP BY PaidTo ORDER BY TotalPayment DESC", connection);
                    paidToCmd.Parameters.AddWithValue("@PaidTo", paidTo[i]);
                    paidToCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);

                    connection.Open();
                    paidToCmd.ExecuteNonQuery();
                    reader = paidToCmd.ExecuteReader();
                    reader.Read();

                    paidToCost[i] = String.Format("{0}", reader["TotalPayment"]);
                    connection.Close();
                }

                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //PAID FROM
                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                //Checks size of possible people paid from
                connection = new SqlConnection(dbConnection.getConnection());
                connection.Open();
                SqlCommand paidFromCmd = new SqlCommand("SELECT COUNT(DISTINCT PaidFrom) AS NumPaidFrom FROM INCOME WHERE TransactionMonth = @Month", connection);
                paidFromCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);


                paidFromCmd.ExecuteNonQuery();
                reader = paidFromCmd.ExecuteReader();
                reader.Read();


                //If PaidFrom < 8, then rezise arrays to new size
                temp = String.Format("{0}", reader["NumPaidFrom"]);
                numPaidFrom = Convert.ToInt32(temp);
                if (numPaidFrom < 8)
                {
                    paidFromCost = new String[numPaidFrom];
                    paidFrom = new String[numPaidFrom];
                }
                connection.Close();


                connection = new SqlConnection(dbConnection.getConnection());
                connection.Open();
                paidFromCmd = new SqlCommand("SELECT TOP 8 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE TransactionMonth = @Month GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                paidFromCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                paidFromCmd.ExecuteNonQuery();

                reader = paidFromCmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidFrom[i] = String.Format("{0}", reader["PaidFrom"]);
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidFrom.Length; i++)
                {
                    connection = new SqlConnection(dbConnection.getConnection());

                    paidFromCmd = new SqlCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom AND TransactionMonth = @Month GROUP BY PaidFrom ORDER BY TotalPayment DESC", connection);
                    paidFromCmd.Parameters.AddWithValue("@PaidFrom", paidFrom[i]);
                    paidFromCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);

                    connection.Open();
                    paidFromCmd.ExecuteNonQuery();
                    reader = paidFromCmd.ExecuteReader();
                    reader.Read();

                    paidFromCost[i] = String.Format("{0}", reader["TotalPayment"]);
                    connection.Close();
                }
            }           


            categoryChart.Series.Clear();
            paidToChart.Series.Clear();
            paidFromChart.Series.Clear();

            String categorySeries = "Category";
            String paidToSeries = "PaidTo";
            String paidFromSeries = "PaidFrom";

            categoryChart.Series.Add(categorySeries);
            paidToChart.Series.Add(paidToSeries);
            paidFromChart.Series.Add(paidFromSeries);

            //Adds data to Category chart
            for (int i = 0; i < category.Count; i++)
            {
                categoryChart.Series[categorySeries].Points.AddXY(category[i], categoryCost[i]);
                categoryChart.Series[categorySeries].Points[i].Label = category[i];
                categoryCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(categoryCost[i]));
                categoryCost[i] = "$" + categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].LegendText = categoryCost[i];
                categoryChart.Series[categorySeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                categoryChart.Series[categorySeries].LabelForeColor = Color.White;
                categoryChart.Series[categorySeries].Points[i].ToolTip = categoryCost[i];
            }

            //Adds data to PaidTo chart
            for (int i = 0; i < paidTo.Length; i++)
            {
                paidToChart.Series[paidToSeries].Points.AddXY(paidTo[i], paidToCost[i]);
                paidToChart.Series[paidToSeries].Points[i].Label = paidTo[i];
                paidToCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(paidToCost[i]));
                paidToCost[i] = "$" + paidToCost[i];
                paidToChart.Series[paidToSeries].Points[i].LegendText = paidToCost[i];
                paidToChart.Series[paidToSeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                paidToChart.Series[paidToSeries].LabelForeColor = Color.White;
                paidToChart.Series[paidToSeries].Points[i].ToolTip = paidToCost[i];
            }

            //Adds data to PaidFrom chart
            for (int i = 0; i < paidFrom.Length; i++)
            {
                paidFromChart.Series[paidFromSeries].Points.AddXY(paidFrom[i], paidFromCost[i]);
                paidFromChart.Series[paidFromSeries].Points[i].Label = paidFrom[i];
                paidFromCost[i] = String.Format("{0:#.00}", Convert.ToDecimal(paidFromCost[i]));
                paidFromCost[i] = "$" + paidFromCost[i];
                paidFromChart.Series[paidFromSeries].Points[i].LegendText = paidFromCost[i];
                paidFromChart.Series[paidFromSeries].Points[i].Font = new Font("Arial", 14, FontStyle.Bold);
                paidFromChart.Series[paidFromSeries].LabelForeColor = Color.White;
                paidFromChart.Series[paidFromSeries].Points[i].ToolTip = paidFromCost[i];
            }

            //Options for category chart
            categoryChart.Series[categorySeries].ChartType = SeriesChartType.Doughnut;
            categoryChart.Series[categorySeries].IsVisibleInLegend = false;
            categoryChart.BackColor = Color.Transparent;
            categoryChart.ChartAreas[0].BackColor = Color.Transparent;

            //Options for PaidTo chart
            paidToChart.Series[paidToSeries].ChartType = SeriesChartType.Doughnut;
            paidToChart.Series[paidToSeries].IsVisibleInLegend = false;
            paidToChart.BackColor = Color.Transparent;
            paidToChart.ChartAreas[0].BackColor = Color.Transparent;

            //Options for PaidFrom chart
            paidFromChart.Series[paidFromSeries].ChartType = SeriesChartType.Doughnut;
            paidFromChart.Series[paidFromSeries].IsVisibleInLegend = false;
            paidFromChart.BackColor = Color.Transparent;
            paidFromChart.ChartAreas[0].BackColor = Color.Transparent;
        }  
    }
}
