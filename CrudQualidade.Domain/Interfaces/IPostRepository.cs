using CrudQualidade.Domain.Entities;

namespace CrudQualidade.Domain.Interfaces;

public interface IPostRepository
{
    IEnumerable<Post> GetAllPosts();
    Post GetPostById(int id);
    void InsertPost(Post post);
    void UpdatePost(Post post);
    void DeletePost(Post post);
}