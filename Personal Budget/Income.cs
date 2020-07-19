using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{
    class Income
    {
        public int Id { get; set; }
        public string PaidFrom { get; set; }
        public double Payment { get; set; }
        public string PaymentDate { get; set; }

        static String connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\Budget.mdb";
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbCommand cmd;
        OleDbDataReader reader;

        public void Insert()
        {
            cmd = new OleDbCommand("INSERT INTO INCOME (IncomeID, PaidFrom, Payment, IncomeDate) VALUES (@IncomeID, @PaidFrom, @Payment, @IncomeDate)", connection);
            cmd.Parameters.AddWithValue("@IncomeID", Id);
            cmd.Parameters.AddWithValue("@PaidFrom", PaidFrom);
            cmd.Parameters.AddWithValue("@Payment", Payment);
            cmd.Parameters.AddWithValue("@IncomeDate", PaymentDate);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            cmd = new OleDbCommand("UPDATE INCOME SET PaidFrom = @PaidFrom, Payment = @Payment, IncomeDate = @IncomeDate WHERE IncomeID = @ID", connection);
            cmd.Parameters.AddWithValue("@PaidFrom", PaidFrom);
            cmd.Parameters.AddWithValue("@Payment", Payment);
            cmd.Parameters.AddWithValue("@IncomeDate", PaymentDate);
            cmd.Parameters.AddWithValue("ID", Id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            cmd = new OleDbCommand("DELETE FROM INCOME WHERE IncomeID = @IncomeID", connection);
            cmd.Parameters.AddWithValue("@IncomeID", Id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void GetNewestIncome()
        {
            
            cmd = new OleDbCommand("SELECT TOP 1 IncomeID FROM INCOME ORDER BY IncomeID DESC", connection);

            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Id = Int32.Parse(String.Format("{0}", reader["IncomeID"]));
            }
            Id++;
            connection.Close();
        }
    }
}
