﻿using Domain;
using Infrastructure.Common.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ICustomerService
    {
        Task <Customer> Add(CreateCustomer create);
    }
}
