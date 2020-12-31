using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerWeb.Models.DB
{
    public partial class Visiting
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? VisitDate { get; set; }
        public bool? NotifyByEmail { get; set; }
        public int? CustomerId { get; set; }
    }
}
