namespace Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppoitmentServices, AppointmentService>();
            services.AddScoped<IAppointmentUseCase, AppointmentUseCase>();

            // Repositories
            services.AddScoped<IRepository<PatientEntity>, PatientRepository>();
            services.AddScoped<IRepository<DoctorEntity>, DoctorRepository>();
            services.AddScoped<IRepository<AppointmentEntity>, AppointmentRepository>();

            return services;
        }

        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainMapper));
            return services;
        }
    }
}
