using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntroToEF.Data.Repositories
{
    public class HorseRepo : IHorseRepo
    {
        private SamuraiContext _context;

        public HorseRepo()
        {
            // connect to db
            _context = new SamuraiContext();
        }

        public void AddHorse(string name, int age, bool isWarHorse, int samuraiId)
        {
            var horse = new Horse()
            {
                Name = name,
                Age = age,
                IsWarHorse = isWarHorse,
                SamuraiId = samuraiId,
            };

            _context.Add(horse);
            _context.SaveChanges();
        }

        public Horse GetHorse(int id)
        {
            throw new NotImplementedException();
        }

        public List<Horse> GetHorses()
        {
            return _context.Horses
                .Include(x => x.Samurai)
                .ToList();
        }

        public void UpdateHorse(int id, Horse quote)
        {
            throw new NotImplementedException();
        }

        public void DeleteHorse(int id)
        {
            throw new NotImplementedException();
        }
    }
}