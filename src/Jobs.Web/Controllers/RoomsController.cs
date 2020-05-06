using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Jobs.Core.ApiModels;
using Jobs.Core.Abstractions.Services;

namespace Jobs.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getoverview")]
        [ProducesResponseType(typeof(IEnumerable<RoomProgressOverviewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoomProgressOverview()
        {
            var roomProgressOverview = await _roomService.GetRoomsProgressOverviewAsync();

            return Ok(roomProgressOverview);
        }
    }
}