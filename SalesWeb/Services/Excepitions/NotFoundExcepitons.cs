using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services.Excepitions
{
    public class NotFoundExcepitons : ApplicationException
    {
        public NotFoundExcepitons (string massege) : base(massege)
        {

        }
    }
}
