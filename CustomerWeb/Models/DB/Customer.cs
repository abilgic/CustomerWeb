using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerWeb.Models.DB
{
    public partial class Customer
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
