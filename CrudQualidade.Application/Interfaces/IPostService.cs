using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Application.Interfaces;

public interface IPostService
{
    IEnumerable<Post> GetAllPosts();
    Post GetPostById(int id);
    void InsertPost(Post post);
    void UpdatePost(Post post);
    void DeletePost(Post post);
}