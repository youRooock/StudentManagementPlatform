using StudentManagementSystem.Domain.Interfaces.Repositories;
using StudentManagementSystem.Domain.Interfaces.Services;
using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Application.Services;

public class ApplicantsService: IApplicantsService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IApplicationRepository _applicationRepository;

    public ApplicantsService(IApplicationRepository applicationRepository, IApplicantRepository applicantRepository)
    {
        _applicationRepository = applicationRepository;
        _applicantRepository = applicantRepository;
    }

    public Applicant GetApplicantInfo(int applicantId)
    {
        var applicantEntity = _applicantRepository.Find(applicantId);

        if (applicantEntity is null)
            throw new ArgumentException("Applicant not found");
        
        if (!applicantEntity.Activated)
            throw new ArgumentException("Applicant is deactivated");

        return new Applicant
        {
            Name = applicantEntity.Name,
            Email = applicantEntity.Email,
            DateOfBirth = applicantEntity.DateOfBirth,
            AverageScore = applicantEntity.AverageScore,
            Country = applicantEntity.Country
        };
    }

    public Domain.Models.Application CreateApplication(int applicantId, List<object> requiredDocuments)
    {
        throw new NotImplementedException();
    }
}