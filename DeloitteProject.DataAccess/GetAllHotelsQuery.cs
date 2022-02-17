using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using Newtonsoft.Json;

namespace DeloitteProject.DataAccess
{
    public class GetAllHotelsQuery : IGetAllHotelsQuery
    {
        public async Task<IEnumerable<Hotel>> Execute()
        {
            string json = await File.ReadAllTextAsync(@"..\hotels.json");
            return JsonConvert.DeserializeObject<List<Hotel>>(json);
        }

    }
}
