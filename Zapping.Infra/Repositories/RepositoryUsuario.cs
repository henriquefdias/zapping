using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zapping.Domain.Entities;
using Zapping.Domain.Interfaces.Repositories;
using Zapping.Infra.Repositories.Base;

namespace Zapping.Infra.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly ZappingContext _context;
        public RepositoryUsuario(ZappingContext context) : base(context)
        {
            _context = context;
        }

    }
}
