using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Domain.Interfaces.Services;

public interface IApplicantsService
{
    Applicant GetApplicantInfo(int applicantId);
    Application CreateApplication(int applicantId, List<object> requiredDocuments);
}