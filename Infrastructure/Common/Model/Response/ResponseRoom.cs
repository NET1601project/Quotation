using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseRoom
    {
        [Key]

        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
    }
}
