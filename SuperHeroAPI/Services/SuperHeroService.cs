using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetHeros()
        {
            try
            {
                var database = await _context.SuperHeroes.Include(c => c.EvilCaraters).ToListAsync();

                return database;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            try
            {
                var newSuperHero = new SuperHero
                {
                    Id = hero.Id,
                    Name = hero.Name,
                    FirtsName = hero.FirtsName,
                    LastName = hero.LastName,
                    Place = hero.Place,
                    EvilCaraters = hero.EvilCaraters,
                };
                _context.SuperHeroes.Add(newSuperHero);
                await _context.SaveChangesAsync();
                return await _context.SuperHeroes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
                if (dbHero == null)
                {
                    throw new Exception("51");
                }
                dbHero.Name = hero.Name;
                dbHero.FirtsName = hero.FirtsName;
                dbHero.LastName = hero.LastName;
                dbHero.Place = hero.Place;
                await _context.SaveChangesAsync();
                return await _context.SuperHeroes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            try
            {
                var dbHero = await _context.SuperHeroes.FindAsync(id);
                if (dbHero == null)
                {
                    throw new Exception("51");
                }
                _context.SuperHeroes.Remove(dbHero);
                await _context.SaveChangesAsync();

                return await _context.SuperHeroes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
