using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using Newtonsoft.Json;

namespace DeloitteProject.DataAccess
{
    public class GetAllHotelsQuery : IGetAllHotelsQuery
    {
        public async Task<IEnumerable<Hotel>> Execute()
        {
            string json = await File.ReadAllTextAsync(Constants.HotelsFilePath);
            return JsonConvert.DeserializeObject<List<Hotel>>(json);
        }
    }
}
