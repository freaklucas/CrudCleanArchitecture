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

        [HttpDelete("remove")]
        public IActionResult RemoveAllRelationFriend([FromQuery] int personId)
        {
            try
            {
                _friendshipService.RemoveAllRelationFriend(personId);

                return Ok($"Relações de amizade deletadas do id: {personId}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover amizades : {ex.Message}");
            }
        }
    }
    
}

        