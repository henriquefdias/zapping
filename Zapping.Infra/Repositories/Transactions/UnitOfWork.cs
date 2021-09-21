using System;
using System.Collections.Generic;
using System.Text;
using Zapping.Infra.Repositories.Base;

namespace Zapping.Infra.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZappingContext _context;

        public UnitOfWork(ZappingContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
