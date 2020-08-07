using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{
    class RecipientCategory
    {
        public int RecipientCategoryId { get; set; }
        public int RecipientId { get; set; }
        public int CategoryId { get; set; }

        public static List<RecipientCategory> GetRecipientCategories()
        {
            List<RecipientCategory> recipientCategories = new List<RecipientCategory>();
            string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";
            var con = new MySqlConnection(connectionString);

            string recipientString = "SELECT * FROM recipientcategory";
            var cmd = new MySqlCommand(recipientString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                RecipientCategory recipientCategory = new RecipientCategory
                {
                    RecipientCategoryId = reader.GetInt32("RecipientCategoryId"),
                    RecipientId = reader.GetInt32("RecipientId"),
                    CategoryId = reader.GetInt32("CategoryId")
                };

                recipientCategories.Add(recipientCategory);
            }

            con.Close();
            return recipientCategories;
        }

       
    }

}
