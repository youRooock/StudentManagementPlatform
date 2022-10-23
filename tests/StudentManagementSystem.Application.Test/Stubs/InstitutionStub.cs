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
}