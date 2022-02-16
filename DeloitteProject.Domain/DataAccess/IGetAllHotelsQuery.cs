using DeloitteProject.Domain.Models;

namespace DeloitteProject.Domain.DataAccess
{
    public interface IGetAllHotelsQuery
    {
        Task<IEnumerable<Hotel>> Execute();
    }
}
