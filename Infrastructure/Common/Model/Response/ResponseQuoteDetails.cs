using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseQuoteDetails
    {
        [Key]

        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string image {  get; set; }
        public int NumberMaterial { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
