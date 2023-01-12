using AutoMapper;
using DevSongs.Application.InputModels;
using DevSongs.Application.Services.Interfaces;
using DevSongs.Application.ViewModels;
using DevSongs.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSongs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ISongService _service;

        public SongController(IMapper mapper, ISongService registerService)
        {
            _mapper = mapper;
            _service = registerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string query)
        {
            var songViewModel = _service.GetAll(query);      

            return Ok(songViewModel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var songViewModel = _service.GetById(id);

            return Ok(songViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] NewSongInputModel model)
        {
            var id = _service.Create(model);

            return CreatedAtAction(nameof(GetById), new { id }, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateSongInputModel model)
        {
            _service.Update(model);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
