using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QuoteDetails
    {
        public Guid QuoteId { get; set; }
        public Guid MaterialId { get; set; }
        public int numberMaterial { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Quote Quote { get; set; }
        public Material Material { get; set; }
    }
}
