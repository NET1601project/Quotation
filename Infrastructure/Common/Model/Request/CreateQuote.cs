using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateQuote
    {
        [Required]

        public Guid ProjectID { get; set; }
        [Required]

        public Guid MaterialID { get; set; }
        [Required]

        public int QuoteNumber { get; set; }
        

    }
}
