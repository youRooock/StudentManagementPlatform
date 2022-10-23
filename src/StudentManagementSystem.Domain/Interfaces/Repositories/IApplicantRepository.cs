using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces.Repositories;

public interface IApplicantRepository
{
    ApplicantEntity Find(int id);
}