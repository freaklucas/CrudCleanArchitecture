namespace CrudQualidade.Application.DTOs;

public class PeoplePatchDTO
{

        public PeoplePatchDTO() {}
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? NumberPhone { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }

        public string? Email { get; set; }
    }

