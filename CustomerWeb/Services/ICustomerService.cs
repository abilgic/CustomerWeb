using CustomerWeb.Models;
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
        Task<int> AddCustomer(Customer Customer);
        Task<int> UpdateCustomer(Customer Customer);
        Task<int> DeleteCustomer(int Id);
        Task<int> AddVisit(Visiting Visiting);
        Task<int> UpdateVisit(Visiting Visiting);
        Task<List<Visiting>> GetVisitDetail(int Id);
        Task<List<Visiting>> GetVisitList(int CustomerId);
         Task<int> DeleteVisit(int Id);
    }
}
