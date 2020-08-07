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
    public partial class IncomeWindow : Form
    {
        DataSet ds = new DataSet();
        MySqlDataAdapter dataadapter;
        Income income = new Income();

        static List<Recipient> recipients;
        static List<Category> categories;
        static List<RecipientCategory> recipientCategories;

        static Recipient recipient;
        static Category category;
        static RecipientCategory recipientCategory;

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
            incomeGridView.Columns["Payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            incomeGridView.Columns["Id"].Width = 50;
            incomeGridView.Columns["Recipient"].Width = 140;
            incomeGridView.Columns["TransactionDate"].Width = 140;

            recipients = Recipient.GetRecipients();
            categories = Category.GetCategories();

            foreach (Category category in categories)
            {
                categoryBox.Items.Add(category.Name);
            }


            foreach (DataGridViewColumn column in incomeGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void transactionBtn_Click(object sender, EventArgs e)
        {
            income.GetNewestIncome();
            recipients = Recipient.GetRecipients();

            income.RecipientId = recipients.Find(r => r.Name == recipientBox.Text)?.RecipientId;
            category.CategoryId = categories.Find(c => c.Name == categoryBox.Text)?.CategoryId;

            if (income.RecipientId == null)
            {
                recipient = new Recipient
                {
                    Name = recipientBox.Text
                };
                recipient.Add();

                income.RecipientId = recipient.RecipientId;
            }

            if (category.CategoryId == null)
            {
                category = new Category
                {
                    Name = categoryBox.Text
                };
                category.Add();

                income.RecipientId = recipient.RecipientId;
            }


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
            categories = Category.GetCategories();
            recipientCategories = RecipientCategory.GetRecipientCategories();
            if (e.RowIndex == -1) return;

            Income income = new Income();
            income.Id = Convert.ToInt32(incomeGridView.Rows[e.RowIndex].Cells[0].Value);

            income.Get();

            recipientCategory = recipientCategories.Find(r => r.RecipientId == income.RecipientId);
            category = categories.Find(c => c.CategoryId == recipientCategory?.CategoryId);

            incomeGridView.Rows[e.RowIndex].Selected = true;
            IDBox.Text = incomeGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            categoryBox.Text = category?.Name;
            recipientBox.Text = incomeGridView.Rows[e.RowIndex].Cells["Recipient"].Value.ToString();
            paymentBox.Text = incomeGridView.Rows[e.RowIndex].Cells["Payment"].Value.ToString().Substring(1);
            transactionDatePicker.Text = incomeGridView.Rows[e.RowIndex].Cells["TransactionDate"].Value.ToString();

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
                RecipientId = recipients.Find(r => r.Name == recipientBox.Text).RecipientId,
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

        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category category = Category.GetCategories().Find(c => c.Name == categoryBox.Text);

            recipients = Recipient.GetRecipients(category?.CategoryId);

            recipientBox.Items.Clear();
            foreach (Recipient recipient in recipients)
            {
                recipientBox.Items.Add(recipient.Name);
            }
        }
    }
}
