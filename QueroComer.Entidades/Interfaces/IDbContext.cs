using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueroComer.Entidades.Interfaces
{
    public interface IDbContext
    { 
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
