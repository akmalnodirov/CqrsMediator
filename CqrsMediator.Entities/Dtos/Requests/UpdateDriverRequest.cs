namespace CqrsMediator.Entities.Dtos.Requests;

public class UpdateDriverRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void Something()
    {
        Console.WriteLine("write something");
    }
}
