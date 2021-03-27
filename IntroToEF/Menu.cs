using System;
using System.Linq;

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
            Console.WriteLine("1. Add new Samurai to the DB");
            Console.WriteLine("2. Update something in the DB");
            Console.WriteLine("3. Delete something in the DB");
            Console.WriteLine("4. Show DB");
            Console.WriteLine("5. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    GetSamuraiFromUserInput();
                    _business.AddSamuraiFromUserInput();
                    ShowMenu();
                    return false;

                case "2":

                    return false;

                case "3":
                    //dosomething
                    return true;

                case "4":
                    Console.Clear();
                    _business.ShowSamuraiDb();
                    Console.WriteLine("Enter to exit");
                    Console.ReadLine();
                    ShowMenu();
                    return false;

                case "5":
                    ShowMenu();
                    return true;

                default:
                    return true;
            }
        }

        public void GetSamuraiFromUserInput()
        {
            Console.WriteLine("Samurai name?");
            _business.SamuraiName = Console.ReadLine();
            Console.WriteLine("What dynasty?");
            _business.SamuraiDynasty = Console.ReadLine();
            Console.WriteLine($"Give a Quote from {_business.SamuraiName}");
            _business.SamuraiQuote = Console.ReadLine();
            Console.WriteLine($"What was the name of {_business.SamuraiName}'s horse?");
            _business.HorseName = Console.ReadLine();
            Console.WriteLine("Was it a warhorse? yes/no");
            _business.IsItAwarHorse = Console.ReadLine();
            Console.WriteLine($"Which battle did {_business.SamuraiName} fight in?");
            _business.BattleName = Console.ReadLine();
            Console.WriteLine("Year of the battle?");
            _business.BattleYear = Console.ReadLine();
            Console.WriteLine("Location of the battle?");
            _business.BattleLocation = Console.ReadLine();
        }
    }
}