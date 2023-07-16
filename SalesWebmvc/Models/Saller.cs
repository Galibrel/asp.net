using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebmvc.Models
{
    public class Saller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]//torna nome obrigatorio
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]//altera o nome
        [DataType(DataType.Date)]//configura a data para tirar hora
        public DateTime birthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString ="{0:F2}")]//arredonda as casa decimal
        [Display(Name = "Base Salary")]
        public double Salary { get; set; }
        

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
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
