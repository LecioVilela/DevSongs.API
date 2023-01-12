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

        private readonly ISongRegisterService _registerService;

        public SongController(IMapper mapper, ISongRegisterService registerService)
        {
            _mapper = mapper;
            _registerService = registerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string query)
        {
            var song = _registerService.GetAll(query);

            return Ok(song);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var song = new Song("Break Stuff", "Limp Bizkt", "None", "New Rock");

            var songViewModel = _mapper.Map<SongViewModel>(song);

            return Ok(songViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] NewSongInputModel model)
        {
            var id = _registerService.Create(model);

            return CreatedAtAction(nameof(GetById), new { id }, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(UpdateSongInputModel model)
        {
            var song = _mapper.Map<Song>(model);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
