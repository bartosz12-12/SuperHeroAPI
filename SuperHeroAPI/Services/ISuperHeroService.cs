using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHeroDto hero);
        Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id);
        Task<List<SuperHero>> GetHeros();
        Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHeroDto hero);
    }
}