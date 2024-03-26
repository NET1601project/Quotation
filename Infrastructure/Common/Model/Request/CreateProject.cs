using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Model.Request
{
    public class CreateProject
    {
        [Required]

        public string ProjectName { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]

        public double Bargain { get; set; }
        [Required]

        public List<CreateRoom> createRooms { get; set; }
    }
}
