using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("server=DESKTOP-59GB3J6;database=CustomerLib_Melenteva;Trusted_Connection=True");
        }
    }
}
