using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseProjectV2
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public double Bargain { get; set; }

        public Guid CustomerId { get; set; }
        public List<ResponseRoomV2> RoomList { get; set; }
    }
}
