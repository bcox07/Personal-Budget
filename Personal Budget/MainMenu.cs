using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Budget
{
    public partial class MainMenu : Form
    {
        PaymentWindow pWindow;
        IncomeWindow iWindow;
        StatsWindow statWindow;
        public MainMenu()
        {
            InitializeComponent();            
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            pWindow = new PaymentWindow();
            pWindow.Show();
            this.Hide();            
        }

        private void incomeBtn_Click(object sender, EventArgs e)
        {
            iWindow = new IncomeWindow();
            iWindow.Show();
            this.Hide();
        }

        private void statsBtn_Click(object sender, EventArgs e)
        {
            statWindow = new StatsWindow();
            statWindow.Show();
            statWindow.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
    }
}
