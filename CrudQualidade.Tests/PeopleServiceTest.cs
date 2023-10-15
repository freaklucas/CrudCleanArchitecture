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

        [Fact]
        public void GetPeoples_ShouldReturnPeopleById()
        {
            var expectedPeopleId = 1;
            var expectedPeople = new People { Id = expectedPeopleId, Name = "Lucas" };
            var mockRepo = new Mock<IPeopleRepository>();
            mockRepo.Setup(repo => repo.GetPeopleById(expectedPeopleId)).Returns(expectedPeople);

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockRepo.Object);

            var service = new PeopleService(mockUow.Object);
            var result = service.GetPeopleById(expectedPeopleId);

            Assert.Equal(expectedPeople.Name, result.Name);
        }

        [Fact]
        public void PostPeoples_ShouldReturnSendPost()
        {
            // Arrange
            var newPeople = new People { Id = 1, Name =  "Lucas"};
            var mockRepo = new Mock<IPeopleRepository>();
            mockRepo.Setup(repo => repo.Insert(newPeople));

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockRepo.Object);
            var service = new PeopleService(mockUow.Object);
            
            // Act
            service.InsertPeople(newPeople);
            
            // Assert
            mockRepo.Verify(repo => repo.Insert(newPeople), Times.Once());
        }

    [Fact]
        public void UpdatePeople_ShouldUpdatePeople()
        {
            var mockPeople = new People { Id = 1, Name = "Lucas Editado" };
            var mockRepo = new Mock<IPeopleRepository>();
            mockRepo.Setup(repo => repo.UpdatePeople(mockPeople));

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockRepo.Object);
            var service = new PeopleService(mockUow.Object);
            
            service.UpdatePeople(mockPeople);
            mockRepo.Verify(repo => repo.UpdatePeople(mockPeople), Times.Once());
        }

        [Fact]
        public void RemovePeople_ShouldRemovePeople()
        {
            // Arrange -> requisitos
            var mockPeople = new People{ Id = 1, Name = "Lucas"};
            var mockRepo = new Mock<IPeopleRepository>();
            mockRepo.Setup(repo => repo.DeletePeople(mockPeople));

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockRepo.Object);

            var service = new PeopleService(mockUow.Object);
            // act -> funcionalidade
            service.DeletePeople(mockPeople);
            
            //Asset -> esperado
            mockRepo.Verify(repo => repo.DeletePeople(mockPeople), Times.Once());
        }

        [Fact]
        public void GetPeopleByFilters_ShouldReturnFilteredPeoples()
        {
            var mockPepo = new Mock<IPeopleRepository>();
            mockPepo.Setup(repo => repo.GetPeopleByFilters("Rio Verde", 20, 80))
                .Returns(GetTestFilteredPeoples());

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(uow => uow.PeopleRepository).Returns(mockPepo.Object);

            var service = new PeopleService(mockUow.Object);
            var result = service.GetPeopleByFilters("Rio Verde", 20, 80);
            
            Assert.Collection(result,
                people => Assert.Equal("Lucas", people.Name),
                people => Assert.Equal("Márcia", people.Name)
                );
        }
        private List<People> GetTestFilteredPeoples()
        {
            return new List<People>
            {
                new People {Id = 1, Name="Lucas", Age = 20},
                new People {Id = 2, Name="Márcia", Age = 60}
            };
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
