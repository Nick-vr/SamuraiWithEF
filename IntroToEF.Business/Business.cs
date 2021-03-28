using System;
using IntroToEF.Data.Entities;
using IntroToEF.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using IntroToEF.Data;
using Microsoft.EntityFrameworkCore;

namespace IntroToEF.Business
{
    public class Business
    {
        // Composition
        private SamuraiContext _context;

        private ISamuraiRepo _repo;

        public int SamuraiId { get; set; }
        public string SamuraiName { get; set; }
        public string SamuraiDynasty { get; set; }
        public string SamuraiQuote { get; set; }
        public string HorseName { get; set; }
        public int HorseAge { get; set; }
        public string IsItAwarHorse { get; set; }
        public string BattleName { get; set; }
        public int BattleYear { get; set; }
        public string BattleLocation { get; set; }

        public Business()
        {
            _context = new SamuraiContext();
            _repo = new SamuraiRepo();
        }

        public List<Samurai> ShowSamuraiDb()
        {
            var samurai = _context.Samurais
                .Include(x => x.Quotes)
                .Include(x => x.Horses)
                .Include(x => x.Battles)
                .ToList();

            var table = new ConsoleTable("Id", "Name", "Dynasty", "Horsename", "Quote", "Battle");
            foreach (var samu in samurai)
            {
                var horseName = "";
                var quoteText = "";
                var battleName = "";

                foreach (var horse in samu.Horses)
                {
                    horseName = horse.ToString();
                }

                foreach (var quote in samu.Quotes)
                {
                    quoteText = quote.ToString();
                }

                foreach (var battle in samu.Battles)
                {
                    battleName = battle.ToString();
                }

                table.AddRow(samu.Id, samu.Name, samu.Dynasty, horseName, quoteText, battleName);
            }

            table.Write();
            Console.WriteLine();

            return samurai;
        }

        public void AddSamuraiFromUserInput()
        {
            var samurai = new Samurai
            {
                Name = SamuraiName,
                Dynasty = SamuraiDynasty,
                Quotes = new List<Quote>
                {
                    new()
                    {
                        Text = SamuraiQuote,
                    }
                },
                Horses = new List<Horse>
                {
                    new()
                    {
                        IsWarHorse = IsItAwarHorse == "yes",
                        Name = HorseName,
                        Age = HorseAge,
                    }
                },
                Battles = new List<Battle>
                {
                    new()
                    {
                        Name = BattleName,
                        Year = BattleYear,
                        Location = BattleLocation,
                    }
                }
            };

            _repo.AddSamurai(samurai);
        }

        public void UpdateSamuraiFromUserInput()
        {
            var samurai = _repo.GetSamurai(SamuraiId);

            samurai.Name = SamuraiName;
            samurai.Dynasty = SamuraiDynasty;

            _repo.UpdateSamurai(samurai);
        }

        public List<Samurai> GetSamuraiWhoSaidAWord(string word)
        {
            var result = _repo.GetResultFromStoredProcedure(word);
            return result;
        }

        public void RemoveSamurai(int id)
        {
            _repo.DeleteSamurai(id);
        }

        public void AddSamuraiWithHorses()
        {
            var samurai = new Samurai
            {
                Name = "Samurai With Horses",
                Dynasty = "Sengoku",
                Horses = new List<Horse>
                {
                    new()
                    {
                        IsWarHorse = true,
                        Name = "Roach"
                    },
                    new()
                    {
                        IsWarHorse = false,
                        Name = "Boeddika"
                    }
                }
            };

            _repo.AddSamurai(samurai);
        }

        public void AddSamuraiWhoFoughtInBattles()
        {
            var veteran = new Samurai
            {
                Name = "A weary broken man",
                Battles = new List<Battle>
                {
                    new()
                    {
                        Name = "Okinagawa",
                        Year = 1557
                    },
                    new()
                    {
                        Name = "Fukushima",
                        Year = 2011
                    }
                }
            };

            _repo.AddSamurai(veteran);
        }

        public void GetAllSamurais()
        {
            var samurais = _repo.GetSamurais();
        }

        public void RenameSamurai(int id, string name)
        {
            // Get element from DB
            Samurai samuraiToBeUpdated = _repo.GetSamurai(id);

            // Perform changes
            samuraiToBeUpdated.Name = name;

            // Save object back to db
            _repo.UpdateSamurai(samuraiToBeUpdated);
        }

        public void RenameMultipleSamurais()
        {
            // Bad practice -> Code in datalayer should go here.
            _repo.UpdateSamurais();
        }

        public Samurai GetSamuraiWithBattles(int id)
        {
            return _repo.GetSamurai(id, true);
        }
    }
}