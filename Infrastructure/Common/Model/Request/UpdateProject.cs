using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class UpdateProject
    {
        public string ProjectName { get; set; }
        public DateTime EndDate { get; set; }
        public double Bargain { get; set; }
    }
}
