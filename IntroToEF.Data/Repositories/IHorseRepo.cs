using IntroToEF.Data.Entities;
using System;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    public interface IHorseRepo
    {
        void AddHorse(string name, int age, bool isWarHorse, int samuraiId);

        void DeleteHorse(int id);

        Horse GetHorse(int id);

        List<Horse> GetHorses();

        void UpdateHorse(int id, Horse quote);
    }
}