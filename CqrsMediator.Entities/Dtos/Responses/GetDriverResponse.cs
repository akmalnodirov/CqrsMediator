namespace CqrsMediator.Entities.Dtos.Responses;

public class GetDriverResponse
{
    public Guid DriverId { get; set; }
    public string FullName { get; set; } = String.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
