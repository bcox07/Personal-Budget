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
using System.Data.OleDb;

namespace Personal_Budget
{
    public partial class StatsWindow : Form
    {       
        static Connection dbConnection = new Connection();
        OleDbConnection connection = new OleDbConnection(dbConnection.getConnection());

        OleDbCommand cmd, cmd2;
        OleDbDataReader reader, reader2;

        private Color autumn = Color.FromArgb(118, 54, 38);
        private Color mist = Color.FromArgb(144, 175, 197);
        private Color stone = Color.FromArgb(51, 107, 135);

        static int numPaidTo = 6;
        static int numPaidFrom = 6;

        static List<String> paidTo = new List<String>();
        static List<String> paidFrom = new List<String>();
        static List<String> category = new List<String>();

        static List<String> categoryCost = new List<String>();
        static String[] paidToCost = new String[numPaidTo]; 
        static String[] paidFromCost = new string[numPaidFrom];
        
                              

        static int currMonthNum = Convert.ToInt32(DateTime.Now.ToString("MM"));
        static String[] month = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        static String[] monthCost = new String[12];
        static String[] monthIncome = new String[12];
        static String[] net = new String[12];


        public StatsWindow()
        {
            InitializeComponent();
        }

        public String GetEarliestPayment()
        {
            String temp = "";
            //Earliest Payment date
            cmd = new OleDbCommand("SELECT  TOP 1 TransactionDate FROM Payments ORDER BY TransactionDate", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["TransactionDate"]);
            connection.Close();
            return temp;
        }

        public String GetEarliestIncome()
        {
            String temp = "";
            //Earliest Income date
            cmd = new OleDbCommand("SELECT  TOP 1 IncomeDate FROM Income ORDER BY IncomeDate", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["IncomeDate"]);
            connection.Close();
            return temp;
        }

        //Compare first income and payment dates and sets the earliest startMonth
        public int FindEarliestDate(String first, String second, DateTime firstDate, DateTime secondDate)
        {
            int temp;
            if (firstDate < secondDate)
            {
                temp = Convert.ToInt32(DateTime.Parse(first).ToString("MM"));
            }
            else
            {
                temp = Convert.ToInt32(DateTime.Parse(second).ToString("MM"));
            }
            return temp;
        }


