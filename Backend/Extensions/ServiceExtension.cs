using Backend.Services;

namespace Backend.Extensions;

public static class ServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CityService>();
        services.AddScoped<RegistrationService>();
        services.AddScoped<RegistrationConfirmationService>();
        services.AddScoped<CanteenService>();
        services.AddScoped<DistrictService>();
        services.AddScoped<TeacherService>();
        services.AddScoped<ParentService>();
        services.AddScoped<PasswordService>();
        services.AddScoped<ClassService>();
        services.AddScoped<StudentService>();
    }
}