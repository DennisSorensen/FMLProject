using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FML.BusinessLayer
{
    public interface ICustomerController<T>
    {
        void Create(T Customer);
        void FindByCustomerId(int CustomerId);
        void Update(T entity);
        void Delete(int id);
        T Get(int id);
    }
}
