namespace StudentManagementSystem.Domain.Entities;

public record ApplicantEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public bool Activated { get; set; }
    public decimal AverageScore { get; set; }
    public string Country { get; set; } = default!;
    public DateTime RegistrationDate { get; set; }
    public DateTime LastVisitedDate { get; set; }
}