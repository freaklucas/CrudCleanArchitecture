using Xunit;
using Moq;
using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Domain.Entities;
using System.Collections.Generic;
using CrudQualidade.Application;

namespace CrudQualidade.Tests
{
    public class PeopleServiceTests
    {
        [Fact]
        public void GetAllPeoples_ShouldReturnAllPeoples()
        {
            var mockRepo = new Mock<IPeopleRepository>();
            mockRepo.Setup(repo => repo.GetAllPeoples())
                .Returns(GetTestPeoples());
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockRepo.Object);
            
            var service = new PeopleService(mockUow.Object);
            var result = service.GetAllPeoples();

            Assert.Collection(result, 
                people => Assert.Equal("Lucas", people.Name),
                people => Assert.Equal("Márcia", people.Name));
        }

        private List<People> GetTestPeoples()
        {
            return new List<People>
            {
                new People { Id = 1, Name = "Lucas" },
                new People { Id = 2, Name = "Márcia" },
            };
        }
    }
}
