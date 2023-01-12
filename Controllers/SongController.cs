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

        /// <summary>
        /// Get all songs of your playlist.
        /// </summary>
        /// <remarks>
        /// 
        ///     ### Input a query string to get all the information from your playlist ###
        ///         - 
        /// 
        ///     ### Responses ###
        ///         Status code response below:
        ///         - 200 - Ok
        ///         - 404 - NotFound
        ///         - 400 - Bad Request
        ///         
        /// </remarks>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return NotFound("Ooops! Can't find your songs...");
                }
                else
                {
                    var songViewModel = _service.GetAll(query);

                    return Ok(songViewModel);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Get one song of your playlist.
        /// </summary>
        /// <remarks>
        /// 
        ///     ### Input an id to get the information of a song from your playlist ###
        ///         - 
        /// 
        ///     ### Responses ###
        ///         Status code response below:
        ///         - 200 - Ok
        ///         - 404 - NotFound
        ///         - 400 - Bad Request
        ///         
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Ooops! Please input a correct id for the request...");
                }
                else
                {
                    var songViewModel = _service.GetById(id);

                    if (songViewModel is null)
                    {
                        return NotFound("Looks like that you don't have any song in your playlist....");
                    }
                    else
                    {
                        return Ok(songViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Set one song to your playlist
        /// </summary>
        /// <remarks>
        /// 
        ///     ### Input the data of the song that you wan't to save. ###
        ///         - 
        /// 
        ///     ### Responses ###
        ///         Status code response below:
        ///         - 200 - Ok
        ///         - 404 - NotFound
        ///         - 400 - Bad Request
        ///         
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] NewSongInputModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest("Ooops! I need some informations about the song...");
                }
                else
                {
                    var id = _service.Create(model);

                    return CreatedAtAction(nameof(GetById), new { id }, model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Update one song from your playlist
        /// </summary>
        /// <remarks>
        /// 
        ///     ### Input the data of the song that you wan't to update. ###
        ///         - 
        /// 
        ///     ### Responses ###
        ///         Status code response below:
        ///         - 200 - Ok
        ///         - 404 - NotFound
        ///         - 400 - Bad Request
        ///         
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateSongInputModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest("Ooops! I need some informations about the song...");
                }
                else
                {
                    _service.Update(model);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Remove one song from your playlist
        /// </summary>
        /// <remarks>
        /// 
        ///     ### Input the id of the song that you wan't to remove. ###
        ///         - 
        /// 
        ///     ### Responses ###
        ///         Status code response below:
        ///         - 200 - Ok
        ///         - 404 - NotFound
        ///         - 400 - Bad Request
        ///         
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Ooops! Please input an existing id...");
                }
                else
                {
                    _service.Delete(id);

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }         
        }
    }
}
