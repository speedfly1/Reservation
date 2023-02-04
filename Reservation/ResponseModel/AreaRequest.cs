namespace Reservation
{
    public class AreaRequest
    {
        public string id { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public string score { get; set; }
        public OptionRequest[] options { get; set; }

    }
}