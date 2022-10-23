namespace StudentManagementSystem.Domain.Models;

public record Course
{
    public string Name { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public int StudentsCapacity { get; set; }
    public int MinScoreRequired { get; set; }
};