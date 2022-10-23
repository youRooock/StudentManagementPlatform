using FakeItEasy;
using StudentManagementSystem.Application.Services;
using StudentManagementSystem.Application.Test.Stubs;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces.Repositories;
using StudentManagementSystem.Domain.Interfaces.Services;
using Xunit;

namespace StudentManagementSystem.Application.Test.Services;

public class EducationalInstitutionServiceTests
{
    private readonly IEducationalInstitutionRepository _institutionRepository;
    private readonly IEducationalInstitutionService _institutionService;
    private const int InstitutionId = 1;

    public EducationalInstitutionServiceTests()
    {
        _institutionRepository = A.Fake<IEducationalInstitutionRepository>();
        _institutionService = new EducationalInstitutionService(_institutionRepository);
    }

    [Fact]
    public void ShouldListAvailableCourses()
    {
        var coursesStub = InstitutionStub.GetCourses();
        A.CallTo(() => _institutionRepository.FindAllCourses(InstitutionId)).Returns(coursesStub);
        var availableCourses = _institutionService.ListAvailableCourses(InstitutionId);
        
        Assert.Equal(coursesStub.Count, availableCourses.Count);
    }
    
    [Fact]
    public void ShouldThrowIfNoCoursesAvailable()
    {
        A.CallTo(() => _institutionRepository.FindAllCourses(InstitutionId)).Returns(Enumerable.Empty<CourseEntity>().ToList());

        Assert.Throws<ArgumentException>(() => _institutionService.ListAvailableCourses(InstitutionId));
    }
}