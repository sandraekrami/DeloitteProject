using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using Newtonsoft.Json;

namespace DeloitteProject.DataAccess
{
    public class GetAllHotelsQuery : IGetAllHotelsQuery
    {
        public async Task<IEnumerable<Hotel>> Execute(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return new List<Hotel>();
            }

            string json = await File.ReadAllTextAsync(filePath);
            List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            return hotels.OrderByDescending(x => x.Ranking);
        }
    }
}
