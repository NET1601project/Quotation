using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseQuoteV2
    {
        [Key]

        public Guid QuoteID { get; set; }
        public Guid ProjectID { get; set; }
        public string NameProject { get; set; }

        public DateTime QuoteDate { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public Guid StaffId { get; set; }
        public List<ResponseQuoteDetails> ResponseQuoteDetails { get; set; }
    }
}
