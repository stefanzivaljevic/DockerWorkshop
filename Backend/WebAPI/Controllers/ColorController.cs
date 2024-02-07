using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly ColorsRepository _repo;

        public ColorController(ColorsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetColors()
        {
            return await _repo.GetAllColors();
        }

        [HttpPost]
        public async Task<ActionResult> AddColor([FromBody] string color)
        {
            var colorToAdd = new Color() { Value = color };
            await _repo.AddColor(colorToAdd);
            return Ok();
        }
    }
}
