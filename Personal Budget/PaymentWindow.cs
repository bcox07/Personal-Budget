using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Personal_Budget.Models;

namespace Personal_Budget
{
    public partial class PaymentWindow : Form
    {
        DataSet ds = new DataSet();
        static Connection dbConnection = new Connection();       
        String sql = @" SELECT 
	                        payment.Id, 
	                        account.Account, 
                            category.Category, 
                            recipient.Recipient,
                            payment.Payment,
                            TransactionDate
                        FROM payment
                        INNER JOIN account ON
	                        account.AccountId = payment.AccountId
                        INNER JOIN category ON
	                        category.CategoryId = payment.CategoryId
                        INNER JOIN recipient ON
	                        recipient.RecipientId = payment.RecipientId
                        ORDER BY TransactionDate DESC";
        MySqlConnection connection = new MySqlConnection(dbConnection.getConnection());
        MySqlDataAdapter dataadapter;

        static List<Recipient> recipients = Recipient.GetRecipients();
        static List<Account> accounts = Account.GetAccounts();
        static List<Category> categories = Category.GetCategories();

        public PaymentWindow()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] sort = {"PaymentAccount", "Category", "Payment", "PaidTo", "TransactionDate"};
            transactionDatePicker.Format = DateTimePickerFormat.Custom;
            transactionDatePicker.CustomFormat = "yyyy-MM-dd";

            List<Category> categories = DatabaseCalls.GetCategories();

            dataadapter = new MySqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

            budgetGridView.Columns[4].DefaultCellStyle.Format = "C";
            budgetGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            budgetGridView.Columns[0].Width = 50;
            budgetGridView.Columns[2].Width = 120;
            budgetGridView.Columns[3].Width = 160;
            budgetGridView.Columns[5].Width = 130;

            foreach (Category category in categories)
            {
                categoryBox.Items.Add(category.Name);
            }
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
            Payment payment = new Payment
            {
                AccountId = accounts.Find(a => a.Name == paymentAcctBox.Text).AccountId,
                CategoryId = categories.Find(c => c.Name == categoryBox.Text).CategoryId,
                RecipientId = recipients.Find(r => r.Name == paidToBox.Text).RecipientId,
                Cost = Convert.ToDouble(paymentBox.Text),
                TransactionDate = transactionDatePicker.Text
            };

            payment.Insert();

            ds.Tables.Clear();
            dataadapter = new MySqlDataAdapter(sql, connection);
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
            Payment payment = new Payment
            {
                Id = int.Parse(IDBox.Text),
                AccountId = accounts.Find(a => a.Name == paymentAcctBox.Text).AccountId,
                CategoryId = categories.Find(c => c.Name == categoryBox.Text).CategoryId,
                RecipientId = recipients.Find(r => r.Name == paidToBox.Text).RecipientId,
                Cost = Convert.ToDouble(paymentBox.Text),
                TransactionDate = transactionDatePicker.Text
            };

            payment.Update();

            ds.Tables.Clear();
            dataadapter = new MySqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment
            {
                Id = int.Parse(IDBox.Text)
            };

            payment.Delete();

            ds.Tables.Clear();
            dataadapter = new MySqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            dataadapter = new MySqlDataAdapter(sql, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Boolean pAcctBoxCheck, cBoxCheck, pBoxCheck;
            pAcctBoxCheck = cBoxCheck = pBoxCheck = false;
            String srch = "SELECT * FROM payment WHERE ";
            if (paymentAcctBox.Text.Length > 0)
            {
                pAcctBoxCheck = true;
                srch += "AccountId = " + accounts.Find(a => a.Name == paymentAcctBox.Text).AccountId + " ";
                Console.WriteLine(srch);
            }
            if (categoryBox.SelectedIndex != -1 && pAcctBoxCheck == true)
            {
                cBoxCheck = true;
                srch += "AND CategoryId = " + categories.Find(c => c.Name == categoryBox.Text).CategoryId + " ";
            }
            else if (categoryBox.SelectedIndex != -1)
            {
                cBoxCheck = true;
                srch += "CategoryId = " + categories.Find(c => c.Name == categoryBox.Text).CategoryId + " ";
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
                srch += "AND RecipientId = " + recipients.Find(r => r.Name == paidToBox.Text).RecipientId;
            }
            else if (paidToBox.Text.Length > 0)
            {
                srch += "RecipientId = " + recipients.Find(r => r.Name == paidToBox.Text).RecipientId;
            }

            ds.Tables.Clear();
            dataadapter = new MySqlDataAdapter(srch, connection);
            connection.Open();
            dataadapter.Fill(ds, "Budget");
            connection.Close();
            budgetGridView.DataSource = ds.Tables[0];
        }
    }
}
