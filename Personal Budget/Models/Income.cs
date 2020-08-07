using MySql.Data.MySqlClient;
using System;
using System.Data.OleDb;


namespace Personal_Budget
{
    class Income
    {
        public int Id { get; set; }
        public int? RecipientId { get; set; }
        public double Payment { get; set; }
        public string PaymentDate { get; set; }

        static Connection dbConnection = new Connection();
        static MySqlConnection connection = new MySqlConnection(dbConnection.getConnection());
        static MySqlCommand cmd;
        static MySqlDataReader reader;

        public void Insert()
        {
            cmd = new MySqlCommand("INSERT INTO Income (Id, RecipientId, Payment, TransactionDate) VALUES (@Id, @RecipientId, @Payment, @TransactionDate)", connection);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RecipientId", RecipientId);
            cmd.Parameters.AddWithValue("@Payment", Payment);
            cmd.Parameters.AddWithValue("@TransactionDate", PaymentDate);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            cmd = new MySqlCommand("UPDATE income SET RecipientId = @RecipientId, Payment = @Payment, TransactionDate = @TransactionDate WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@RecipientId", RecipientId);
            cmd.Parameters.AddWithValue("@Payment", Payment);
            cmd.Parameters.AddWithValue("@TransactionDate", PaymentDate);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            cmd = new MySqlCommand("DELETE FROM income WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void GetNewestIncome()
        {
            
            cmd = new MySqlCommand("SELECT Id FROM income ORDER BY Id DESC LIMIT 1", connection);

            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Id = Int32.Parse(String.Format("{0}", reader["Id"]));
            }
            Id++;
            connection.Close();
        }

        public void Get()
        {
            cmd = new MySqlCommand("SELECT * FROM income WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RecipientId = int.Parse(string.Format("{0}", reader["RecipientId"]));
                Payment = double.Parse(string.Format("{0}", reader["Payment"]));
                PaymentDate = string.Format("{0}", reader["TransactionDate"]);
            }
            connection.Close();
        }
    }
}
