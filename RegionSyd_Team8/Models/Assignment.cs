using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd_Team8.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }

        public string Description { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public string FromAddress2 { get; set; } = "";
        public string ToAddress2 { get; set; } = "";
        public bool Combined { get; set; }
        public bool Done { get; set; }
        
        
    }
}
