using System;
using System.Collections.Generic;

#nullable disable

namespace SE1617_Group01_A1.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int? NumberRows { get; set; }
        public int? NumberCols { get; set; }
    }
}
