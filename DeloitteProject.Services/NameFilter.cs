﻿using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using Microsoft.Extensions.Logging;

namespace DeloitteProject.Services
{
    public class NameFilter : IFilterService
    {
        private readonly IGetAllHotelsQuery getAllHotelsQuery;
        private readonly ILogger<NameFilter> logger;

        public NameFilter(IGetAllHotelsQuery getAllHotelsQuery, ILogger<NameFilter> logger)
        {
            this.getAllHotelsQuery = getAllHotelsQuery;
            this.logger = logger;
        }

        public async Task<IEnumerable<Hotel>> Apply(object filterValue)
        {
            logger.LogInformation("Filtering hotels by name");
            var allHotels = await getAllHotelsQuery.Execute();

            if (filterValue == null || string.IsNullOrEmpty(filterValue.ToString()))
            {
                return allHotels;
            }

            return allHotels.Where(x => x.Name.Contains(filterValue.ToString(), StringComparison.CurrentCultureIgnoreCase))
                .ToList() ?? new List<Hotel>();
        }
    }
}
