using Kolokwium2.DTOs.Requests;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers {
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase {
        private readonly IDbService _service;

        public ArtistsController(IDbService service) {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetArtist(int id) {
            return Ok(_service.GetArtist(id));
        }

        [HttpPut("{idArtist:int}/events/{idEvent:int}")]
        public IActionResult UpdateArtistPerformanceDate(int idArtist, int idEvent, UpdateArtistPerformanceDateRequest request) {
            _service.UpdateArtistPerformanceDate(idArtist, idEvent, request);
            return Ok();
        }
    }
}