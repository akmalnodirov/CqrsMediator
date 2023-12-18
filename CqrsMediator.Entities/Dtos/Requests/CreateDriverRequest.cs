namespace CqrsMediator.Entities.Dtos.Requests;

public class CreateDriverRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
