using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FML.Models
{
    class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        List<SalesLineItem> salesLineItem;
    }
}
