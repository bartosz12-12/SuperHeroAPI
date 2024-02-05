using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface IEvilCaracterService
    {
        Task<ActionResult<List<EvilCarater>>> CreateEvilCaracter(EvilCaracterDto hero);
        Task<ActionResult<List<EvilCarater>>> DeleteEvilCarater(int id);
        Task<List<EvilCarater>> GetEvilCaracter();
        Task<ActionResult<List<EvilCarater>>> UpdateEvilCarater(int id, EvilCaracterDto hero);
        Task<ActionResult<EvilCarater>> GetById(int id);
    }
}