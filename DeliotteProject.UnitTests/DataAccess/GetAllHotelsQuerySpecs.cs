using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DeloitteProject.DataAccess;
using DeloitteProject.Domain.Models;
using Moq;
using Xunit;

namespace DeliotteProject.UnitTests.DataAccess
{
    public abstract class GetAllHotelsQuerySpecs : InstanceSpecification<GetAllHotelsQuery>
    {
        private string filePath = "filePath";
        private IEnumerable<Hotel> result;

        protected override GetAllHotelsQuery CreateSubjectUnderTest()
        {
            return new GetAllHotelsQuery();
        }

        protected override void Because()
        {
            result = SUT.Execute(filePath).Result.ToList();
        }

        public class when_filepath_is_empty : GetAllHotelsQuerySpecs
        {
            protected override void EstablishContext()
            {
                base.EstablishContext();
                filePath = "";
            }

            [Fact]
            public void it_returns_empty_list()
            {
                Assert.Empty(result);
            }
        }
    }
}
