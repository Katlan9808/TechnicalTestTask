using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Interfaces;

namespace Task.Application.Interfaces
{
    public interface IBaseService<T, TId> : IAdd<T>, IEdit<T>, IDelete<TId>, IListE<T, TId>
    {

    }
}
