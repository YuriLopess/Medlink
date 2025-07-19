namespace MedLink.Infrastructure.Repositories
{
    public class DoctorRepository : IRepository<DoctorEntity>
    {
        private readonly AppDbContext _dbContext;

        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(DoctorEntity entitie)
        {
            string query = @"INSERT INTO public.doctor(
	            id, name, email, specialty, crm)
	            VALUES (@Id, @Name, @Email, @Specialty, @Crm);";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public Task Delete(DoctorEntity entitie)
        {
            string query = @"DELETE FROM public.DoctorEntity
            	WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public async Task<DoctorEntity?> Get(Guid idEntitie)
        {
            string query = @"SELECT id, name, email, specialty, crm
	            FROM public.DoctorEntity
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<DoctorEntity>(query, new { Id = idEntitie });

            return result;
        }

        public async Task<List<DoctorEntity>> GetAll()
        {
            string query = @"SELECT id, name, email, specialty, crm
	            FROM public.DoctorEntity;";

            var result = await _dbContext.Connection.QueryAsync<DoctorEntity>(query);

            return result.ToList();
        }

        public Task Update(DoctorEntity entitie)
        {
            string query = @"UPDATE public.DoctorEntity
	            SET id=@Id, name=@Name, email=@Email, specialty=@Specialty, crm=@Crm
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }
    }
}