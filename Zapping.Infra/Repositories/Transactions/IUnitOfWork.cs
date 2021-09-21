using System;
using System.Collections.Generic;
using System.Text;

namespace Zapping.Infra.Repositories.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
