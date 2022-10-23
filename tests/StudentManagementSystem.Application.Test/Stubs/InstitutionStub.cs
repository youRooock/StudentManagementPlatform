using AutoFixture;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Test.Stubs;

public static class InstitutionStub
{
    private static readonly Fixture Fixture = new();
    
    public static List<CourseEntity> GetCourses()
    {
        return Fixture.Create<List<CourseEntity>>();
    }
    
    public static EducationalInstitutionEntity Get(string licenseNumber, bool verified, bool removed)
    {
        return new EducationalInstitutionEntity
        {
            Id = Fixture.Create<int>(),
            Name = Fixture.Create<string>(),
            Created = Fixture.Create<DateTime>(),
            Verified = verified,
            Removed = removed,
            LicenseNumber = licenseNumber,
            Courses = Fixture.Create<List<CourseEntity>>()
        };
    }
    
    public static List<EducationalInstitutionEntity> GetMany()
    {
        return Fixture.Create<List<EducationalInstitutionEntity>>();
    }
}