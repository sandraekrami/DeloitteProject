using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;

namespace DeloitteProject.Services
{
    public class NameFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;

        public NameFilter(IGetAllHotelsQuery getAllHotelsQuery)
        {
            this.getAllHotelsQuery = getAllHotelsQuery;
        }

        public async Task<IList<Hotel>> Apply(object filterValue)
        {
            var allHotels = await getAllHotelsQuery.Execute();

            if (filterValue == null || string.IsNullOrEmpty(filterValue.ToString()))
            {
                return allHotels;
            }

            return allHotels.Where(x => x.Name.Contains(filterValue.ToString())).ToList() ?? new List<Hotel>();
        }
    }
}
