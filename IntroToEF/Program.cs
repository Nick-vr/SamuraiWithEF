﻿using IntroToEF.Data.Repositories;
using System;
using IntroToEF.Business;

namespace IntroToEF
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var menu = new Menu();
            menu.ShowMenu();
        }
    }
}