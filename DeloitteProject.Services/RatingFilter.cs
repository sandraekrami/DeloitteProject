using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;

namespace DeloitteProject.Services
{
    public class RatingFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;

        public RatingFilter(IGetAllHotelsQuery getAllHotelsQuery)
        {
            this.getAllHotelsQuery=getAllHotelsQuery;
        }

        public async Task<IList<Hotel>> Apply(object filterValue)
        {
            if (!IsInteger(filterValue))
            {
                throw new InvalidOperationException("Value is not an integer.");
            }

            int rating = (int)filterValue;
            var allHotels = await getAllHotelsQuery.Execute();

            return allHotels
                .Where(x => x.Rating >= rating)
                .OrderByDescending(x => x.Rating)
                .ToList() ?? new List<Hotel>();
        }

        private bool IsInteger(object value)
        {
            return int.TryParse(value.ToString(), out _);
        }
    }
}
