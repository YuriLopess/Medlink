namespace MedLink.Infrastructure.Repositories
{
    public class DoctorRepository : IRepository<DoctorDto>
    {
        private readonly AppDbContext _dbContext;

        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(DoctorDto entitie)
        {
            string query = @"INSERT INTO public.doctor(
	            id, name, email, specialty, crm)
	            VALUES (@Id, @Name, @Email, @Specialty, @Crm);";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public Task Delete(DoctorDto entitie)
        {
            string query = @"DELETE FROM public.doctor
            	WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public async Task<DoctorDto?> Get(Guid idEntitie)
        {
            string query = @"SELECT id, name, email, specialty, crm
	            FROM public.doctor
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<DoctorDto>(query, new { Id = idEntitie });

            return result;
        }

        public async Task<List<DoctorDto>> GetAll()
        {
            string query = @"SELECT id, name, email, specialty, crm
	            FROM public.doctor;";

            var result = await _dbContext.Connection.QueryAsync<DoctorDto>(query);

            return result.ToList();
        }

        public Task Update(DoctorDto entitie)
        {
            string query = @"UPDATE public.doctor
	            SET id=@Id, name=@Name, email=@Email, specialty=@Specialty, crm=@Crm
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }
    }
}