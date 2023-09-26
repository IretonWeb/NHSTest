using Microsoft.EntityFrameworkCore;

using Moq;
using NHSTest.Application.Queries.Staff;
using NHSTest.Application.ResponseModels;
using NHSTest.Domain.Entities;
using NHSTest.Persistence;
using System.Threading;
using MockQueryable.Moq;

namespace NhsTest.UnitTests
{
    public class Tests
    {
        [Fact]
        public async Task GetListOfStaff()
        {
            List<Staff> data = (List<Staff>)SetUpStaffList().Data;
            var myDbSetUp = GetQueryableMockDbSet(data);
            

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Staff).Returns(myDbSetUp);
            var handler = new GetAllStaffQuery.Handler(mockContext.Object);

            var result =  await handler.Handle(new GetAllStaffQuery(), CancellationToken.None);
            Assert.NotNull(result);
       
        }


        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable().BuildMockDbSet();
          
            return queryable.Object;

        }

        public GenericResponseModel SetUpStaffList()
        {

            return new GenericResponseModel
            {
                Success = true,
                Data = new List<Staff>
                {
                    new Staff
                    {
                        FirstName = "Glen",
                        Surname = "Deathridge"
                    }
                }
            };
        }

    }
}
