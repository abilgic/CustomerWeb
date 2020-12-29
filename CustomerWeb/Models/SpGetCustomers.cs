using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWeb.Models
{
    public class SpGetCustomers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TaxId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }
}
