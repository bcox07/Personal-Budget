using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{

    class Connection
    {
        public String connectionString = "Data Source=budgetinstance.cmog5krjfemw.us-east-2.rds.amazonaws.com,1433; Initial Catalog=Budget; User ID=master; Password=password;";
        public String getConnection()
        {
            return connectionString;
        }
    }

   
}
