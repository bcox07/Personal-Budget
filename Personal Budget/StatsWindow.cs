using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Personal_Budget.Models;

namespace Personal_Budget
{
    public partial class StatsWindow : Form
    {       
        static List<Category> categories = new List<Category>();
        static List<Category> payments = new List<Category>();
        static List<Category> incomes = new List<Category>();
        static List<Category> incomeMonths = new List<Category>();
        static List<Category> paymentMonths = new List<Category>();
        static List<Category> netMonths = new List<Category>();

        static String[] monthName = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

        Point defaultYearPoint;
        Point yearPoint;

        ChartValues<double> paymentChart = new ChartValues<double>();
        ChartValues<double> incomeChart = new ChartValues<double>();
        ChartValues<double> netChart = new ChartValues<double>();

        List<string> xAxis = new List<string>();

        Category category = new Category();
        Recipient paidTo = new Recipient();
        Recipient paidFrom = new Recipient();


        public StatsWindow()
        {
            InitializeComponent();
        }

        //Compare first income and payment dates and sets the earliest startMonth
       int FindEarliestDate(String first, String second, DateTime firstDate, DateTime secondDate)
        {
            int tempMonth, tempYear;
            if (firstDate < secondDate)
            {
                tempMonth = Convert.ToInt32(DateTime.Parse(first).ToString("MM"));
            }
            else
            {
                tempMonth = Convert.ToInt32(DateTime.Parse(second).ToString("MM"));
            }
            return tempMonth;
        }

        //Compare first income and payment dates and sets the earliest startMonth
        int FindEarliestYear(String first, String second, DateTime firstDate, DateTime secondDate)
        {
            int tempYear;
            if (firstDate < secondDate)
            {
                tempYear = Convert.ToInt32(DateTime.Parse(first).ToString("yyyy"));
            }
            else
            {
                tempYear = Convert.ToInt32(DateTime.Parse(first).ToString("yyyy"));
            }
            return tempYear;
        }
       
        private void StatsWindow_Load(object sender, EventArgs e)
        {
            defaultYearPoint = new Point(yearChooser.Location.X, yearChooser.Location.Y);
            yearPoint = new Point(monthChooser.Location.X, monthChooser.Location.Y - 60);
            //Find the earliest date that an income or payment was recorded
            String temp1, temp2;
            temp1 = temp2 = "";
            DateTime temp3, temp4;
            int startMonth = 0;
            int startYear = 0;

            try
            {
                temp1 = DatabaseCalls.GetEarliestPayment();
                temp2 = DatabaseCalls.GetEarliestIncome();

                //Convert date strings to DateTime for comparison
                temp3 = Convert.ToDateTime(temp1);
                temp4 = Convert.ToDateTime(temp2);

                startMonth = FindEarliestDate(temp1, temp2, temp3, temp4);
                startYear = FindEarliestYear(temp1, temp2, temp3, temp4);

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

            
            DateTime curr = DateTime.Today;
            String tempYear = curr.ToString("yyyy");

            //Fill year combobox
            for (int i = startYear; i <= Int32.Parse(tempYear); i++)
            {
                yearChooser.Items.Add(i);
            }
            yearChooser.Items.Add("Total");
            yearChooser.SelectedIndex = yearChooser.Items.Count - 1;

            monthChart.Visible = false;
            categoryChart1.Visible = false;
            paymentChart1.Visible = false;
            incomeChart1.Visible = false;
            yearChooser.Visible = false;
            monthChooser.Visible = false;

            yearChooser.DropDownStyle = ComboBoxStyle.DropDownList;
            monthChooser.DropDownStyle = ComboBoxStyle.DropDownList;

            categories.Clear();
            payments.Clear();
            incomes.Clear();

            String sMonth = DateTime.Now.ToString("MM");
            int temp = Int32.Parse(sMonth);

            for (int i=startMonth-1; i<12; i++)
            {
                monthChooser.Items.Add(monthName[i]);
            }
            monthChooser.Items.Add("Total");
            monthChooser.SelectedIndex = monthChooser.Items.Count - 1;

            DatabaseCalls.FillMonthArrays(yearChooser.SelectedItem.ToString(), paymentMonths, incomeMonths, netMonths);

            ChartCreation.CustomizeMonthChart(monthLiveChart, xAxis);
            ChartCreation.FillMonthChart(paymentChart, paymentMonths);
            ChartCreation.FillMonthChart(incomeChart, incomeMonths);
            ChartCreation.FillMonthChart(netChart, netMonths);

            foreach (Category category in netMonths)
            {
                xAxis.Add(category.Name);
            }

            monthLiveChart.LegendLocation = LegendLocation.Top;
            monthLiveChart.FontSize = 20;

            monthLiveChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Income",
                    Values = incomeChart,
                    PointForeground = System.Windows.Media.Brushes.DodgerBlue,
                    PointGeometrySize = 15,
                    StrokeThickness = 5,
                    Fill = System.Windows.Media.Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Payments",
                    Values = paymentChart,
                    Stroke = System.Windows.Media.Brushes.Firebrick,
                    StrokeThickness = 5,
                    PointForeground = System.Windows.Media.Brushes.Firebrick,
                    PointGeometrySize = 15,
                    Fill = System.Windows.Media.Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Profit",
                    Values = netChart,
                    Stroke = System.Windows.Media.Brushes.Goldenrod,
                    StrokeThickness = 5,
                    PointForeground = System.Windows.Media.Brushes.Goldenrod,
                    PointGeometrySize = 15,
                    Fill = System.Windows.Media.Brushes.Transparent
                }

            };


