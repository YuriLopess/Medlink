var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IAppoitmentServices, AppointmentService>();
builder.Services.AddScoped<IRepository<PatientEntity>, PatientRepository>();
builder.Services.AddScoped<IRepository<DoctorEntity>, DoctorRepository>();
builder.Services.AddScoped<IRepository<AppointmentEntity>, AppointmentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();