using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvilCaracterController : ControllerBase
    {
        private readonly IEvilCaracterService _service;

        public EvilCaracterController(IEvilCaracterService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<EvilCarater>>> GetEvilCaracter()
        {
            try
            {
                return Ok(await _service.GetEvilCaracter());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<EvilCarater>> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add")]
        public async Task<ActionResult<List<EvilCarater>>> CreateEvilCaracter(EvilCaracterDto hero)
        {
            try
            {
                return Ok(await _service.CreateEvilCaracter(hero));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<List<EvilCarater>>> UpdateEvilCaracter(int id, EvilCaracterDto hero)
        {
            try
            {
                return Ok(await _service.UpdateEvilCarater(id, hero));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Delete/{id}")]

        public async Task<ActionResult<List<EvilCarater>>> DeleteSEvilCarater(int id)
        {
            try
            {
                return Ok(await _service.DeleteEvilCarater(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
