using FakeItEasy;
using StudentManagementSystem.Application.Services;
using StudentManagementSystem.Application.Test.Stubs;
using StudentManagementSystem.Domain.Interfaces.Repositories;
using StudentManagementSystem.Domain.Interfaces.Services;
using Xunit;

namespace StudentManagementSystem.Application.Test.Services;

public class MinistryServiceTests
{
    private readonly IEducationalInstitutionRepository _institutionRepository;
    private readonly IMinistryService _ministryService;
    private const string LicenseNumber = "QRN2057";

    public MinistryServiceTests()
    {
        _institutionRepository = A.Fake<IEducationalInstitutionRepository>();
        _ministryService = new MinistryService(_institutionRepository);
    }

    [Fact]
    public void ShouldSearchInstitution()
    {
        var institutionEntity = InstitutionStub.Get(LicenseNumber, verified:true, removed:false);
        A.CallTo(() => _institutionRepository.Find(institutionEntity.LicenseNumber)).Returns(institutionEntity);
        var institution = _ministryService.FindInstitution(institutionEntity.LicenseNumber)!;

        Assert.Multiple(
            () => Assert.Equal(institutionEntity.LicenseNumber, institution.LicenseNumber),
            () => Assert.Equal(institutionEntity.Name, institution.Name),
            () => Assert.Equal(institutionEntity.Courses.Count, institution.Courses.Count)
        );
    }
    
    [Fact]
    public void ShouldThrowIfInstitutionNotVerified()
    {
        A.CallTo(() => _institutionRepository.Find(LicenseNumber)).Returns(InstitutionStub.Get(LicenseNumber, verified:false, removed:false));

        Assert.Throws<ArgumentException>(() => _ministryService.FindInstitution(LicenseNumber));
    }
    
    [Fact]
    public void ShouldThrowIfInstitutionDeactivated()
    {
        A.CallTo(() => _institutionRepository.Find(LicenseNumber)).Returns(InstitutionStub.Get(LicenseNumber, verified:true, removed:true));

        Assert.Throws<ArgumentException>(() => _ministryService.FindInstitution(LicenseNumber));
    }
}