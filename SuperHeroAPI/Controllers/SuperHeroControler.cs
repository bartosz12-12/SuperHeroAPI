using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroControler : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroControler(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            try
            {
                return Ok(await _service.GetHeros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("add")]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            try
            {
                return Ok(await _service.CreateSuperHero(hero));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            try
            {
                return Ok(await _service.UpdateSuperHero(hero));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/{id}")]

        public async Task<ActionResult<List<SuperHero>>> deleteSuperHero(int id)
        {
            try
            {
                return Ok(await _service.DeleteSuperHero(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
