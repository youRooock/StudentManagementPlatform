using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces.Repositories;

public interface IApplicationRepository
{
    void Insert(ApplicationEntity entity);
}