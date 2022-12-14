using StudentManagementSystem.Domain.Interfaces;
using StudentManagementSystem.Domain.Interfaces.Repositories;
using StudentManagementSystem.Domain.Interfaces.Services;
using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Application.Services;

public class MinistryService: IMinistryService
{
    private readonly IEducationalInstitutionRepository _institutionRepository;

    public MinistryService(IEducationalInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

    public List<EducationalInstitution> GetAllInstitutions()
    {
        var entities = _institutionRepository.GetAll();

        if (!entities.Any())
            throw new ArgumentException("No institutions found");

        return entities.Select(e => new EducationalInstitution
        {
            Name = e.Name,
            LicenseNumber = e.LicenseNumber,
            Courses = e.Courses.Select(c => new Course
            {
                MinScoreRequired = c.MinScoreRequired,
                Name = c.Name,
                StartTime = c.StartTime,
                StudentsCapacity = c.MinScoreRequired
            }).ToList()
        }).ToList();
    }

    public EducationalInstitution? FindInstitution(string licenseNumber)
    {
        var institutionEntity = _institutionRepository.Find(licenseNumber);

        if (institutionEntity.Removed)
            throw new ArgumentException("Institution deactivated");
        if (!institutionEntity.Verified)
            throw new ArgumentException("Institution not verified");

        return new EducationalInstitution
        {
            Name = institutionEntity.Name,
            LicenseNumber = institutionEntity.LicenseNumber,
            Courses = institutionEntity.Courses.Select(e => new Course
            {
                Name = e.Name,
                StartTime = e.StartTime,
                StudentsCapacity = e.StudentsCapacity,
                MinScoreRequired = e.MinScoreRequired
            }).ToList()
        };
    }
}