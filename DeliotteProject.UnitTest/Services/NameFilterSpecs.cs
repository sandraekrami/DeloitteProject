using System.Collections.Generic;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Services;
using Moq;
using Xunit;

namespace DeliotteProject.UnitTests.Services
{
    public abstract class NameFilterSpecs : InstanceSpecification<NameFilter>
    {
        internal object filterValue;
        internal IList<Hotel> allHotels;
        internal Task<IList<Hotel>> result;
        internal Mock<IGetAllHotelsQuery> getAllHotelsQueryMock;

        protected override void EstablishContext()
        {
            base.EstablishContext();
            getAllHotelsQueryMock = new Mock<IGetAllHotelsQuery>();

            allHotels = new List<Hotel>
            {
                Helper.CreateHotel(1),
                Helper.CreateHotel(2),
                Helper.CreateHotel(3),
                Helper.CreateHotel(4),
                Helper.CreateHotel(5)
            };

            getAllHotelsQueryMock.Setup(x => x.Execute()).ReturnsAsync(allHotels);
        }

        protected override NameFilter CreateSubjectUnderTest()
        {
            return new NameFilter(getAllHotelsQueryMock.Object);
        }

        protected override void Because()
        {
            result = SUT.Apply(filterValue);
        }

        public class when_filter_value_is_null : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = null;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void if_returns_all_hotels()
            {
                Assert.Equal(allHotels, result.Result);
            }
        }

        public class when_filter_value_is_empty : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = string.Empty;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void if_returns_all_hotels()
            {
                Assert.Equal(allHotels, result.Result);
            }
        }

        public class when_there_are_no_hotels_with_name_containing_keyword : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = "random";
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void if_returns_empty_list()
            {
                Assert.Empty(result.Result);
            }
        }

        public class when_there_are_hotels_containing_name : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = allHotels[3].Name;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void it_returns_all_hotels_with_name_contining_keyword()
            {
                Assert.Equal(1, result.Result.Count);
                Assert.Equal(allHotels[3], result.Result[0]);
            }
        }

        public class when_there_are_hotels_containing_name_but_with_different_culture : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = allHotels[4].Name.ToUpper();
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void it_searches_exact_match_and_returns_empty_list()
            {
                Assert.Empty(result.Result);
            }
        }

        public class when_there_are_hotels_containing_location : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = allHotels[3].Location;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void if_returns_empty_list()
            {
                Assert.Empty(result.Result);
            }
        }

        public class when_there_are_hotels_containing_description : NameFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = allHotels[3].Description;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void if_returns_empty_list()
            {
                Assert.Empty(result.Result);
            }
        }
    }
}
