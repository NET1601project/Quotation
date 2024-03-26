using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseStaff
    {
        [Key]

        public Guid StaffId { get; set; }
        public string StaffName { get; set; }
        public string Contact { get; set; }
        public DateTime CreateDate { get; set; }
        public ResponseAccount Account { get; set; }
    }
}
