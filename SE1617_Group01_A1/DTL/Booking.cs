using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciname.DTL
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        public string SeatStatus { get; set; }
        public decimal Amount { get; set; }
    }
}
