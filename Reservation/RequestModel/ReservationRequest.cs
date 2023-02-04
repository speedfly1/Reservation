using System;

public class ReservationRequest
{
    public string slug { get; set; }
    public string locale { get; set; }
    public SearchCriteria criteria { get; set; }
}
