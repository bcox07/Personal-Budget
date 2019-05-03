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
    public partial class PaymentWindow : Form
    {
        DataSet ds = new DataSet();
        static Connection dbConnection = new Connection();       
        String sql = "SELECT * FROM BUDGET ORDER BY TransactionDate";
        SqlConnection connection = new SqlConnection(dbConnection.getConnection());
        SqlDataAdapter dataadapter;
        String sort = null;
        

        public PaymentWindow()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] sort = {"PaymentAccount", "Category", "Payment", "PaidTo", "TransactionDate"};
            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";


            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

            budgetGridView.Columns[3].DefaultCellStyle.Format = "C";

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
            String account, category, paidTo, date, month, temp;
            Double payment = 0;
            DateTime monthDate;
            int transactionID = 0;
            
            account = category = paidTo = temp = date = month = "";
            account = category = paidTo = temp = date = month = "";

            account = paymentAcctBox.Text;
            category = categoryBox.Text;
            temp = paymentBox.Text;
            payment = Convert.ToDouble(temp);
            paidTo = paidToBox.Text;
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
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 TransactionID FROM BUDGET ORDER BY TransactionID DESC", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            temp = String.Format("{0}", reader["TransactionID"]);
            transactionID = Int32.Parse(temp) + 1;
            connection.Close();
            
            cmd = new SqlCommand("INSERT INTO BUDGET VALUES (@TransactionID, @PaymentAccount, @Category, @Payment, @PaidTo, @TransactionDate, @TransactionMonth)", connection);

            connection.Open();
            cmd.Parameters.AddWithValue("@TransactionID", transactionID);
            cmd.Parameters.AddWithValue("@PaymentAccount", account);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Payment", payment);
            cmd.Parameters.AddWithValue("@PaidTo", paidTo);
            cmd.Parameters.AddWithValue("@TransactionDate", date);
            cmd.Parameters.AddWithValue("@TransactionMonth", month);
            cmd.ExecuteNonQuery();            
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }



        private void statsBtn_Click(object sender, EventArgs e)
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

        private void budgetGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {       
            IDBox.Text = budgetGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            paymentAcctBox.Text = budgetGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            categoryBox.Text = budgetGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            paymentBox.Text = budgetGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            paidToBox.Text = budgetGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            transactionDatePicker.Text = budgetGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE BUDGET SET PaymentAccount = @Account, Category = @Category, Payment = @Payment, PaidTo = @PaidTo, TransactionDate = @Date WHERE TransactionID =  @ID", connection);
            cmd.Parameters.AddWithValue("@Account", paymentAcctBox.Text);
            cmd.Parameters.AddWithValue("@Category", categoryBox.Text);
            cmd.Parameters.AddWithValue("@Payment", paymentBox.Text);
            cmd.Parameters.AddWithValue("@PaidTo", paidToBox.Text);
            cmd.Parameters.AddWithValue("@Date", transactionDatePicker.Text);
            cmd.Parameters.AddWithValue("@ID", IDBox.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM BUDGET WHERE TransactionID = @TransactionID", connection);
            cmd.Parameters.AddWithValue("@TransactionID", IDBox.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            dataadapter = new SqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            String temp;
            temp = Convert.ToString(sortBox.SelectedItem);
            setSort("SELECT * FROM BUDGET ORDER BY " + temp);

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
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        

        private void setSort(String s)
        {
            sort = s;
        }



        private void incButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String temp = "SELECT * FROM BUDGET ORDER BY " + Convert.ToString(sortBox.SelectedItem) + " ASC";

                SqlCommand cmd = new SqlCommand(temp, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                ds.Tables.Clear();
                dataadapter = new SqlDataAdapter(temp, connection);
                connection.Open();
                dataadapter.Fill(ds, "Sort");
                connection.Close();
                budgetGridView.DataSource = ds.Tables[0];
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
                String temp = "SELECT * FROM BUDGET ORDER BY " + Convert.ToString(sortBox.SelectedItem) + " DESC";

                SqlCommand cmd = new SqlCommand(temp, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                ds.Tables.Clear();
                dataadapter = new SqlDataAdapter(temp, connection);
                connection.Open();
                dataadapter.Fill(ds, "Sort");
                connection.Close();
                budgetGridView.DataSource = ds.Tables[0];
            }
            catch (SqlException)
            {
                connection.Close();
            }
           
        }
    }
}
