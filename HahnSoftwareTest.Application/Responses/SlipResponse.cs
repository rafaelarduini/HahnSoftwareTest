namespace HahnSoftwareTest.Application.Responses;

public class SlipResponse
{
    public required SlipContents Slip { get; set; }
}

public class SlipContents
{
    public int SlipId { get; set; }
    public required string Advice { get; set; }
}