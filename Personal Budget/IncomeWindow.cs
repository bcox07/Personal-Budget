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
        OleDbDataAdapter dataadapter;
        Income income = new Income();

        public IncomeWindow()
        {
            InitializeComponent();
        }

        private void IncomeWindow_Load(object sender, EventArgs e)
        {
            String[] sort = { "IncomeID", "PaidFrom", "Payment", "IncomeDate" };

            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";

            DatabaseCalls.GetIncome(dataadapter, ds);

            incomeGridView.DataSource = ds.Tables[0];
            incomeGridView.Columns[2].DefaultCellStyle.Format = "C";
           
            foreach (DataGridViewColumn column in incomeGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            income.GetNewestIncome();

            income.PaidFrom = paidFromBox.Text;
            income.Payment = Convert.ToDouble(paymentBox.Text);
            income.PaymentDate = transactionDatePicker.Text;

            income.Insert();

            ds.Tables.Clear();
            DatabaseCalls.GetIncome(dataadapter, ds);
            incomeGridView.DataSource = ds.Tables[0];
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            income = new Income
            {
                Id = int.Parse(IDBox.Text)
            };

            income.Delete();

            ds.Tables.Clear();
            DatabaseCalls.GetIncome(dataadapter, ds);
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

            income = new Income
            {
                Id = int.Parse(IDBox.Text),
                PaidFrom = paidFromBox.Text,
                Payment = Convert.ToDouble(paymentBox.Text),
                PaymentDate = transactionDatePicker.Text
            };

            income.Update();

            ds.Tables.Clear();
            DatabaseCalls.GetIncome(dataadapter, ds);
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
    }
}