        public void FillMonthArrays(int startMonth)
        {
            //Fill monthCost array
            int i;
            for (i = startMonth - 1; i < currMonthNum; i++)
            {
                cmd = new OleDbCommand("SELECT TransactionMonth, SUM(Payment) AS TotalPayment FROM Payments WHERE TransactionMonth = @Month GROUP BY TransactionMonth", connection);
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
            for (i = startMonth - 1; i < currMonthNum; i++)
            {
                cmd = new OleDbCommand("SELECT IncomeMonth, SUM(Payment) AS TotalIncome FROM Income WHERE IncomeMonth = @Month GROUP BY IncomeMonth", connection);
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
        }

        private void StatsWindow_Load(object sender, EventArgs e)
        {
            
            monthChart.Visible = false;
            categoryChart.Visible = false;
            paidToChart.Visible = false;
            paidFromChart.Visible = false;
            monthChooser.Visible = false;

            paidFrom.Clear();
            paidTo.Clear();
            category.Clear();

            int i = 0;

            for (i=0; i<month.Length; i++)
            {
                monthCost[i] = "0";
                monthIncome[i] = "0";
                net[i] = "0";
            }


            //Find the earliest date that an income or payment was recorded
            String temp1, temp2;
            temp1 = temp2 = "";
            DateTime temp3, temp4;
            int startMonth = 0;

            
            try
            {
                temp1 = GetEarliestPayment();
                temp2 = GetEarliestIncome();

                //Convert date strings to DateTime for comparison
                temp3 = Convert.ToDateTime(temp1);
                temp4 = Convert.ToDateTime(temp2);

                startMonth = FindEarliestDate(temp1, temp2, temp3, temp4);

            }
            catch (InvalidOperationException)
            {
                label1.Text = "No Stats To Show";
                label1.Left = 190;
                label1.Top = -50;
                monthBtn.Hide();
                categoryBtn.Hide();
                paidToBtn.Hide();
                paidFromBtn.Hide();
                return;
            }

            //Reset numPaidTo on window opening
            numPaidTo = 6;
            numPaidFrom = 6;

            String sMonth = DateTime.Now.ToString("MM");
            int temp = Int32.Parse(sMonth);


            categoryCost.Clear();
            paidToCost = new String[numPaidTo];
            paidFromCost = new String[numPaidFrom];


            for (i=startMonth-1; i<currMonthNum; i++)
            {
                monthChooser.Items.Add(month[i]);
            }
            monthChooser.Items.Add("Total");
            monthChooser.SelectedText = "Total";


            FillMonthArrays(startMonth);
                       
            //Fill category array
            connection.Open();
            cmd = new OleDbCommand("SELECT TOP 6 Category, SUM(Payment) AS TotalPayment FROM Payments GROUP BY Category ORDER BY SUM(Payment) DESC", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {                
                category.Add(String.Format("{0}", reader["Category"]));

            }
            connection.Close();
            

            //Fill paidTo and paidFrom array
            connection.Open();
            cmd = new OleDbCommand("SELECT TOP 6 PaidTo, SUM(Payment) AS TotalPayment FROM Payments GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
            cmd2 = new OleDbCommand("SELECT TOP 6 PaidFrom, SUM(Payment) AS TotalPayment FROM Income GROUP BY PaidFRom ORDER BY SUM(Payment) DESC", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                paidTo.Add(String.Format("{0}", reader["PaidTo"]));
            }
            connection.Close();

            connection.Open();
            reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                paidFrom.Add(String.Format("{0}", reader2["PaidFrom"]));
            }
            connection.Close();


            //Fill paidToCost array
            cmd = new OleDbCommand("SELECT TOP 6 PaidTo, SUM(Payment) AS TotalPayment FROM Payments GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
            connection.Open();
            reader = cmd.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                paidToCost[i] = String.Format("{0}", reader["TotalPayment"]);
                i++;
            }
            connection.Close();


            //Fill paidFromCost array
            for (i = 0; i < paidFrom.Count; i++)
            {
                cmd2 = new OleDbCommand("SELECT TOP 6 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom GROUP BY PaidFrom", connection);
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

                cmd = new OleDbCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM Payments WHERE CATEGORY = @Category GROUP BY Category", connection);
                cmd.Parameters.AddWithValue("@Category", category[i]);

                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();

                categoryCost.Add(String.Format("{0}", reader["TotalPayment"]));
                connection.Close();
            } 


            //Fill net, monthCost, and monthIncome array
            for (i = startMonth-1; i < currMonthNum; i++)
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
            monthChart.Series[monthIncomeSeries].Color = mist;
            monthChart.Series[monthIncomeSeries].LabelForeColor = Color.White;

            monthChart.Series.Add(netSeries);
            monthChart.Series[netSeries].ChartType = SeriesChartType.Line;
            monthChart.Series[netSeries].BorderWidth = 8;
            monthChart.Series[netSeries].Color = Color.FromArgb(146, 156, 80);
            monthChart.Series[netSeries].LabelForeColor = Color.White;


            monthChart.ChartAreas[0].BackColor = stone;

            monthChart.ChartAreas[0].AxisX.LineColor = mist;
            monthChart.ChartAreas[0].AxisX.MajorGrid.LineColor = mist;            
            monthChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 3;
            monthChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = mist;
            monthChart.ChartAreas[0].AxisX.MajorTickMark.LineWidth = 3;
            monthChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = mist;
            monthChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            monthChart.ChartAreas[0].AxisY.LineColor = mist;            
            monthChart.ChartAreas[0].AxisY.MajorGrid.LineColor = mist;            
            monthChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 3;
            monthChart.ChartAreas[0].AxisY.MajorTickMark.LineColor = mist;
            monthChart.ChartAreas[0].AxisY.MajorTickMark.LineWidth = 3;
            monthChart.ChartAreas[0].AxisY.LabelStyle.ForeColor = mist;
            monthChart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            int j = 0;
            for (i = startMonth-1; i <currMonthNum; i++)
            {
                
                monthChart.Series[monthPaymentSeries].Points.AddXY(month[i], monthCost[i]);
                monthChart.Series[monthIncomeSeries].Points.AddXY(month[i], monthIncome[i]);
                monthChart.Series[netSeries].Points.AddXY(month[i], net[i]);
                monthChart.Series[monthPaymentSeries].Points[j].Label = monthCost[i];
                monthChart.Series[monthIncomeSeries].Points[j].Label = monthIncome[i];
                monthChart.Series[netSeries].Points[j].Label = net[i];
                monthChart.Series[monthPaymentSeries].Points[j].Font = monthChart.Series[monthIncomeSeries].Points[j].Font = monthChart.Series[netSeries].Points[j].Font = new Font("Arial", 12, FontStyle.Bold);
                j++;
            }
            
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //PaidTo chart creation
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            String paidToSeries = "Paid To";
            paidToChart.Series.Add(paidToSeries);
            paidToChart.Series[paidToSeries].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            paidToChart.ChartAreas[0].BackColor = Color.Transparent;
            paidToChart.Series[paidToSeries].IsVisibleInLegend = false;

            for (i = 0; i < paidTo.Count; i++)
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

            for (i = 0; i < paidFrom.Count; i++)
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
            paidToCost = new string[6];
            paidFromCost = new string[6];

            category.Clear();
            paidTo.Clear();
            paidFrom.Clear();

            String temp;
            OleDbConnection connection = new OleDbConnection(dbConnection.getConnection());
            OleDbDataReader reader;
            
            if (monthChooser.SelectedItem.Equals("Total"))
            {
                //Total Category Chart
                connection.Open();
                OleDbCommand cmd1 = new OleDbCommand("SELECT TOP 6 Category, SUM(Payment) AS TotalPayment FROM Payments GROUP BY Category ORDER BY SUM(Payment) DESC", connection);
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
                    connection = new OleDbConnection(dbConnection.getConnection());

                    cmd1 = new OleDbCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM Payments WHERE CATEGORY = @Category GROUP BY Category ORDER BY SUM(Payment) DESC", connection);
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
                cmd1 = new OleDbCommand("SELECT TOP 6 PaidTo, SUM(Payment) AS TotalPayment FROM Payments GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
                reader = cmd1.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidTo.Add(String.Format("{0}", reader["PaidTo"]));
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidTo.Count; i++)
                {
                    connection = new OleDbConnection(dbConnection.getConnection());

                    cmd1 = new OleDbCommand("SELECT PaidTo, SUM(Payment) AS TotalPayment FROM Payments WHERE PaidTo = @PaidTo GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
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
                cmd1 = new OleDbCommand("SELECT TOP 6 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME GROUP BY PaidFrom ORDER BY SUM(Payment) DESC", connection);
                reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    paidFrom.Add(String.Format("{0}", reader["PaidFrom"]));
                }
                connection.Close();

                for (i = 0; i < paidFrom.Count; i++)
                {
                    connection = new OleDbConnection(dbConnection.getConnection());

                    cmd1 = new OleDbCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom GROUP BY PaidFrom ORDER BY SUM(Payment) DESC", connection);
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
                category.Clear();
                categoryCost.Clear();

                connection = new OleDbConnection(dbConnection.getConnection());
                connection.Open();
                cmd = new OleDbCommand("SELECT TOP 6 Category, SUM(Payment) AS TotalPayment FROM Payments WHERE TransactionMonth = @Month GROUP BY Category ORDER BY SUM(Payment) DESC", connection);
                cmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                cmd.ExecuteNonQuery();

                reader = cmd.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    category.Add(String.Format("{0}", reader["Category"]));
                    i++;
                    
                }
                connection.Close();


                connection = new OleDbConnection(dbConnection.getConnection());

                cmd = new OleDbCommand("SELECT Category, SUM(Payment) AS TotalPayment FROM Payments WHERE TransactionMonth = @Month GROUP BY Category ORDER BY SUM(Payment) DESC", connection);
                cmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                connection.Open();
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    categoryCost.Add(String.Format("{0}", reader["TotalPayment"]));
                    i++;
                }
                connection.Close();



                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //PAID TO
                //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //Checks size of possible people paid to
                connection = new OleDbConnection(dbConnection.getConnection());
                connection.Open();
                OleDbCommand paidToCmd = new OleDbCommand("SELECT COUNT(PaidTo) AS NumPaidTo FROM (SELECT DISTINCT PaidTo FROM Payments WHERE TransactionMonth = @Month)", connection);
                paidToCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);


                paidToCmd.ExecuteNonQuery();
                reader = paidToCmd.ExecuteReader();
                reader.Read();


                //If PaidTo < 6, then resize arrays to new size
                temp = String.Format("{0}", reader["NumPaidTo"]);
                numPaidTo = Convert.ToInt32(temp);
                if (numPaidTo < 6)
                {
                    paidToCost = new String[numPaidTo];
                }
                else
                {
                    numPaidTo = 6;
                }
                connection.Close();


                connection = new OleDbConnection(dbConnection.getConnection());
                connection.Open();
                paidToCmd = new OleDbCommand("SELECT TOP 6 PaidTo, SUM(Payment) AS TotalPayment FROM Payments WHERE TransactionMonth = @Month GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
                paidToCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                paidToCmd.ExecuteNonQuery();

                reader = paidToCmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidTo.Add(String.Format("{0}", reader["PaidTo"]));
                    i++;
                }
                connection.Close();

                for (i = 0; i < numPaidTo; i++)
                {
                    connection = new OleDbConnection(dbConnection.getConnection());

                    paidToCmd = new OleDbCommand("SELECT PaidTo, SUM(Payment) AS TotalPayment FROM Payments WHERE PaidTo = @PaidTo AND TransactionMonth = @Month GROUP BY PaidTo ORDER BY SUM(Payment) DESC", connection);
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
                connection = new OleDbConnection(dbConnection.getConnection());
                connection.Open();
                OleDbCommand paidFromCmd = new OleDbCommand("SELECT COUNT(PaidFrom) AS NumPaidFrom FROM (SELECT DISTINCT PaidFrom FROM Income WHERE IncomeMonth = @Month)", connection);
                paidFromCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);


                paidFromCmd.ExecuteNonQuery();
                reader = paidFromCmd.ExecuteReader();
                reader.Read();


                //If PaidFrom < 6, then rezise arrays to new size
                temp = String.Format("{0}", reader["NumPaidFrom"]);
                numPaidFrom = Convert.ToInt32(temp);
                if (numPaidFrom < 6)
                {
                    paidFromCost = new String[numPaidFrom];
                }
                connection.Close();


                connection = new OleDbConnection(dbConnection.getConnection());
                connection.Open();
                paidFromCmd = new OleDbCommand("SELECT TOP 8 PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE IncomeMonth = @Month GROUP BY PaidFrom ORDER BY SUM(Payment) DESC", connection);
                paidFromCmd.Parameters.AddWithValue("@Month", monthChooser.SelectedItem);
                paidFromCmd.ExecuteNonQuery();

                reader = paidFromCmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    paidFrom.Add(String.Format("{0}", reader["PaidFrom"]));
                    i++;
                }
                connection.Close();

                for (i = 0; i < paidFrom.Count; i++)
                {
                    connection = new OleDbConnection(dbConnection.getConnection());

                    paidFromCmd = new OleDbCommand("SELECT PaidFrom, SUM(Payment) AS TotalPayment FROM INCOME WHERE PaidFrom = @PaidFrom AND IncomeMonth = @Month GROUP BY PaidFrom ORDER BY SUM(Payment) DESC", connection);
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
            for (int i = 0; i < paidTo.Count; i++)
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
            for (int i = 0; i < paidFrom.Count; i++)
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
