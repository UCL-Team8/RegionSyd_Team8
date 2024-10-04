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

        public string Description2 { get; set; } = "";
        public string FromAddress2 { get; set; } = "";
        public string ToAddress2 { get; set; } = "";
        public DateTime PickUpTime2 { get; set; }
        public DateTime DropOffTime2 { get; set; }

        public bool Combined { get; set; }
        public bool Done { get; set; }

        public static int NextID = 1;

        //Test constructor

        public Assignment()
        {
            AssignmentID = NextID++;
        }
        public Assignment(string description, DateTime pickUpTime, DateTime dropOffTime, string fromAddress, string toAddress, bool combined, bool done)
        {
            AssignmentID = NextID;
            NextID++;
            Description = description;
            PickUpTime = pickUpTime;
            DropOffTime = dropOffTime;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Combined = combined;
            Done = done;
        }

        public Assignment(string description, string description2, DateTime pickUpTime, DateTime dropOffTime, DateTime pickUpTime2, DateTime dropOffTime2, string fromAddress, string toAddress, string fromAddress2, string toAddress2, bool combined, bool done)
        {
            AssignmentID = NextID;
            NextID++;
            Description = description;
            Description2 = description2;
            PickUpTime = pickUpTime;
            DropOffTime = dropOffTime;
            PickUpTime2 = pickUpTime2;
            DropOffTime2 = dropOffTime2;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            FromAddress2 = fromAddress2;
            ToAddress2 = toAddress2;
            Combined = combined;
            Done = done;
        }

    }
}
