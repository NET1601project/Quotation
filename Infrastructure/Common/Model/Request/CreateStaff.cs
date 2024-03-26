using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateStaff
    {
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string StaffName { get; set; }
        [Required]

        public string Contact { get; set; }

    }
}
