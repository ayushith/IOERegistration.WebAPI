using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
