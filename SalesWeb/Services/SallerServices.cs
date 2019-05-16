using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services
{
    public class SallerServices
    {
        private readonly SalesWebContext _context;
        public SallerServices (SalesWebContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();

        }

        public void Insert (Saller obj)
        {
             obj.Deparment = _context.Departament.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
