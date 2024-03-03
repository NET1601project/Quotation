using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateRoom
    {
        public string RoomName { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
    }
}
