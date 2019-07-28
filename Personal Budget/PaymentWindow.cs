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
using System.Data.OleDb;

namespace Personal_Budget
{
    public partial class PaymentWindow : Form
    {
        DataSet ds = new DataSet();
        static Connection dbConnection = new Connection();       
        String sql = "SELECT * FROM Payments ORDER BY TransactionDate";
        OleDbConnection connection = new OleDbConnection(dbConnection.getConnection());
        OleDbDataAdapter dataadapter;
        

        public PaymentWindow()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] sort = {"PaymentAccount", "Category", "Payment", "PaidTo", "TransactionDate"};
            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";


            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

            budgetGridView.Columns[3].DefaultCellStyle.Format = "C";

            categoryBox.Items.Add("Auto");
            categoryBox.Items.Add("Dining");
            categoryBox.Items.Add("Entertainment");
            categoryBox.Items.Add("Gas");
            categoryBox.Items.Add("Grocery");
            categoryBox.Items.Add("Healthcare");
            categoryBox.Items.Add("Interest");
            categoryBox.Items.Add("Online");
            categoryBox.Items.Add("Other");
            categoryBox.Items.Add("Phone");
            categoryBox.Items.Add("Rent");
        }

        private void budgetGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = budgetGridView.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = budgetGridView.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn && budgetGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            budgetGridView.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
                System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
        }

        private void incomeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in budgetGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
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
            category = categoryBox.SelectedText;
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
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 TransactionID FROM Payments ORDER BY TransactionID DESC", connection);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            temp = String.Format("{0}", reader["TransactionID"]);
            transactionID = Int32.Parse(temp) + 1;
            connection.Close();
            
            cmd = new OleDbCommand("INSERT INTO Payments VALUES (@TransactionID, @PaymentAccount, @Category, @Payment, @PaidTo, @TransactionDate, @TransactionMonth)", connection);

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
            dataadapter = new OleDbDataAdapter(sql, connection);
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
            if (e.RowIndex == -1) return;
            budgetGridView.Rows[e.RowIndex].Selected = true;
            IDBox.Text = budgetGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            paymentAcctBox.Text = budgetGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            categoryBox.Text = budgetGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            paymentBox.Text = budgetGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            paidToBox.Text = budgetGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            transactionDatePicker.Text = budgetGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(paymentAcctBox.Text);
            Console.WriteLine(categoryBox.Text);
            Console.WriteLine(paymentBox.Text);
            Console.WriteLine(paidToBox.Text);
            Console.WriteLine(transactionDatePicker.Text);
            Console.WriteLine(IDBox.Text);

            OleDbCommand cmd = new OleDbCommand("UPDATE Payments SET Account = @Account, Category = @Category, Payment = @Payment, PaidTo = @PaidTo, TransactionDate = @Date WHERE TransactionID =  @ID", connection);
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
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Payments WHERE TransactionID = @TransactionID", connection);
            cmd.Parameters.AddWithValue("@TransactionID", IDBox.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Boolean pAcctBoxCheck, cBoxCheck, pBoxCheck;
            pAcctBoxCheck = cBoxCheck = pBoxCheck = false;
            String srch = "SELECT * FROM Payments WHERE ";
            if (paymentAcctBox.Text.Length > 0)
            {
                pAcctBoxCheck = true;
                srch += "Account = '" + paymentAcctBox.Text + "' ";
                Console.WriteLine(srch);
            }
            if (categoryBox.SelectedIndex != -1 && pAcctBoxCheck == true)
            {
                cBoxCheck = true;
                srch += "AND Category = '" + categoryBox.Text + "' ";
            }
            else if (categoryBox.SelectedIndex != -1)
            {
                cBoxCheck = true;
                srch += "Category = '" + categoryBox.Text + "' ";
            }
            if (paymentBox.Text.Length > 0 && (pAcctBoxCheck == true || cBoxCheck == true))
            {
                pBoxCheck = true;
                srch += "AND Payment = " + paymentBox.Text + " ";
            }
            else if (paymentBox.Text.Length > 0)
            {
                pBoxCheck = true;
                srch += "Payment = " + paymentBox.Text + " ";
            }
            if (paidToBox.Text.Length > 0 && (pAcctBoxCheck == true || cBoxCheck == true || pBoxCheck == true))
            {
                srch += "AND PaidTo = '" + paidToBox.Text + "'";
            }
            else if (paidToBox.Text.Length > 0)
            {
                srch += "PaidTo = '" + paidToBox.Text + "'";
            }

            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(srch, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }
    }
}
