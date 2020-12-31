using CustomerWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWeb.Models
{
    public class GetModel
    {
        public Customer Customer { get; set; }
        public List<Visiting> Visitings { get; set; }
    }
}
