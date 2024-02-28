using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Response
{
    public class ResponseEquipment
    {
        public Guid EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Note { get; set; }
        public double UnitPrice { get; set; }
    }
}
