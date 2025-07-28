namespace MedLink.Domain.Interfaces.Repositories
{
    public interface IRepository<Dto>
    {
        Task Add(Dto dto);
        Task Update(Dto dto);
        Task Delete(Dto dto);
        Task<Dto?> Get(Guid entityId);
        Task<List<Dto>> GetAll();
    }
}
