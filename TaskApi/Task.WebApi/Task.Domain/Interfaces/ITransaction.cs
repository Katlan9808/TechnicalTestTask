using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Interfaces
{
    public interface ITransaction
    {
        void saveChanges();
    }
}
