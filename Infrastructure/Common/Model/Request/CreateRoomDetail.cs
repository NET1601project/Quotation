using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateRoomDetail
    {
        public string Name { get; set; }
        public int NumberEquipment { get; set; }
        public string Description { get; set; }
    }
}
