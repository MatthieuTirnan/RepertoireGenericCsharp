using FirstGenericRepository.Domain.Entity;

namespace FirstGenericRepository.Domain.Repository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsWithMovie();
    }
}
