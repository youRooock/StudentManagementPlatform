using FakeItEasy;
using StudentManagementSystem.Application.Services;
using StudentManagementSystem.Application.Test.Stubs;
using StudentManagementSystem.Domain.Interfaces.Repositories;
using Xunit;

namespace StudentManagementSystem.Application.Test.Services;

public class ApplicantsServiceTests
{
    private readonly ApplicantsService _applicantsService;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IApplicationRepository _applicationRepository;
    private const int ApplicantId = 1;
    private const int NotExistingApplicantId = 2;

    public ApplicantsServiceTests()
    {
        _applicantRepository = A.Fake<IApplicantRepository>();
        _applicationRepository = A.Fake<IApplicationRepository>();
        _applicantsService = new ApplicantsService(_applicationRepository, _applicantRepository);
    }

    [Fact]
    public void ShouldGetApplicantsInformation()
    {
        var applicantEntity = ApplicantStub.Get(true);
        A.CallTo(() => _applicantRepository.Find(ApplicantId)).Returns(applicantEntity);
        var applicantInfo = _applicantsService.GetApplicantInfo(ApplicantId);

        Assert.Multiple(
            () => Assert.Equal(applicantEntity.Country, applicantInfo.Country),
            () => Assert.Equal(applicantEntity.Email, applicantInfo.Email),
            () => Assert.Equal(applicantEntity.Name, applicantInfo.Name),
            () => Assert.Equal(applicantEntity.AverageScore, applicantInfo.AverageScore),
            () => Assert.Equal(applicantEntity.DateOfBirth, applicantInfo.DateOfBirth)
        );
    }

    [Fact]
    public void ShouldThrowIfApplicantNotFound()
    {
        A.CallTo(() => _applicantRepository.Find(NotExistingApplicantId)).Returns(null);
        
        Assert.Throws<ArgumentException>(() => _applicantsService.GetApplicantInfo(NotExistingApplicantId));
    }

    [Fact]
    public void ShouldThrowIfApplicantIsDeactivated()
    {
        var applicantEntity = ApplicantStub.Get(false);
        A.CallTo(() => _applicantRepository.Find(ApplicantId)).Returns(applicantEntity);

        Assert.Throws<ArgumentException>(() => _applicantsService.GetApplicantInfo(ApplicantId));
    }
}