using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseRoomDetail
    {
        public Guid RoomDetailId { get; set; }
        public string Name { get; set; }
        public int NumberEquipment { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
