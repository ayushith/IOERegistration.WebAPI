using IOERegistration.WebAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOEDbContext context;

        public UnitOfWork(IOEDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
