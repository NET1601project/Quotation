using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateRoomsV2
    {
        [Required]
        public string RoomName { get; set; }
        [Required]

        public string Size { get; set; }
        [Required]

        public string Description { get; set; }
        public List<CreateRoomDetail> CreateRoomDetails { get; set; }
    }
}
