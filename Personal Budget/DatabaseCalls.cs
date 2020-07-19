using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{
    class DatabaseCalls
    {
        static Connection dbConnection = new Connection();
        static OleDbConnection connection = new OleDbConnection(dbConnection.getConnection());
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        public static String GetEarliestPayment()
        {
            String temp = "";
            //Earliest Payment date
            cmd = new OleDbCommand(@"   SELECT TOP 1 
                                            TransactionDate 
                                        FROM Payments 
                                        ORDER BY 
                                            TransactionDate",
                                            connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["TransactionDate"]);
            connection.Close();
            return temp;
        }

        public static void GetIncome(OleDbDataAdapter adapter, DataSet ds)
        {
            String sql = @" SELECT * 
                            FROM 
                                Income 
                            ORDER BY 
                                IncomeDate DESC";
            adapter = new OleDbDataAdapter(sql, connection);
            connection.Open();
            adapter.Fill(ds, "Income");
            connection.Close();
            
        }

        public static String GetEarliestIncome()
        {
            String temp = "";
            //Earliest Income date
            cmd = new OleDbCommand("SELECT  TOP 1 IncomeDate FROM Income ORDER BY IncomeDate", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["IncomeDate"]);
            connection.Close();
            return temp;
        }

        public static void FillArray(String type, String table, List<Category> categories)
        {
            categories.Clear();
            string connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");
            cmd = new OleDbCommand(connString, connection);
            connection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = String.Format("{0}", reader[type]),
                    Cost = String.Format("{0}", reader["TotalPayment"])
                };
                categories.Add(category);
            }
                

            connection.Close();
        }

        public static void FillArrayByMonth(string type, string table, Object month, string year, List<Category> categories)
        {
            categories.Clear();
            string connString = null;
            if (year == "Total")
            {
                connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE FORMAT(TransactionMonth, 'MMMM') = @Month GROUP BY " + type + " ORDER BY SUM(Payment) DESC");

                if (table == "Income")
                {
                    connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE FORMAT(IncomeDate, 'MMMM') = @Month GROUP BY " + type + " ORDER BY SUM(Payment) DESC");
                }
            }
            else
            {
                if (month == null || month.ToString() == "Total")
                {
                    connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE YEAR(TransactionDate) = " + year + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");

                    if (table == "Income")
                    {
                        connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE YEAR(IncomeDate) = " + year + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");
                    }
                }
                else
                {
                    connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE FORMAT(TransactionMonth, 'MMMM') = @Month AND YEAR(TransactionDate) = " + year + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");

                    if (table == "Income")
                    {
                        connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " WHERE FORMAT(IncomeDate, 'MMMM') = @Month AND YEAR(IncomeDate) = " + year + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");
                    }
                }
            }

            

            connection = new OleDbConnection(dbConnection.getConnection());
            connection.Open();
            cmd = new OleDbCommand(connString, connection);
            cmd.Parameters.AddWithValue("@Month", month);
            cmd.ExecuteNonQuery();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = String.Format("{0}", reader[type]),
                    Cost = String.Format("{0}", reader["TotalPayment"])
                };
                categories.Add(category);
            }

            connection.Close();
        }

        public static void FillMonthArrays(string year, List<Category> paymentMonths, List<Category> incomeMonths, List<Category> netMonths)
        {
            paymentMonths.Clear();
            incomeMonths.Clear();
            netMonths.Clear();
            if (year == "Total")
            {

                //test
                string query = @"SELECT 
                                    MONTH(Payments.TransactionDate) AS TransactionMonth, 
                                    SUM(Payments.Payment) AS TotalPayment,
                                    I.TotalIncome,
                                    I.TotalIncome - SUM(Payments.Payment) AS NetIncome
                                FROM 
                                    Payments 
                                INNER JOIN 
                                    (
                                    SELECT 
                                        MONTH(IncomeDate) AS IncomeMonth, 
                                        SUM(Payment) AS TotalIncome 
                                    FROM Income 
                                    GROUP BY 
                                        MONTH(IncomeDate)
                                    ) AS I ON
                                    I.IncomeMonth = Month(Payments.TransactionDate)
                                GROUP BY 
                                    MONTH(Payments.TransactionDate), 
                                    I.TotalIncome";

                cmd = new OleDbCommand(query, connection);
            }

            else
            {
                string query = @"SELECT 
                                    MONTH(Payments.TransactionDate) AS TransactionMonth, 
                                    SUM(Payments.Payment) AS TotalPayment,
                                    I.TotalIncome,
                                    I.TotalIncome - SUM(Payments.Payment) AS NetIncome
                                FROM 
                                    Payments 
                                INNER JOIN 
                                    (
                                    SELECT 
                                        MONTH(IncomeDate) AS IncomeMonth, 
                                        SUM(Payment) AS TotalIncome 
                                    FROM Income 
                                    WHERE YEAR(IncomeDate) = @Year
                                    GROUP BY 
                                        MONTH(IncomeDate)
                                    ) AS I ON
                                    I.IncomeMonth = Month(Payments.TransactionDate)
                                WHERE YEAR(Payments.TransactionDate) = @Year
                                GROUP BY 
                                    MONTH(Payments.TransactionDate), 
                                    I.TotalIncome";
                //Fill monthCost array
                cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@Year", year);

            }

            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int monthInt = int.Parse(reader["TransactionMonth"].ToString());
                string month = new DateTime(2010, monthInt, 1).ToString("MMMM");
                Category paymentMonth = new Category
                {
                    Name = month,
                    Cost = String.Format("${0:#.00}", reader["TotalPayment"])
                };

                Category incomeMonth = new Category
                {
                    Name = month,
                    Cost = String.Format("${0:#.00}", reader["TotalIncome"])
                };

                Category netMonth = new Category
                {
                    Name = month,
                    Cost = String.Format("${0:#.00}", reader["NetIncome"])
                };

                paymentMonths.Add(paymentMonth);
                incomeMonths.Add(incomeMonth);
                netMonths.Add(netMonth);
            }
            connection.Close();

        }
    }
}
