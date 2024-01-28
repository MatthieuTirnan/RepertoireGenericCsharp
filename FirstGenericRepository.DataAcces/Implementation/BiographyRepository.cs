using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{

    public class BiographyRepository : GenericRepository<Biography>, IBiographyRepository
    {
        public BiographyRepository(FirstGenericRepositoryDbContext context) : base(context)
        {

        }
    }
}
