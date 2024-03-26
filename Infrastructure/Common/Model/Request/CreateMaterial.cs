using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateMaterial
    {
        [Required]

        public string MaterialName { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public double UnitPrice { get; set; }
        [Required]

        public int Stock { get; set; }

        public IFormFile Image { get; set; }
    }
}
