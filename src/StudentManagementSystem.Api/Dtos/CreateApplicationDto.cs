namespace StudentManagementSystem.Api.Dtos;

public class CreateApplicationDto
{
    public int ApplicantId { get; set; }
    public List<object> Documents { get; set; } = new ();
}