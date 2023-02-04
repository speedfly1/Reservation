namespace Reservation
{
    public class ReservationResponse
    {
        public PageRequest page { get; set; }
        public AreaRequest[] areas { get; set; }
        public RecommendedRequest[] recommended { get; set; }
        public FormattedRequestModel formattedRequest { get; set; }
        public string availability_id { get; set; }
    }
}
