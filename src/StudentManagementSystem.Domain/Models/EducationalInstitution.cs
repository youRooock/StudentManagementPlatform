namespace StudentManagementSystem.Domain.Models;

public class EducationalInstitution
{
    public string Name { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public List<Course> Courses { get; set; } = new();
}