using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Connection
    {
        public SqlConnection db = null;

        public Connection()
        {
            db = new SqlConnection("");
        }
    }
}
