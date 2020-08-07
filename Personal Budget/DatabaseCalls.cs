using MySql.Data.MySqlClient;
using Personal_Budget.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Personal_Budget
{
    class DatabaseCalls
    {
        static Connection dbConnection = new Connection();
        static MySqlConnection connection = new MySqlConnection(dbConnection.getConnection());
        static MySqlCommand cmd;
        static MySqlDataReader reader;
        public static String GetEarliestPayment()
        {
            String temp = "";
            //Earliest Payment date
            cmd = new MySqlCommand(@"   SELECT 
                                            TransactionDate 
                                        FROM Payment
                                        ORDER BY 
                                            TransactionDate
                                        LIMIT 1",
                                            connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["TransactionDate"]);
            connection.Close();
            return temp;
        }

        public static void GetIncome(MySqlDataAdapter adapter, DataSet ds)
        {
            String sql = @" SELECT 
	                            income.Id, 
                                recipient.Recipient,
                                CONCAT('$', income.Payment) AS Payment, 
                                TransactionDate
                            FROM income
                            INNER JOIN recipient ON
	                            recipient.RecipientId = income.RecipientId
                            ORDER BY TransactionDate DESC";
            adapter = new MySqlDataAdapter(sql, connection);
            connection.Open();
            adapter.Fill(ds, "Income");
            connection.Close();
            
        }

        public static String GetEarliestIncome()
        {
            String temp = "";
            //Earliest Income date
            cmd = new MySqlCommand("SELECT TransactionDate FROM income ORDER BY TransactionDate LIMIT 1", connection);
            connection.Open();
            //cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            reader.Read();

            temp = String.Format("{0}", reader["TransactionDate"]);
            connection.Close();
            return temp;
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string connString = ("SELECT DISTINCT Category FROM Category");
            cmd = new MySqlCommand(connString, connection);
            connection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = String.Format("{0}", reader["Category"]),
                };
                categories.Add(category);
            }
            connection.Close();
            return categories;
        }

        public static void FillArray(String type, String table, List<Category> categories)
        {
            categories.Clear();
            string connString = ("SELECT TOP 6 " + type + ", SUM(Payment) AS TotalPayment FROM " + table + " GROUP BY " + type + " ORDER BY SUM(Payment) DESC");
            cmd = new MySqlCommand(connString, connection);
            connection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = String.Format("{0}", reader[type]),
                    Cost = Convert.ToString(reader["TotalPayment"])
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
                    if (table.ToLower() == "payment")
                    {
                        if (type == "Category")
                        {
                            connString = (@"SELECT 
	                                            category.Category, 
                                                SUM(Payment) AS TotalPayment 
                                            FROM payment 
                                            INNER JOIN category ON
	                                            category.CategoryId = payment.CategoryId
                                            WHERE YEAR(TransactionDate) = @Year 
                                            GROUP BY Category 
                                            ORDER BY SUM(Payment) DESC
                                            LIMIT 6");
                        }
                        else
                        {
                            connString = (@"SELECT 
	                                        recipient.Recipient AS PaidTo, 
                                            SUM(Payment) AS TotalPayment 
                                        FROM payment 
                                        INNER JOIN recipient ON
	                                        recipient.RecipientId = payment.RecipientId
                                        WHERE YEAR(TransactionDate) = 2020 
                                        GROUP BY Recipient 
                                        ORDER BY SUM(Payment) DESC
                                        LIMIT 6;");
                        }
                        
                    }
                    if (table == "Income")
                    {
                        connString = (@"SELECT 
	                                        recipient.Recipient AS PaidFrom, 
                                            SUM(income.Payment) AS TotalPayment 
                                        FROM income 
                                        INNER JOIN recipient ON
	                                        recipient.RecipientId = income.RecipientId
                                        WHERE YEAR(TransactionDate) = @Year
                                        GROUP BY recipient.Recipient 
                                        ORDER BY SUM(income.Payment) DESC
                                        LIMIT 6");
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

            

            connection = new MySqlConnection(dbConnection.getConnection());
            connection.Open();
            cmd = new MySqlCommand(connString, connection);
            if (year != "Total")
            {
                cmd.Parameters.AddWithValue("@Year", year);
            }
            if (month != null && month.ToString() != "Total")
            {
                cmd.Parameters.AddWithValue("@Month", month);
            }
            
            cmd.ExecuteNonQuery();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = String.Format("{0}", reader[type]),
                    Cost = Convert.ToString(reader["TotalPayment"])
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
                string query = @"   SELECT 
	                                    MONTH(payment.TransactionDate) AS TransactionMonth, 
	                                    SUM(payment.Payment) AS TotalPayment,
	                                    I.TotalIncome,
	                                    I.TotalIncome - SUM(payment.Payment) AS NetIncome
                                    FROM 
	                                    payment 
                                    INNER JOIN 
	                                    (
	                                    SELECT 
		                                    MONTH(income.TransactionDate) AS IncomeMonth, 
		                                    SUM(Payment) AS TotalIncome 
	                                    FROM income 
	                                    GROUP BY 
		                                    MONTH(income.TransactionDate)
	                                    ) AS I ON
	                                    I.IncomeMonth = Month(payment.TransactionDate)
                                    GROUP BY 
	                                    MONTH(payment.TransactionDate), 
	                                    I.TotalIncome";

                cmd = new MySqlCommand(query, connection);
            }

            else
            {
                string query = @"   SELECT 
	                                    MONTH(payment.TransactionDate) AS TransactionMonth, 
	                                    SUM(payment.Payment) AS TotalPayment,
	                                    I.TotalIncome,
	                                    I.TotalIncome - SUM(payment.Payment) AS NetIncome
                                    FROM 
	                                    payment 
                                    INNER JOIN 
	                                    (
	                                    SELECT 
		                                    MONTH(income.TransactionDate) AS IncomeMonth, 
		                                    SUM(Payment) AS TotalIncome 
	                                    FROM income 
                                        WHERE YEAR(income.TransactionDate) = @Year
	                                    GROUP BY 
		                                    MONTH(income.TransactionDate)
	                                    ) AS I ON
	                                    I.IncomeMonth = Month(payment.TransactionDate)
                                    WHERE YEAR(payment.TransactionDate) = @Year
                                    GROUP BY 
	                                    MONTH(payment.TransactionDate), 
	                                    I.TotalIncome";
                //Fill monthCost array
                cmd = new MySqlCommand(query, connection);
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
                    Cost = Convert.ToString(reader["TotalPayment"])
                };

                Category incomeMonth = new Category
                {
                    Name = month,
                    Cost = Convert.ToString(reader["TotalIncome"])
                };

                Category netMonth = new Category
                {
                    Name = month,
                    Cost = Convert.ToString(reader["NetIncome"])
                };

                paymentMonths.Add(paymentMonth);
                incomeMonths.Add(incomeMonth);
                netMonths.Add(netMonth);
            }
            connection.Close();

        }
    }
}
