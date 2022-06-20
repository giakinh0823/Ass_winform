﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SE1617_Group01_A1.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public string SeatStatus { get; set; }
        public decimal? Amount { get; set; }
    }
}
