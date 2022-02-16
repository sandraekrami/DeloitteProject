using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Services;
using Moq;
using Xunit;

namespace DeliotteProject.UnitTests.Services
{
    internal abstract class KeywordFilterSpecs : InstanceSpecification<KeywordFilter>
    {
        internal Mock<IGetAllHotelsQuery> getAllHotelsQueryMock;
        internal object filterValue;
        internal IList<Hotel> allHotels;
        internal Task<IList<Hotel>> result;

        protected override void EstablishContext()
        {
            base.EstablishContext();
            getAllHotelsQueryMock = new Mock<IGetAllHotelsQuery>();

            allHotels = new List<Hotel>
            {
                CreateHotel(1),
                CreateHotel(2),
                CreateHotel(3),
                CreateHotel(4),
                CreateHotel(5)
            };

            getAllHotelsQueryMock.Setup(x => x.Execute()).ReturnsAsync(allHotels);
        }

        protected override KeywordFilter CreateSubjectUnderTest()
        {
            return new KeywordFilter(getAllHotelsQueryMock.Object);
        }

        protected override void Because()
        {
            result = SUT.Apply(filterValue);
        }

        public class when_filter_value_is_null : KeywordFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = null;
            }

            [Fact]
            public void if_retrns_all_hotels()
            {
                Assert.Equal(allHotels.Count, result.Result.Count);
            }
        }

        private Hotel CreateHotel(int key)
        {
            return new Hotel { Id=1, Name=$"Hotel {key}", Description = $"Description {key}", Location = $"Locaion {key}", Rating = key };
        }
    }
}
