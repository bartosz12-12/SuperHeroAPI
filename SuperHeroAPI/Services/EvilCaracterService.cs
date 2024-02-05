using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class EvilCaracterService : IEvilCaracterService
    {
        private readonly DataContext _context;

        public EvilCaracterService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EvilCarater>> GetEvilCaracter()
        {
            try
            {
                var database = await _context.EvilCaraters.ToListAsync();

                return database;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<EvilCarater>> GetById(int id)
        {
            try
            {
                var database = await _context.EvilCaraters.FindAsync(id);

                return database;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ActionResult<List<EvilCarater>>> CreateEvilCaracter(EvilCaracterDto hero)
        {
            try
            {
                var newEvilCaracter = new EvilCarater
                {
                    Name = hero.Name,
                    Place = hero.Place,
                    SuperHeroId = hero.SuperHeroId,
                };
                _context.EvilCaraters.Add(newEvilCaracter);
                await _context.SaveChangesAsync();
                return await _context.EvilCaraters.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<List<EvilCarater>>> UpdateEvilCarater(int id, EvilCaracterDto hero)
        {
            try
            {
                var dbHero = await _context.EvilCaraters.FindAsync(id);
                if (dbHero == null)
                {
                    throw new Exception("51");
                }
                dbHero.Name = hero.Name;
                dbHero.Place = hero.Place;
                dbHero.SuperHeroId = hero.SuperHeroId;
                await _context.SaveChangesAsync();
                return await _context.EvilCaraters.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ActionResult<List<EvilCarater>>> DeleteEvilCarater(int id)
        {
            try
            {
                var dbHero = await _context.EvilCaraters.FindAsync(id);
                if (dbHero == null)
                {
                    throw new Exception("51");
                }
                _context.EvilCaraters.Remove(dbHero);
                await _context.SaveChangesAsync();

                return await _context.EvilCaraters.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
