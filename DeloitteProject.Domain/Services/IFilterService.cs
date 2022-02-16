using DeloitteProject.Domain.Models;

namespace DeloitteProject.Domain.Services
{
    public interface IFilterService
    {
        Task<IList<Hotel>> Apply(object filterValue);
    }
}
