using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using Microsoft.Extensions.Logging;

namespace DeloitteProject.Services
{
    public class KeywordFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;
        private readonly ILogger<KeywordFilter> logger;

        public KeywordFilter(IGetAllHotelsQuery getAllHotelsQuery, ILogger<KeywordFilter> logger)
        {
            this.getAllHotelsQuery = getAllHotelsQuery;
            this.logger = logger;
        }

        public async Task<IEnumerable<Hotel>> Apply(object filterValue)
        {
            logger.LogInformation("Filtering hotels by keyword");
            IEnumerable<Hotel>? allHotels = await getAllHotelsQuery.Execute();

            if (filterValue == null || string.IsNullOrEmpty(filterValue.ToString()))
            {
                return allHotels;
            }

            string keyword = filterValue.ToString();

            return allHotels.Where(x =>
                    x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    x.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    x.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList() ?? new List<Hotel>();
        }
    }
}
