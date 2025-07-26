namespace MedLink.Infrastructure.Repositories

{
    public class PatientRepository : IRepository<PatientDto>
    {
        private readonly AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(PatientDto entitie)
        {
            string query = "INSERT INTO public.patient(id, name, email, cpf, bithdate) VALUES (@Id, @Name, @Email, @Cpf, @Bithdate);";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public Task Delete(PatientDto entitie)
        {
            string query = "DELETE FROM public.patient WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public async Task<PatientDto?> Get(Guid idEntitie)
        {
            string query = @"SELECT id, name, email, cpf, bithdate
	            FROM public.patient
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<PatientDto>(query, new { Id = idEntitie });

            return result;
        }

        public async Task<List<PatientDto>> GetAll()
        {
            string query = @"SELECT id, name, email, cpf, bithdate
	            FROM public.patient;";

            var result = await _dbContext.Connection.QueryAsync<PatientDto>(query);

            return result.ToList();
        }

        public Task Update(PatientDto entitie)
        {
            string query = @"UPDATE public.patient
	            SET id=@Id, name=@Name, email=@Email, cpf=@Cpf, bithdate=@Bithdate
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }
    }
}
