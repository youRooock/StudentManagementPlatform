using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Api.Dtos;
using StudentManagementSystem.Application.Services;
using StudentManagementSystem.Domain.Interfaces.Services;
using StudentManagementSystem.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IApplicantsService, ApplicantsService>();
builder.Services.AddScoped<IMinistryService, MinistryService>();
builder.Services.AddScoped<IEducationalInstitutionService, EducationalInstitutionService>();

var app = builder.Build();

app.Map("/applicants/{id}", (int id, [FromServices] IApplicantsService service) => service.GetApplicantInfo(id));
app.MapPost("/applicants/create-application", (CreateApplicationDto dto, [FromServices] IApplicantsService service) => service.CreateApplication(dto.ApplicantId, dto.Documents));

app.Map("/educational-institutions/{id}", (int id, [FromServices] IEducationalInstitutionService service) => service.ListAvailableCourses(id));
app.MapPost("/educational-institutions/{id}", (int id, Course course, [FromServices] IEducationalInstitutionService service) => service.CreateCourse(id, course));
app.MapPut("/educational-institutions", (AcceptForCourseDto dto, [FromServices] IEducationalInstitutionService service) => service.AcceptForCourse(dto.ApplicantId, dto.InstitutionId, dto.CourseId));

app.Map("/ministry", (IMinistryService service) => service.GetAllInstitutions());
app.Map("/ministry/{license}", (string license, [FromServices] IMinistryService service) => service.FindInstitution(license));

app.Run();