            category.GetTop();
            paidTo.GetTopPayments();
            paidFrom.GetTopIncomes();

            ChartCreation.FillChart(categoryLiveChart, category.Categories);
            ChartCreation.FillChart(paymentLiveChart, paidTo.Recipients);
            ChartCreation.FillChart(incomeLiveChart, paidFrom.Recipients);
        }

        private void paidToBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart1.Visible = false;
            paymentChart1.Visible = true;
            incomeChart1.Visible = false;
            yearChooser.Visible = true;
            yearChooser.Location = yearPoint;
            monthChooser.Visible = false;
        }

        private void paidFromBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart1.Visible = false;
            paymentChart1.Visible = false;
            incomeChart1.Visible = true;
            yearChooser.Visible = true;
            yearChooser.Location = yearPoint;
            monthChooser.Visible = false;
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = false;
            categoryChart1.Visible = true;
            paymentChart1.Visible = false;
            incomeChart1.Visible = false;
            yearChooser.Visible = true;
            yearChooser.Location = yearPoint;
            monthChooser.Visible = false;
        }

        private void monthBtn_Click(object sender, EventArgs e)
        {
            monthChart.Visible = true;
            categoryChart1.Visible = false;
            paymentChart1.Visible = false;
            incomeChart1.Visible = false;
            yearChooser.Visible = true;
            yearChooser.Location = defaultYearPoint;
            monthChooser.Visible = false;
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

        private void yearChooser_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (yearChooser.SelectedItem.Equals("Total"))
            {
                monthChooser.Visible = false;
                category.GetTop();
                paidTo.GetTopPayments();
                paidFrom.GetTopIncomes();

            }
            else
            {
                if (monthChart.Visible == false)
                {
                    monthChooser.Visible = true;

                    category.GetTop(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
                    paidTo.GetTopPayments(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
                    paidFrom.GetTopIncomes(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
                }
            }

            DatabaseCalls.FillMonthArrays(yearChooser.SelectedItem.ToString(), paymentMonths, incomeMonths, netMonths);

            ChartCreation.CustomizeMonthChart(monthLiveChart, xAxis);
            ChartCreation.FillMonthChart(paymentChart, paymentMonths);
            ChartCreation.FillMonthChart(incomeChart, incomeMonths);
            ChartCreation.FillMonthChart(netChart, netMonths);

            ChartCreation.FillChart(categoryLiveChart, category.Categories);
            ChartCreation.FillChart(paymentLiveChart, paidTo.Recipients);
            ChartCreation.FillChart(incomeLiveChart, paidFrom.Recipients);
        }

        private void monthChooser_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (monthChooser.SelectedItem.Equals("Total"))
            {
                category.GetTop();
                paidTo.GetTopPayments();
                paidFrom.GetTopIncomes();
            }
            else
            {
                category.GetTop(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
                paidTo.GetTopPayments(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
                paidFrom.GetTopIncomes(yearChooser.SelectedItem.ToString(), monthChooser.SelectedItem.ToString());
            }

            ChartCreation.FillChart(categoryLiveChart, category.Categories);
            ChartCreation.FillChart(paymentLiveChart, paidTo.Recipients);
            ChartCreation.FillChart(incomeLiveChart, paidFrom.Recipients);
        }  

    }
}
