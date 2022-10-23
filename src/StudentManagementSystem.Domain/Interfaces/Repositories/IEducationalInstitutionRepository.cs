using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces.Repositories;

public interface IEducationalInstitutionRepository
{
    void InsertCourse(int id, CourseEntity entity);
    CourseEntity FindCourse(int id, int courseId);
    List<CourseEntity> FindAllCourses(int id);
    void Update(EducationalInstitutionEntity entity);
}