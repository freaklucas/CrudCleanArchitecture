using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using CrudQualidade.Infrastructure.Data;
using System.Linq;
using CrudQualidade.Application.DTOs;
using CrudQualidade.Infrastructure.Repository.Generic;


namespace CrudQualidade.Infrastructure.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public void InsertPost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts.ToList();
    }

    public Post GetPostById(int id)
    {
        return _context.Posts.FirstOrDefault(p => p.Id == id);
    }

    public void UpdatePost(Post post)
    {
        var existsPost = _context.Posts.Find(post.Id);
        if (existsPost == null)
            throw new Exception("Post não encontrado!");
        
        _context.Entry(existsPost).CurrentValues.SetValues(post);
        _context.SaveChanges();
    }

    public void DeletePost(Post post)
    {
        Remove(post);
        _context.SaveChanges();
    }
}