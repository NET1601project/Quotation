using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateQuoteDetail
    {
        [Required]
        public Guid MaterialId { get; set; }
        [Required]
        public int numberMaterial { get; set; }
    }
}
