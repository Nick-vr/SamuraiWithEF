using System;
using IntroToEF.Data.Entities;

namespace IntroToEF.Data.Repositories
{
    internal class BattleRepo : IBattleRepo
    {
        private SamuraiContext _context;

        public BattleRepo()
        {
            _context = new SamuraiContext();
        }

        public void AddBattle(string name, int year, string location, int samuraiId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBattle(int id, Battle battle)
        {
            throw new NotImplementedException();
        }
    }
}