namespace StudentManagementSystem.Api.Dtos;

public record AcceptForCourseDto
{
    public int ApplicantId { get; set; }
    public int InstitutionId { get; set; }
    public int CourseId { get; set; }
}