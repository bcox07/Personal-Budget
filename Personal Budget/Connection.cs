using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Budget
{

    class Connection
    {
        public String connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ..\\..\\Budget.mdb";
        public String getConnection()
        {
            return connectionString;
        }
    }

   
}
