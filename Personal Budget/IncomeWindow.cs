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
    public partial class IncomeWindow : Form
    {
        DataSet ds = new DataSet();
        String sql = "SELECT * FROM Income ORDER BY IncomeDate DESC";
        
        static String connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\Budget.mdb";
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbDataAdapter dataadapter;

        public IncomeWindow()
        {
            InitializeComponent();
        }

        private void IncomeWindow_Load(object sender, EventArgs e)
        {
            String[] sort = { "IncomeID", "PaidFrom", "Payment", "IncomeDate" };

            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";

            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];

            incomeGridView.Columns[2].DefaultCellStyle.Format = "C";
           

            foreach (DataGridViewColumn column in incomeGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
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
            OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 IncomeID FROM INCOME ORDER BY IncomeID DESC", connection);
            OleDbDataReader reader = cmd.ExecuteReader();
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
            cmd = new OleDbCommand("INSERT INTO INCOME VALUES (@IncomeID, @PaidFrom, @Payment, @IncomeDate, @IncomeMonth)", connection);
            cmd.Parameters.AddWithValue("@IncomeID", incomeID);
            cmd.Parameters.AddWithValue("@PaidFrom", paidFrom);
            cmd.Parameters.AddWithValue("@Payment", payment); 
            cmd.Parameters.AddWithValue("@IncomeDate", date);
            cmd.Parameters.AddWithValue("@IncomeMonth", month);

            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];



        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM INCOME WHERE IncomeID = @IncomeID", connection);
            cmd.Parameters.AddWithValue("@IncomeID", IDBox.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];
        }

        private void incomeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            incomeGridView.Rows[e.RowIndex].Selected = true;
            IDBox.Text = incomeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            paidFromBox.Text = incomeGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            paymentBox.Text = incomeGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            transactionDatePicker.Text = incomeGridView.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void incomeGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = incomeGridView.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = incomeGridView.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn && incomeGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending)
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
            incomeGridView.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
                System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
        }

        private void incomeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in incomeGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DateTime monthDate;

            OleDbCommand cmd = new OleDbCommand("UPDATE INCOME SET PaidFrom = @PaidFrom, Payment = @Payment, IncomeDate = @Date, TransactionMonth = @Month WHERE IncomeID =  @ID", connection);
                        
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

            ds.Tables.Clear();
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];
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
            dataadapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Income");
            connection.Close();
            incomeGridView.DataSource = ds.Tables[0];
        }
    }
}
