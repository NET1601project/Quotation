using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateStaff
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string StaffName { get; set; }
        public string Contact { get; set; }

    }
}
