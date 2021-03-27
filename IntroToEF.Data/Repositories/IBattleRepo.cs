using IntroToEF.Data.Entities;

namespace IntroToEF.Data.Repositories
{
    internal interface IBattleRepo
    {
        void AddBattle(string name, int year, string location, int samuraiId);

        void UpdateBattle(int id, Battle battle);
    }
}