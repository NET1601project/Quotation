using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseRoomV2
    {
        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public List<ResponseRoomDetail> ResponseRoomDetails { get; set; }
    }
}
