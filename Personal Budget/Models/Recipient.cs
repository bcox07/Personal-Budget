using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Personal_Budget
{
    class Recipient
    {
        public int RecipientId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public List<Recipient> Recipients { get; set; }

        public void GetTopPayments()
        {
            Recipients = new List<Recipient>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(@"  SELECT 
	                                                    recipient.RecipientId, 
                                                        recipient.Recipient, 
                                                        SUM(Payment) AS TotalPayment 
                                                    FROM payment 
                                                    INNER JOIN recipient ON
	                                                    recipient.RecipientId = payment.RecipientId
                                                    GROUP BY Recipient
                                                    ORDER BY SUM(Payment) DESC LIMIT 6", connection);

            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipients.Add(new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient"),
                    Cost = reader.GetString("TotalPayment")

                });
            }
        }

        public void GetTopPayments(string year, string month)
        {
            year = (year == "Total" ? null : year);
            month = (month == "Total" ? null : month);

            Recipients = new List<Recipient>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(@"  SELECT 
	                                                    recipient.RecipientId, 
	                                                    recipient.Recipient, 
	                                                    SUM(Payment) AS TotalPayment 
                                                    FROM payment 
                                                    INNER JOIN recipient ON
	                                                    recipient.RecipientId = payment.RecipientId
                                                    WHERE 
	                                                    (@Year IS NULL OR YEAR(TransactionDate) = @Year) AND
	                                                    (@Month IS NULL OR MONTHNAME(TransactionDate) = @Month)
                                                    GROUP BY Recipient
                                                    ORDER BY SUM(Payment) DESC 
                                                    LIMIT 6", connection);

            
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);

            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipients.Add(new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient"),
                    Cost = reader.GetString("TotalPayment")

                });
            }
        }

        public void GetTopIncomes()
        {
            Recipients = new List<Recipient>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(@"  SELECT 
	                                                    recipient.RecipientId, 
                                                        recipient.Recipient, 
                                                        SUM(Payment) AS TotalPayment 
                                                    FROM income 
                                                    INNER JOIN recipient ON
	                                                    recipient.RecipientId = income.RecipientId
                                                    GROUP BY Recipient
                                                    ORDER BY SUM(Payment) DESC LIMIT 6", connection);

            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipients.Add(new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient"),
                    Cost = reader.GetString("TotalPayment")

                });
            }
        }

        public void GetTopIncomes(string year, string month)
        {
            year = (year == "Total" ? null : year);
            month = (month == "Total" ? null : month);

            Recipients = new List<Recipient>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(@"  SELECT 
	                                                    recipient.RecipientId, 
	                                                    recipient.Recipient, 
	                                                    SUM(Payment) AS TotalPayment 
                                                    FROM income 
                                                    INNER JOIN recipient ON
	                                                    recipient.RecipientId = income.RecipientId
                                                    WHERE 
	                                                    (@Year IS NULL OR YEAR(TransactionDate) = @Year) AND
	                                                    (@Month IS NULL OR MONTHNAME(TransactionDate) = @Month)
                                                    GROUP BY Recipient
                                                    ORDER BY SUM(Payment) DESC 
                                                    LIMIT 6", connection);


            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);

            connection.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipients.Add(new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient"),
                    Cost = reader.GetString("TotalPayment")

                });
            }
        }

        public static List<Recipient> GetRecipients()
        {
            List<Recipient> recipients = new List<Recipient>();
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string recipientString = "SELECT * FROM recipient";
            var cmd = new MySqlCommand(recipientString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipient recipient = new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient")
                };

                recipients.Add(recipient);
            }

            con.Close();
            return recipients;
        }

        public static List<Recipient> GetRecipients(int? categoryId)
        {
            List<Recipient> recipients = new List<Recipient>();
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string recipientString = @"SELECT 	
	                                        RecipientCategoryId, 
                                            recipient.RecipientId,
	                                        recipient.Recipient, 
	                                        category.Category 
                                        FROM personal.recipientcategory
                                        INNER JOIN recipient ON
	                                        recipient.RecipientId = recipientcategory.RecipientId
                                        INNER JOIN category ON
	                                        category.CategoryId = recipientcategory.CategoryId
                                        WHERE category.CategoryId = @CategoryId;";

            var cmd = new MySqlCommand(recipientString, con);

            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            con.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Recipient recipient = new Recipient
                {
                    RecipientId = reader.GetInt32("RecipientId"),
                    Name = reader.GetString("Recipient")
                };

                recipients.Add(recipient);
            }

            con.Close();
            return recipients;
        }

        public void Add()
        {
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string recipientString = @"INSERT INTO recipient (Recipient)
	                                   VALUES (@Recipient);
                                       SELECT LAST_INSERT_ID();";

            var cmd = new MySqlCommand(recipientString, con);
            cmd.Parameters.AddWithValue("@Recipient", Name);

            con.Open();
            RecipientId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
        }
    }

    
}
