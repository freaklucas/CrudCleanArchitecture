namespace CrudQualidade.Domain.Entities
{
    public class Post
    {
        public Post() {}

        public int Id { get; set; }
        public int PeopleId { get; set; }
        //public virtual People People { get; set; }
        public string Content { get; set; }
        public DateTime DatePost { get; set; }
    }
}