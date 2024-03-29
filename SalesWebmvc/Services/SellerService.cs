﻿using SalesWebmvc.Model;
using SalesWebmvc.Models;
using System.Security.AccessControl;
using System.Security.Permissions;
using Microsoft.EntityFrameworkCore;
using SalesWebmvc.Services.Exceptions;

namespace SalesWebmvc.Services
{
    public class SellerService
    {
        private readonly SalesWebmvcContext _context;

        public SellerService(SalesWebmvcContext context)//injeção de dependencia
        {
            _context = context;
        }

        public List<Saller> FindAll()//criando a lista para ser apresentada em tela na tabela da grid
        {
            return _context.Saller.ToList();
        }

        public void Insert(Saller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Saller FindById(int id)
        {
            return _context.Saller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Saller obj)
        {
            if (!_context.Saller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Saller.Update(obj);
                _context.SaveChanges();

            }
            catch(DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}
