using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Personal_Budget.Models
{
    class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public static List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string accountString = "SELECT * FROM account";
            var cmd = new MySqlCommand(accountString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Account account = new Account
                {
                    AccountId = reader.GetInt32("AccountId"),
                    Name = reader.GetString("Account")
                };

                accounts.Add(account);
            }

            con.Close();
            return accounts;
        }
    }
}
