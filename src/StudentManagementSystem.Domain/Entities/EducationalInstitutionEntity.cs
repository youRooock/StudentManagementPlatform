namespace StudentManagementSystem.Domain.Entities;

public record EducationalInstitutionEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime Created { get; set; }
    public bool Verified { get; set; }
    public bool Removed { get; set; }
    public string LicenseNumber { get; set; } = default!;
    public List<CourseEntity> Courses { get; set; } = new();
};