using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebmvc.Models
{
    public class Saller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime birthDate { get; set; }

        public double Salary { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();//associaçao para muitos sempre deve ser feita onde vai ter muitos 

        public Saller()
        {
        }

        public Saller(int id, string name, string email, DateTime birthDate, double salary, Department department)///sempre tirar as coleções em construtores com argumento
        {
            Id = id;
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            Salary = salary;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
