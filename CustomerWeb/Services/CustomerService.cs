using CustomerWeb.Models;
using CustomerWeb.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;

namespace CustomerWeb.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerWebDbContext _context;

        public CustomerService(CustomerWebDbContext context)
        {
            _context = context;
        }         

        public async Task<int> AddCustomer()
        {
            var rowsAffected = 0;
            try
            {

                using (_context)
                {
                    var Name = "Ali";
                    var TaxId = 222222;
                    var CreateDate = DateTime.Now;
                    var PhoneNumber = "9999999";
                    var Address = "İzmir Karşıyaka";
                    var City = "İzmir";
                    var Town = "Karşıyaka";

                    rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SpAddCustomer @Name={Name}, @TaxId={TaxId}, @CreateDate={CreateDate}, @PhoneNumber={PhoneNumber}, @Address={Address}, @City={City}, @Town={Town}");

                  
                }
            } catch(Exception e)
            { 
                throw e;
            }

            return rowsAffected;
        }

        public async Task<List<Customer>> GetCustomerList()
        {
           

            var CustomerList = await  _context.Customers
                               .FromSqlRaw("SpGetCustomers")
                               .ToListAsync();
            return CustomerList;
        }

        public async Task<List<Customer>> GetCustomerDetail(int Id)
        {

            var Customers = await  _context.Customers
                               .FromSqlRaw("SpGetCustomerDetail {0}",Id).ToListAsync();
           
            return Customers;
        }
    }
}
