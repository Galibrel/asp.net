using System.Collections.Generic;

namespace SalesWebmvc.Models.ViewModels
{
    public class SallerFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Department> Departments  { get; set; }


    }
}
