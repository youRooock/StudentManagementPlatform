using AutoFixture;
using FakeItEasy;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Test.Stubs;

public static class ApplicantStub
{
    private static readonly Fixture Fixture = new();
    
    public static ApplicantEntity Get(bool isActive)
    {
        return new ApplicantEntity
        {
            Id = Fixture.Create<int>(),
            Name = Fixture.Create<string>(),
            Email = Fixture.Create<string>(),
            DateOfBirth = Fixture.Create<DateTime>(),
            Activated = isActive, 
            AverageScore = Fixture.Create<decimal>(), 
            Country = Fixture.Create<string>(),
            RegistrationDate = Fixture.Create<DateTime>(),
            LastVisitedDate = Fixture.Create<DateTime>()
        };
    }
}