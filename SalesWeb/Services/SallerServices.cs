using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Services.Excepitions;

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

        public Saller FindById(int id)
        {
            return _context.Saller.Include(obj => obj.Deparment).FirstOrDefault(obj => obj.Id == id);
        }
         public void Remove (int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();
        }
        public void Insert (Saller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Saller obj)
        {
             if (!_context.Saller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
            
        }
    }
}
