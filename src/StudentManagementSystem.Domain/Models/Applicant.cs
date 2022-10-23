namespace StudentManagementSystem.Domain.Models;

public record Applicant
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public decimal AverageScore { get; set; }
    public string Country { get; set; } = default!;
}