using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services
{
    public class DerpartamentService
    {
        private readonly SalesWebContext _context;
        public DerpartamentService(SalesWebContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();

        }
    }
}
