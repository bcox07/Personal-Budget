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

namespace Personal_Budget
{
    public partial class IncomeWindow : Form
    {
        static Connection dbConnection = new Connection();
        DataSet ds = new DataSet();
        String sql = "SELECT * FROM INCOME ORDER BY IncomeDate";
        SqlConnection connection = new SqlConnection(dbConnection.getConnection());
        SqlDataAdapter dataadapter;
        String sort = null;

        public IncomeWindow()
        {
            InitializeComponent();
        }

        private void IncomeWindow_Load(object sender, EventArgs e)
        {
            String[] sort = { "IncomeID", "PaidFrom", "Payment", "IncomeDate" };

            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";

            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];

            incomeGridView.Columns[2].DefaultCellStyle.Format = "C";
            int i = 0;
            while (i < sort.Length)
            {
                sortBox.Items.Add(sort[i]);
                i++;
            }

            incButton.Select();
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            String paidFrom, date, month, temp;
            Double payment = 0;
            DateTime monthDate;
            int incomeID = 0;

            paidFrom = temp = date = month = "";

            
            temp = paymentBox.Text;
            payment = Convert.ToDouble(temp);
            paidFrom = paidFromBox.Text;
            date = transactionDatePicker.Text;
            monthDate = Convert.ToDateTime(date);

            switch (monthDate.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;

            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 IncomeID FROM INCOME ORDER BY IncomeID DESC", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                temp = String.Format("{0}", reader["IncomeID"]);
            }
            catch (InvalidOperationException)
            {
                temp = "0";
            }
            incomeID = Int32.Parse(temp) + 1;
            connection.Close();
            

            connection.Open();
            cmd = new SqlCommand("INSERT INTO INCOME VALUES (@IncomeID, @PaidFrom, @Payment, @IncomeDate, @IncomeMonth)", connection);
            cmd.Parameters.AddWithValue("@IncomeID", incomeID);
            cmd.Parameters.AddWithValue("@PaidFrom", paidFrom);
            cmd.Parameters.AddWithValue("@Payment", payment); 
            cmd.Parameters.AddWithValue("@IncomeDate", date);
            cmd.Parameters.AddWithValue("@IncomeMonth", month);



            cmd.ExecuteNonQuery();
            connection.Close();
            


        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM INCOME WHERE IncomeID = @IncomeID", connection);
            cmd.Parameters.AddWithValue("@IncomeID", IDBox.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void incomeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDBox.Text = incomeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            paidFromBox.Text = incomeGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            paymentBox.Text = incomeGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            transactionDatePicker.Text = incomeGridView.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DateTime monthDate;

            SqlCommand cmd = new SqlCommand("UPDATE INCOME SET PaidFrom = @PaidFrom, Payment = @Payment, IncomeDate = @Date, TransactionMonth = @Month WHERE IncomeID =  @ID", connection);
                        
            monthDate = Convert.ToDateTime(transactionDatePicker.Text);
            String month = "";

            switch (monthDate.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;

            }

            cmd.Parameters.AddWithValue("@Payment", paymentBox.Text);
            cmd.Parameters.AddWithValue("@PaidFrom", paidFromBox.Text);
            cmd.Parameters.AddWithValue("@Date", transactionDatePicker.Text);
            cmd.Parameters.AddWithValue("@ID", IDBox.Text);
            cmd.Parameters.AddWithValue("@Month", month);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MainMenu>().Count() == 1)
            {
                Application.OpenForms.OfType<MainMenu>().First().Show();
                this.Hide();
            }
            else if (Application.OpenForms.OfType<MainMenu>().Count() > 1)
            {
                Application.OpenForms.OfType<MainMenu>().First().Close();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];
        }

        private void incButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String temp = "SELECT * FROM INCOME ORDER BY " + Convert.ToString(sortBox.SelectedItem) + " ASC";

                SqlCommand cmd = new SqlCommand(temp, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                ds.Tables.Clear();
                dataadapter = new SqlDataAdapter(temp, connection);
                connection.Open();
                dataadapter.Fill(ds, "Sort");
                connection.Close();
                incomeGridView.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                connection.Close();
            }
        }

        private void decButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String temp = "SELECT * FROM INCOME ORDER BY " + Convert.ToString(sortBox.SelectedItem) + " DESC";

                SqlCommand cmd = new SqlCommand(temp, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                ds.Tables.Clear();
                dataadapter = new SqlDataAdapter(temp, connection);
                connection.Open();
                dataadapter.Fill(ds, "Sort");
                connection.Close();
                incomeGridView.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                connection.Close();
            }
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String temp;
            temp = Convert.ToString(sortBox.SelectedItem);
            sort = "SELECT * FROM INCOME ORDER BY " + temp;

            if (decButton.Checked)
            {
                sort += " DESC";
            }

            SqlCommand cmd = new SqlCommand(sort, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sort, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];
        }
    }
}
