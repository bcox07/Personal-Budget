using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Documents;

namespace Personal_Budget
{
    class Payment
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? CategoryId { get; set; }
        public int RecipientId { get; set; }
        public double Cost { get; set; }
        public string TransactionDate { get; set; }
        public List<Payment> Payments { get; set; }

        static Connection dbConnection = new Connection();
        static MySqlConnection connection = new MySqlConnection(dbConnection.getConnection());
        static MySqlCommand cmd;
        static MySqlDataReader reader;

        public void Insert()
        {
            cmd = new MySqlCommand(@"   INSERT INTO Payment (
                                            Id, 
                                            AccountId, 
                                            CategoryId, 
                                            RecipientId, 
                                            Payment, 
                                            TransactionDate) 
                                        VALUES (
                                            @Id, 
                                            @AccountId, 
                                            @CategoryId, 
                                            @RecipientId, 
                                            @Payment, 
                                            @TransactionDate)", connection);

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@AccountId", AccountId);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.Parameters.AddWithValue("@RecipientId", RecipientId);
            cmd.Parameters.AddWithValue("@Payment", Cost);
            cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            cmd = new MySqlCommand(@"UPDATE payment SET AccountId = @AccountId, CategoryId = @CategoryId, RecipientId = @RecipientId, Payment = @Payment, TransactionDate = @TransactionDate WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@AccountId", AccountId);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            cmd.Parameters.AddWithValue("@RecipientId", RecipientId);
            cmd.Parameters.AddWithValue("@Payment", Cost);
            cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            cmd = new MySqlCommand(@"   DELETE FROM payment 
                                        WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void GetNewest()
        {
            cmd = new MySqlCommand(@"   SELECT Id 
                                        FROM payment 
                                        ORDER BY Id DESC 
                                        LIMIT 1", connection);

            connection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Id = Int32.Parse(String.Format("{0}", reader["Id"]));
            }
            Id++;
            connection.Close();
        }
    }
}
