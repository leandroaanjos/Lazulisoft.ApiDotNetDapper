using Lazulisoft.ApiDotNetDapper.Api.Models;
using System.Threading.Tasks;

namespace Lazulisoft.ApiDotNetDapper.Api.Repositories
{
    public interface IHeroRepository : IGenericRepository<Hero>
    {
        Task<Hero> GetHeroByName(string name);
    }
}
