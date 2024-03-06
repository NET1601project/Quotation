using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public Project()
        {
            Rooms = new HashSet<Room>();
            QuoteDetail = new HashSet<Quote>();
        }
        [Key]

        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Quote> QuoteDetail { get; set; }

    }
}

