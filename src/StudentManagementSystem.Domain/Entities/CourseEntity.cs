namespace StudentManagementSystem.Domain.Entities;

public record CourseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public DateTime Created { get; set; }
    public int StudentsCapacity { get; set; }
    public int MinScoreRequired { get; set; }
};