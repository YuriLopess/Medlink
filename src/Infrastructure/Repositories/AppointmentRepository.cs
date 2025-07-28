using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : IRepository<AppointmentEntity>
    {
        private readonly AppDbContext _dbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Task Add(AppointmentEntity entity)
        {
            const string query = @"
                INSERT INTO public.appointment(
                    id, title, datetime, status, doctorid, patientid, createddate)
                VALUES (
                    @Id, @Title, @DateTime, @Status, @DoctorId, @PatientId, @CreatedDate);";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public Task Delete(AppointmentEntity entity)
        {
            const string query = @"DELETE FROM public.appointment WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }

        public async Task<AppointmentEntity?> Get(Guid entityId)
        {
            const string query = @"
                SELECT id, title, datetime, status, doctorid, patientid, createddate
                FROM public.appointment
                WHERE id = @Id;";

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<AppointmentEntity>(
                query, new { Id = entityId });

            return result;
        }

        public async Task<List<AppointmentEntity>> GetAll()
        {
            const string query = @"
                SELECT id, title, datetime, status, doctorid, patientid, createddate
                FROM public.appointment;";

            var result = await _dbContext.Connection.QueryAsync<AppointmentEntity>(query);

            return result.ToList();
        }

        public Task Update(AppointmentEntity entity)
        {
            const string query = @"
                UPDATE public.appointment
                SET title = @Title,
                    datetime = @DateTime,
                    status = @Status,
                    doctorid = @DoctorId,
                    patientid = @PatientId,
                    createddate = @CreatedDate
                WHERE id = @Id;";

            _dbContext.Connection.Execute(sql: query, param: entity);

            return Task.CompletedTask;
        }
    }
}