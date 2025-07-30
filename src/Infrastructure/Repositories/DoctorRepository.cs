namespace MedLink.Infrastructure.Repositories
{
    public class DoctorRepository : IRepository<DoctorEntity>
    {
        private readonly AppDbContext _dbContext;

        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(DoctorEntity entity)
        {
            const string query = @"
                INSERT INTO public.doctor(
                    id, name, email, specialty, crm)
                VALUES (@Id, @Name, @Email, @Specialty, @Crm);";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public Task Delete(DoctorEntity entity)
        {
            const string query = @"DELETE FROM public.doctor WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public async Task<DoctorEntity?> Get(Guid entityId)
        {
            const string query = @"
                SELECT id, name, email, specialty, crm
                FROM public.doctor
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<DoctorEntity>(query, new { Id = entityId });

            return result;
        }

        public async Task<List<DoctorEntity>> GetAll()
        {
            const string query = @"SELECT id, name, email, specialty, crm FROM public.doctor;";

            var result = await _dbContext.Connection.QueryAsync<DoctorEntity>(query);

            return result.ToList();
        }

        public Task Update(DoctorEntity entity)
        {
            const string query = @"
                UPDATE public.doctor
                SET name = @Name,
                    email = @Email,
                    specialty = @Specialty,
                    crm = @Crm
                WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }
    }
}