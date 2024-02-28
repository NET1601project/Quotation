using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateProject
    {
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid StaffId { get; set; }
    }
}
