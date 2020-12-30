﻿using CustomerWeb.Models;
using CustomerWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWeb.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerList();
        Task<List<Customer>> GetCustomerDetail(int Id);
        Task<int> AddCustomer();
    }
}
