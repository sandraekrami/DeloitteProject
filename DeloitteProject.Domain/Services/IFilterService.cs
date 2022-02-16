using DeloitteProject.Domain.Models;

namespace DeloitteProject.Domain.Services
{
    public interface IFilterService
    {
        Task<IEnumerable<Hotel>> Apply(object filterValue);
    }
}
