using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProblematicProblem
{
   
    class Program 
    {
        public static string GetRandomFromList(List<string> passedList)
        {
            Random rnd = new Random();
            var index = rnd.Next(passedList.Count);
            string chosenActivity = passedList[index];
            return chosenActivity;
        }
        static void Main(string[] args)
        {
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string cont = Console.ReadLine().ToLower();
            if (cont == "no")
            {
                Console.WriteLine("Ok, maybe next time.");
                Environment.Exit(0);
            }
            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeList = Console.ReadLine().ToLower();

            if (seeList == "sure")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                string addToList = Console.ReadLine().ToLower();
                Console.WriteLine();

                while (addToList == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower();
                }
            }
            
            while (cont == "yes" || cont == "redo")
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                string randomActivity = GetRandomFromList(activities);

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do Wine Tasting");
                    Console.WriteLine("Pick something else!");

                    activities.Remove("Wine Tasting");

                    randomActivity = GetRandomFromList(activities);
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower();
            }
        }
    }
}
