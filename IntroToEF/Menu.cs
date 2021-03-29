using System;
using System.Net.Mime;

namespace IntroToEF
{
    public class Menu
    {
        private Business.Business _business;

        public Menu()
        {
            _business = new Business.Business();
        }

        public void ShowMenu()
        {
            var showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("          SAMMURAI DB          ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add new Samurai ");
            Console.WriteLine("2. Update Samurai");
            Console.WriteLine("3. Delete Samurai");
            Console.WriteLine("4. Show DB");
            Console.WriteLine("5. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    GetSamuraiInfoFromUserInputForAdding();
                    _business.AddSamuraiFromUserInput();
                    ShowMenu();
                    return false;

                case "2":
                    Console.Clear();
                    _business.ShowSamuraiDb();
                    GetSamuraiIdForUpdate();
                    _business.UpdateSamuraiFromUserInput();
                    ShowMenu();
                    return false;

                case "3":
                    Console.Clear();
                    _business.ShowSamuraiDb();
                    GetSamuraiIdForDelete();
                    _business.DeleteSamuraiFromUserInput();
                    ShowMenu();
                    return false;

                case "4":
                    Console.Clear();
                    _business.ShowSamuraiDb();
                    Console.WriteLine("Enter to exit");
                    Console.ReadLine();
                    ShowMenu();
                    return false;

                case "5":
                    Environment.Exit(0);
                    return false;

                default:
                    return true;
            }
        }

        public void GetSamuraiInfoFromUserInputForAdding()
        {
            Console.WriteLine("Samurai name?");
            _business.SamuraiName = Console.ReadLine();
            Console.WriteLine("What dynasty?");
            _business.SamuraiDynasty = Console.ReadLine();
            Console.WriteLine($"Give a Quote from {_business.SamuraiName}");
            _business.SamuraiQuote = Console.ReadLine();
            Console.WriteLine($"What was the name of {_business.SamuraiName}'s horse?");
            _business.HorseName = Console.ReadLine();
            Console.WriteLine($"What was the age of {_business.SamuraiName}'s horse?");
            _business.HorseAge = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Was it a warhorse? yes/no");
            _business.IsItAwarHorse = Console.ReadLine();
            Console.WriteLine($"Which battle did {_business.SamuraiName} fight in?");
            _business.BattleName = Console.ReadLine();
            Console.WriteLine("Year of the battle?");
            _business.BattleYear = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Location of the battle?");
            _business.BattleLocation = Console.ReadLine();
        }

        public void GetSamuraiIdForUpdate()
        {
            Console.WriteLine("Give Samurai ID you want to update");
            _business.SamuraiId = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Samurai name?");
            _business.SamuraiName = Console.ReadLine();
            Console.WriteLine("What dynasty?");
            _business.SamuraiDynasty = Console.ReadLine();
        }

        public void GetSamuraiIdForDelete()
        {
            Console.WriteLine("Give Samurai ID you want to delete");
            _business.SamuraiId = Convert.ToInt16(Console.ReadLine());
        }
    }
}