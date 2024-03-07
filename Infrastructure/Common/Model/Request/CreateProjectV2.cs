using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateProjectV2
    {
        public string ProjectName { get; set; }
        public DateTime EndDate { get; set; }
        public List<CreateRoomsV2> createRooms { get; set; }
    }
}
