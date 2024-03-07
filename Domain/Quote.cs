using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Quote
    {

        [Key]
        public Guid QuoteID { get; set; }
        public int QuoteNumber { get; set; }
        public DateTime QuoteDate { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public Guid ProjectID { get; set; }
        public Guid StaffId { get; set; }
        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public ICollection<QuoteDetails> QuoteDetails { get; set; } = new List<QuoteDetails>();
    }
}
