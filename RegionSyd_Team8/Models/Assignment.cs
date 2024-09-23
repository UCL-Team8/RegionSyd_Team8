using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd_Team8.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; } = 1;

        public string Description { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public string FromAddress2 { get; set; } = "";
        public string ToAddress2 { get; set; } = "";
        public bool Combined { get; set; }
        public bool Done { get; set; }

        public static int NextID = 1;

        //Test constructor
        public Assignment(string description, DateTime pickUpTime, DateTime dropOffTime, string fromAddress, string toAddress) 
        {
            AssignmentID = NextID;
            NextID++;
            Description = description;
            PickUpTime = pickUpTime;
            DropOffTime = dropOffTime;
            FromAddress = fromAddress;
            ToAddress = toAddress;
        }
    }
}
