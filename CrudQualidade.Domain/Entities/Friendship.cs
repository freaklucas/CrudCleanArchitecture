namespace CrudQualidade.Domain.Entities
{
    public class Friendship
    {
        public Friendship() {}
        
        public int PersonId1 { get; set; }
        public People? People1 { get; set; }
        public int PersonId2 { get; set; }
        public People? People2 { get; set; }
    }
}