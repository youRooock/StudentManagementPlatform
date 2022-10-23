namespace StudentManagementSystem.Domain.Models;

public record Application
{
    public Applicant ApplicantInfo { get; set; } = default!;
    public List<object> RequiredDocuments { get; set; } = new ();
};