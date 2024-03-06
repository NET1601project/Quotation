using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Staff
    {
        public Staff()
        {
            QuoteDetails = new HashSet<Quote>();
        }
        [Key]
        public Guid StaffId { get; set; }
        public string StaffName { get; set; }
        public string Contact { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Quote> QuoteDetails { get; set; }
    }
}
