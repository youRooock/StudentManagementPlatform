using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Domain.Interfaces.Services;

public interface IMinistryService
{
    List<EducationalInstitution> GetAllInstitutions();
    EducationalInstitution? FindInstitution(string licenseNumber);
}