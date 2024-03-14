using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QuoteDetails
    {
        [Key]
        public Guid QuoteId { get; set; }
        [Key]

        public Guid MaterialId { get; set; }
        public int numberMaterial { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Quote Quote { get; set; }
        public Material Material { get; set; }
    }
}
