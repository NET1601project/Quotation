using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateQuote
    {
        public Guid QuoteID { get; set; }
        public string QuoteNumber { get; set; }
        public double TotalAmount { get; set; }
        public Guid ProjectID { get; set; }
        public Guid MaterialID { get; set; }
        public Guid EquipmentID { get; set; }
    }
}
