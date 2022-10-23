namespace StudentManagementSystem.Domain.Entities;

public record ApplicationEntity
{
    public int Id { get; set; }
    public ApplicantEntity ApplicantInfo { get; set; } = default!;
    public DateTime CreationDate { get; set; }
    public List<object> RequiredDocuments { get; set; } = new ();
}