using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseQuote
    {
        public Guid QuoteID { get; set; }
        public string QuoteNumber { get; set; }
        public DateTime QuoteDate { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public Guid ProjectID { get; set; }
        public Guid MaterialID { get; set; }
        public Guid StaffId { get; set; }
    }
}
