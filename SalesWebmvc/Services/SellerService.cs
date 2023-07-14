using SalesWebmvc.Model;
using SalesWebmvc.Models;
using System.Security.AccessControl;

namespace SalesWebmvc.Services
{
    public class SellerService
    {
        private readonly SalesWebmvcContext _context;

        public SellerService(SalesWebmvcContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }
    }
}
