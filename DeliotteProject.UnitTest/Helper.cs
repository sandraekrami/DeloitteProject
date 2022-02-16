using DeloitteProject.Domain.Models;

namespace DeliotteProject.UnitTests
{
    public static class Helper
    {
        public static Hotel CreateHotel(int key)
        {
            return new Hotel
            {
                Id=1,
                Name=$"Hotel {key}",
                Description = $"Description {key}",
                Location = $"Locaion {key}",
                Ranking = key
            };
        }
    }
}
