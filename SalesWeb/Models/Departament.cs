using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SalesWeb.Models
{
    public class Departament
    {
        public int id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sellers { get; set; } = new List<Saller>();

        public Departament()
        {

        }

        public Departament(int id, string name)
        {
            this.id = id;
            Name = name;
        }
        public void AddSaler(Saller saller)
        {
            Sellers.Add(saller);           
        }

        public double TotalSales (DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
