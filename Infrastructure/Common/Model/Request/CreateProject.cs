using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateProject
    {
        public string ProjectName { get; set; }
        public DateTime EndDate { get; set; }
        public double Bargain { get; set; }
        public List<CreateRoom> createRooms { get; set; }
    }
}
