using CrudQualidade.Application.Interfaces;
using CrudQualidade.Domain.Entities;
using CrudQualidade.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudQualidade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FriendshipController : Controller
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }
        
        [HttpPost("{personId1}/AddFriend/{personId2}")]
        public IActionResult AddFriendship(int personId1, int personId2)
        {
            _friendshipService.AddFriendship(personId1, personId2);
            return Ok("Amizade adicionada!");
        }
        
        [HttpGet("{personId}/friends")]
        public IActionResult GetFriendsOfPerson(int personId)
        {
            var friends = _friendshipService.GetFriendsOfPeople(personId);

            return Ok(friends);
        }
    }
    
}

        