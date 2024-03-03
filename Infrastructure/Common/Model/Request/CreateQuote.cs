using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateQuote
    {
        public Guid ProjectID { get; set; }
        public Guid MaterialID { get; set; }
        public int QuoteNumber { get; set; }
        

    }
}
