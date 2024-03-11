using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateMaterial
    {

        public string MaterialName { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public IFormFile Image { get; set; }
    }
}
