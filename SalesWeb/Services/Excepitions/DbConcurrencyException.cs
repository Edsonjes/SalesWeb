using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services.Excepitions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string massage) : base(massage)
        {

        }
    }
}
