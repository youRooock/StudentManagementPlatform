using StudentManagementSystem.Domain.Models;

namespace StudentManagementSystem.Domain.Interfaces.Services;

public interface IEducationalInstitutionService
{
    List<Course> ListAvailableCourses(int institutionId);
    void CreateCourse(int institutionId, Course course);
    public Course? FindCourse (int institutionId, int courseId);
    bool AcceptForCourse(int applicantId, int institutionId, int courseId);
    void RemoveFromCourse(int applicantId, int institutionId, int courseId);
}