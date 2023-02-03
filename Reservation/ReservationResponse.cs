using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class ReservationResponse
    {
        public pageRequest page { get; set; }
        public areaRequest[] areas { get; set; }
        public recommendedRequest[] recommended { get; set; }
        public formattedRequestModel formattedRequest { get; set; }
        public string availability_id { get; set; }
    }
}
