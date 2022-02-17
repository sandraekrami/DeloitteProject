using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using Microsoft.Extensions.Logging;

namespace DeloitteProject.Services
{
    public class RatingFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;
        private readonly ILogger<RatingFilter> logger;

        public RatingFilter(IGetAllHotelsQuery getAllHotelsQuery, ILogger<RatingFilter> logger)
        {
            this.getAllHotelsQuery = getAllHotelsQuery;
            this.logger = logger;
        }

        public async Task<IEnumerable<Hotel>> Apply(object filterValue)
        {
            logger.LogInformation("Filtering hotels by ranking");

            if (!IsInteger(filterValue))
            {
                logger.LogError("Filtering hotels by ranking failed because filter value is not an integer");
                throw new InvalidOperationException("Value is not an integer.");
            }

            int rating = (int)filterValue;
            var allHotels = await getAllHotelsQuery.Execute();

            return allHotels
                .Where(x => x.Ranking >= rating)
                .OrderByDescending(x => x.Ranking)
                .ToList() ?? new List<Hotel>();
        }

        private bool IsInteger(object value)
        {
            return int.TryParse(value.ToString(), out _);
        }
    }
}