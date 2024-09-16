using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebShopProject.API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {

        } 
    }
}
