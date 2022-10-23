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
        A.CallTo(() => _institutionRepository.FindAllCourses(InstitutionId))
            .Returns(Enumerable.Empty<CourseEntity>().ToList());

        Assert.Throws<ArgumentException>(() => _institutionService.ListAvailableCourses(InstitutionId));
    }

    [Fact]
    public void ShouldFindCourse()
    {
        var institutionEntity = InstitutionStub.Get("test", verified: true, removed: false);
        var expectedCourse = institutionEntity.Courses[0];
        A.CallTo(() => _institutionRepository.FindCourse(institutionEntity.Id, expectedCourse.Id)).Returns(expectedCourse);
        var course = _institutionService.FindCourse(institutionEntity.Id, expectedCourse.Id)!;

        Assert.Multiple(
            () => Assert.Equal(expectedCourse.Name, course.Name),
            () => Assert.Equal(expectedCourse.StartTime, course.StartTime),
            () => Assert.Equal(expectedCourse.StudentsCapacity, course.StudentsCapacity),
            () => Assert.Equal(expectedCourse.MinScoreRequired, course.MinScoreRequired)
        );
    }
    
    [Fact]
    public void ShouldThrowIfCourseNotFound()
    {
        var institutionEntity = InstitutionStub.Get("test", verified: true, removed: false);
        var expectedCourse = institutionEntity.Courses[0];
        A.CallTo(() => _institutionRepository.FindCourse(institutionEntity.Id, expectedCourse.Id)).Returns(null);
        
        Assert.Throws<ArgumentException>(() => _institutionService.FindCourse(institutionEntity.Id, expectedCourse.Id));
    }
}