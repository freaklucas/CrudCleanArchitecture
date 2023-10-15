using CrudQualidade.Application.Interfaces;
using CrudQualidade.Application.Services;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using Moq;

namespace CrudQualidade.Tests;

public class PostServiceTest
{
    [Fact]
    public void GetAllPosts_ShouldReturnAllPosts()
    {
        // Arrange
        var mockRepo = new Mock<IPostRepository>();
        mockRepo.Setup(repo => repo.GetAllPosts())
            .Returns(GetTestPosts());

        var mockUow = new Mock<IUnitOfWork>();
        mockUow.Setup(uow => uow.PostRepository).Returns(mockRepo.Object);
        var service = new PostService(mockUow.Object);

        // act
        var result = service.GetAllPosts();

        // Acert
        Assert.Equal(2, result.Count());

        //check individual
        Assert.Collection(result,
            post => Assert.Equal(1, post.Id),
            post => Assert.Equal(2, post.Id));
    }

    [Fact]
    public void GetPosts_ShouldReturnPostById()
    {
        //Arrange
        var expectedPostId = 1;
        var testeId = 2;
        var expectedPost = new Post { Id = expectedPostId, PeopleId = 2, Content = "Teste de postagem..." };
        var mockRepo = new Mock<IPostRepository>();
        mockRepo.Setup(repo => repo.GetPostById(expectedPostId)).Returns(expectedPost);

        var mockUow = new Mock<IUnitOfWork>();
        mockUow.Setup(uow => uow.PostRepository).Returns(mockRepo.Object);

        var service = new PostService(mockUow.Object);
        // Act
        var result = service.GetPostById(expectedPostId);
        // Acert
        Assert.Equal(expectedPost.Id, result.Id);
    }

    [Fact]
    public void PostPosts_ShouldReturnSendPost()
    {
        //Arange
        var newPost = new Post { Id = 3, PeopleId = 2, Content = "Teste de postagem..." };

        var mockRepo = new Mock<IPostRepository>();
        mockRepo.Setup(repo => repo.InsertPost(newPost));

        var mockPeopleRepo = new Mock<IPeopleRepository>();
        mockPeopleRepo.Setup(repo => repo.GetPeopleById(It.IsAny<int>())).Returns(new People());

        var mockUow = new Mock<IUnitOfWork>();
        mockUow.Setup(uow => uow.PostRepository).Returns(mockRepo.Object);
        mockUow.Setup(uow => uow.PeopleRepository).Returns(mockPeopleRepo.Object);
        var service = new PostService(mockUow.Object);
        
        // Act
        service.InsertPost(newPost);
        
        // Assert
        mockRepo.Verify(repo => repo.InsertPost(newPost), Times.Once);
    }

    [Fact]
    public void UpdatePost_ShouldUpdatePost()
    {
        var mockPost = new Post { Id = 3, PeopleId = 2, Content = "Teste de postagem..." };
        var mockRepo = new Mock<IPostRepository>();
        mockRepo.Setup(repo => repo.UpdatePost(mockPost));

        var mockUow = new Mock<IUnitOfWork>();
        mockUow.Setup(uow => uow.PostRepository).Returns(mockRepo.Object);
        var service = new PostService(mockUow.Object);
        
        service.UpdatePost(mockPost);
        mockRepo.Verify(repo => repo.UpdatePost(mockPost), Times.Once());
    }

    [Fact]
    public void RemovePost_ShouldRemovePost()
    {
        //arrange
        var mockPost = new Post { Id = 3, PeopleId = 2, Content = "Teste de postagem..." };
        var mockRepo = new Mock<IPostRepository>();
        mockRepo.Setup(repo => repo.DeletePost(mockPost));

        var mockUow = new Mock<IUnitOfWork>();
        mockUow.Setup(uow => uow.PostRepository).Returns(mockRepo.Object);
        var service = new PostService(mockUow.Object);
        
        service.DeletePost(mockPost);
        mockRepo.Verify(repo => repo.DeletePost(mockPost), Times.Once());
    }
    
    private List<Post> GetTestPosts()
    {
        return new List<Post>
        {
            new Post { Id = 1, PeopleId = 2, Content = "Teste de postagem..." },
            new Post { Id = 2, PeopleId = 3, Content = "Postagem p pessoa 3!" },
        };
    }
}