using Domain.Entities;

namespace MedLink.Infrastructure.Repositories
{
    public class PatientRepository : IRepository<PatientEntity>
    {
        private readonly AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(PatientEntity entity)
        {
            const string query = @"
                INSERT INTO public.patient(id, name, email, cpf, birthdate) 
                VALUES (@Id, @Name, @Email, @Cpf, @Birthdate);";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public Task Delete(PatientEntity entity)
        {
            const string query = @"DELETE FROM public.patient WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public async Task<PatientEntity?> Get(Guid entityId)
        {
            const string query = @"
                SELECT id, name, email, cpf, birthdate
                FROM public.patient
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<PatientEntity>(query, new { Id = entityId });

            return result;
        }

        public async Task<List<PatientEntity>> GetAll()
        {
            const string query = @"SELECT id, name, email, cpf, birthdate FROM public.patient;";

            var result = await _dbContext.Connection.QueryAsync<PatientEntity>(query);

            return result.ToList();
        }

        public Task Update(PatientEntity entity)
        {
            const string query = @"
                UPDATE public.patient
                SET name = @Name, email = @Email, cpf = @Cpf, birthdate = @Birthdate
                WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }
    }
}