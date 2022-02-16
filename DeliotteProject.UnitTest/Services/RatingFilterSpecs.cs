﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Services;
using Moq;
using Xunit;

namespace DeliotteProject.UnitTests.Services
{
    public abstract class RatingFilterSpecs : InstanceSpecification<RatingFilter>
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

        protected override RatingFilter CreateSubjectUnderTest()
        {
            return new RatingFilter(getAllHotelsQueryMock.Object);
        }

        protected override void Because()
        {
            result = SUT.Apply(filterValue);
        }

        public class when_filter_value_is_not_an_integer : RatingFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filterValue = "";
            }

            [Fact]
            public async Task it_should_throw_exception()
            {
                await Assert.ThrowsAsync<InvalidOperationException>(() => SUT.Apply(filterValue));
            }

            [Fact]
            public void it_should_not_get_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute(), Times.Never);
            }
        }

        public class when_there_are_no_hotels_with_higher_or_same_rating : RatingFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                allHotels[0].Rating = 1;
                allHotels[1].Rating = 2;
                allHotels[2].Rating = 3;
                allHotels[3].Rating = 4;
                allHotels[4].Rating = 4;
                getAllHotelsQueryMock.Setup(x => x.Execute()).ReturnsAsync(allHotels);

                filterValue = 5;
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

        public class when_there_are_n_hotels_with_higher_or_same_rating : RatingFilterSpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                allHotels[0].Rating = 1;
                allHotels[1].Rating = 5;
                allHotels[2].Rating = 3;
                allHotels[3].Rating = 5;
                allHotels[4].Rating = 4;
                getAllHotelsQueryMock.Setup(x => x.Execute()).ReturnsAsync(allHotels);

                filterValue = 3;
            }

            [Fact]
            public void it_still_gets_all_hotels()
            {
                getAllHotelsQueryMock.Verify(x => x.Execute());
            }

            [Fact]
            public void it_returns_hotels_with_higher_or_same_rating()
            {
                foreach (var hotel in result.Result)
                {
                    Assert.True(hotel.Rating >= (int)filterValue);
                }
            }

            [Fact]
            public void it_sorts_result_by_rating_descending()
            {
                List<Hotel> expectedList = result.Result.OrderByDescending(x=>x.Rating).ToList();
                Assert.True(expectedList.SequenceEqual(result.Result));
            }
        }
    }
}
