using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Personal_Budget.Models
{
    class Category
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public List<Category> Categories { get; set; }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string categoryString = "SELECT * FROM category";
            var cmd = new MySqlCommand(categoryString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    CategoryId = reader.GetInt32("CategoryId"),
                    Name = reader.GetString("Category")
                };

                categories.Add(category);
            }

            con.Close();
            return categories;
        }

        public void GetTop(string year, string month)
        {

            year = (year == "Total" ? null : year);
            month = (month == "Total" ? null : month);

            List<Category> categories = new List<Category>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string categoryString = @"  SELECT 
                                            category.CategoryId,
	                                        category.Category, 
	                                        SUM(Payment) AS TotalPayment 
                                        FROM payment 
                                        INNER JOIN category ON
	                                        category.CategoryId = payment.CategoryId
                                        WHERE
	                                        (@Year IS NULL OR YEAR(TransactionDate) = @Year) AND
                                            (@Month IS NULL OR MONTHNAME(TransactionDate) = @Month)
                                        GROUP BY Category
                                        ORDER BY SUM(Payment) DESC
                                        LIMIT 6";

            var cmd = new MySqlCommand(categoryString, con);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    CategoryId = reader.GetInt32("CategoryId"),
                    Name = reader.GetString("Category"),
                    Cost = reader.GetString("TotalPayment")
                };

                categories.Add(category);
            }

            con.Close();

            Categories = categories;
        }

        public void GetTop()
        {
            List<Category> categories = new List<Category>();

            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string categoryString = @"  SELECT 
                                            category.CategoryId,
                                            category.Category, 
                                            SUM(Payment) AS TotalPayment 
                                        FROM payment 
                                        INNER JOIN category ON
	                                        category.CategoryId = payment.CategoryId
                                        GROUP BY Category 
                                        ORDER BY SUM(Payment) DESC LIMIT 6";

            var cmd = new MySqlCommand(categoryString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category category = new Category
                {
                    CategoryId = reader.GetInt32("CategoryId"),
                    Name = reader.GetString("Category"),
                    Cost = reader.GetString("TotalPayment")
                };

                categories.Add(category);
            }

            con.Close();

            Categories = categories;
        }

        public void Add()
        {
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string categoryString = @"  INSERT INTO category (Category)
	                                    VALUES (@Category);
                                        SELECT LAST_INSERT_ID();";

            var cmd = new MySqlCommand(categoryString, con);
            cmd.Parameters.AddWithValue("@Category", Name);

            con.Open();
            CategoryId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
    }
}
