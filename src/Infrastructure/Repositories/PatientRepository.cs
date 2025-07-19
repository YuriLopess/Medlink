namespace MedLink.Infrastructure.Repositories
{
    public class PatientRepository : IRepository<PatientEntity>
    {
        private readonly AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(PatientEntity entitie)
        {
            string query = "INSERT INTO public.patient(id, name, email, cpf, bithdate) VALUES (@Id, @Name, @Email, @Cpf, @Bithdate);";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public Task Delete(PatientEntity entitie)
        {
            string query = "DELETE FROM public.patient WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public async Task<PatientEntity?> Get(Guid idEntitie)
        {
            string query = @"SELECT id, name, email, cpf, bithdate
	            FROM public.patient
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<PatientEntity>(query, new { Id = idEntitie });

            return result;
        }

        public async Task<List<PatientEntity>> GetAll()
        {
            string query = @"SELECT id, name, email, cpf, bithdate
	            FROM public.patient;";

            var result = await _dbContext.Connection.QueryAsync<PatientEntity>(query);

            return result.ToList();
        }

        public Task Update(PatientEntity entitie)
        {
            string query = @"UPDATE public.patient
	            SET id=@Id, name=@Name, email=@Email, cpf=@Cpf, bithdate=@Bithdate
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }
    }
}
