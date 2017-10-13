﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FML.BusinessLayer
{
    interface ICustomerController<T>
    {
        void Create(T entity);
        T Get(int id);
    }
}
