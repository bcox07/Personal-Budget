using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{

    class Connection
    {
        public string connectionString = "Server=localhost; Port=3306; DATABASE=personal;UID=root;PWD=test12;";

        public String getConnection()
        {
            return connectionString;
        }
    }

   
}
