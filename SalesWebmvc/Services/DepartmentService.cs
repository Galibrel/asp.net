using SalesWebmvc.Model;
using SalesWebmvc.Models;

namespace SalesWebmvc.Services
{
    public class DepartmentService
    {

        private readonly SalesWebmvcContext _context;

        public DepartmentService(SalesWebmvcContext context)//injeção de dependencia
        {
            _context = context;
        }

        public List<Department>FindAll()
        {
            return _context.Department.OrderBy(x =>x.Name).ToList();
        }
    }
}
