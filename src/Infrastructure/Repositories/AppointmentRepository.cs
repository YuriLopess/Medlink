namespace Infrastructure.Repositories
{
    public class AppointmentRepository : IRepository<AppointmentEntity>
    {
        private readonly AppDbContext _dbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Task Add(AppointmentEntity entitie)
        {
            string query = @"INSERT INTO public.appointment(
                id, title, datetime, status, Doctorid, Patientid, createddate)
                VALUES (@Id, @Title, @DateTime, @Status, @DoctorEntityId, @PatientEntityId, @CreatedDate);";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public Task Delete(AppointmentEntity entitie)
        {
            string query = @"DELETE FROM public.appointment
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }

        public async Task<AppointmentEntity?> Get(Guid idEntitie)
        {
            string query = @"SELECT id, title, datetime, status, doctorid, patientid, createddate
                     FROM public.appointment
                     WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<AppointmentEntity>(query, new { Id = idEntitie });

            return result;
        }

        public async Task<List<AppointmentEntity>> GetAll()
        {
            string query = @"SELECT id, title, datetime, status, doctorid, patientid, createddate
                     FROM public.appointment;";

            var result = await _dbContext.Connection.QueryAsync<AppointmentEntity>(query);

            return result.ToList();
        }

        public Task Update(AppointmentEntity entitie)
        {
            string query = @"UPDATE public.appointment
	            SET id=@Id, title=@Title, datetime=@DateTime, status=@Status, doctorid=@DoctorId, PatientEntityid=@PatientId, createddate=@CreatedDate
	            WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entitie);

            return Task.CompletedTask;
        }
    }
}
