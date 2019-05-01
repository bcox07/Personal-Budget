using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{

    class Connection
    {
        public String connectionString = "Data Source=DESKTOP-PG47RQQ;Initial Catalog=Budget;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        public String getConnection()
        {
            return connectionString;
        }
    }

   
}
