using System;
using System.Linq;
using System.Collections;
using NuGet.Protocol.Plugins;

namespace SalesWebmvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sallers { get; set; } = new List<Saller>();//associando o departmento onde tera muitos sellers

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Saller saller)
        {
            Sallers.Add(saller);
        }

        public void RemoveSaller(Saller saller)
        {
            Sallers.Remove(saller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sallers.Sum(saller => saller.TotalSales(initial, final));
        }
    }
}
