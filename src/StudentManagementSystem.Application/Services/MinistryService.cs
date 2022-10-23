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
        throw new NotImplementedException();
    }

    public EducationalInstitution? FindInstitution(string licenseNumber)
    {
        throw new NotImplementedException();
    }
}