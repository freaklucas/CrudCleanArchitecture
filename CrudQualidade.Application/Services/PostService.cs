using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;

    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _unitOfWork.PostRepository.GetAllPosts();
    }

    public Post GetPostById(int id)
    {
        return _unitOfWork.PostRepository.GetPostById(id);
    }
    
    public void InsertPost(Post post)
    {
        var people = _unitOfWork.PeopleRepository.GetPeopleById(post.PeopleId);
        if (people == null) throw new Exception("Pessoa não encontrada!");

        _unitOfWork.PostRepository.InsertPost(post);
    }

    public void UpdatePost(Post post)
    {
        _unitOfWork.PostRepository.UpdatePost(post);
    }

    public void DeletePost(Post post)
    {
        _unitOfWork.PostRepository.DeletePost(post);
    }
}