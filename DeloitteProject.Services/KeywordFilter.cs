using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;

namespace DeloitteProject.Services
{
    public class KeywordFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;

        public KeywordFilter(IGetAllHotelsQuery getAllHotelsQuery)
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

            string keyword = filterValue.ToString();

            return allHotels.Where(x =>
                    x.Name.Contains(keyword) ||
                    x.Description.Contains(keyword) ||
                    x.Location.Contains(keyword))
                .ToList() ?? new List<Hotel>();
        }
    }
}
