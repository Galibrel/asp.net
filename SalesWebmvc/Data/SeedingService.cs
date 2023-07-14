using SalesWebmvc.Model;
using SalesWebmvc.Models;

namespace SalesWebmvc.Data
{
    public class SeedingService
    {
        private SalesWebmvcContext _context;

        public SeedingService()
        {
        }

        public SeedingService(SalesWebmvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Saller.Any() || _context.SalesRecord.Any())
            {
                return; //db com dados populados
            }

        }
    }
}
