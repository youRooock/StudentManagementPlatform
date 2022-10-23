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
        throw new NotImplementedException();
    }

    public Domain.Models.Application CreateApplication(int applicantId, List<object> requiredDocuments)
    {
        throw new NotImplementedException();
    }
}