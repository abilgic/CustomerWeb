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

        public async Task<int> AddCustomer(Customer Customer)
        {
            var rowsAffected = 0;
            try
            {
                using (_context)
                {
                    rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SpAddCustomer @Name={Customer.Name}, @TaxId={Customer.TaxId}, @CreateDate={Customer.CreateDate}, @PhoneNumber={Customer.PhoneNumber}, @Address={Customer.Address}, @City={Customer.City}, @Town={Customer.Town}");                  
                }
            } catch(Exception e)
            { 
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> UpdateCustomer(Customer Customer)
        {
            var rowsAffected = 0;
            try
            {

                using (_context)
                {
                    rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SpUpdateCustomer @Id={Customer.Id}, @Name={Customer.Name}, @TaxId={Customer.TaxId}, @CreateDate={Customer.CreateDate}, @PhoneNumber={Customer.PhoneNumber}, @Address={Customer.Address}, @City={Customer.City}, @Town={Customer.Town}");


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteCustomer(int Id)
        {
            var rowsAffected = 0;
            try
            {
                using (_context)
                {                          

                    rowsAffected = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SpDeleteCustomer @Id={Id}");

                }
            }
            catch (Exception e)
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
