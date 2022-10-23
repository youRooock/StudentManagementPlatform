using StudentManagementSystem.Domain.Interfaces;
using StudentManagementSystem.Domain.Interfaces.Repositories;
using StudentManagementSystem.Domain.Interfaces.Services;
using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Application.Services;

public class EducationalInstitutionService : IEducationalInstitutionService
{
    private readonly IEducationalInstitutionRepository _institutionRepository;

    public EducationalInstitutionService(IEducationalInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

    public List<Course> ListAvailableCourses(int institutionId)
    {
        throw new NotImplementedException();
    }

    public void CreateCourse(int institutionId, Course course)
    {
        throw new NotImplementedException();
    }

    public Course? FindCourse(int institutionId, int courseId)
    {
        throw new NotImplementedException();
    }

    public bool AcceptForCourse(int applicantId, int institutionId, int courseId)
    {
        throw new NotImplementedException();
    }

    public void RemoveFromCourse(int applicantId, int institutionId, int courseId)
    {
        throw new NotImplementedException();
    }
}