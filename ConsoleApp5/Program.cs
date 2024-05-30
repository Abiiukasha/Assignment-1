using System;

namespace VirtualPetSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pet Creation
            Console.WriteLine("Welcome to the Virtual Pet Simulator!");
            Console.WriteLine("Select the type of pet:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Rabbit");
            Console.Write("Enter type: ");

            string petType;
            while (true)
            {
                string petTypeInput = Console.ReadLine();
                switch (petTypeInput)
                {
                    case "1":
                        petType = "Dog";
                        break;
                    case "2":
                        petType = "Cat";
                        break;
                    case "3":
                        petType = "Rabbit";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 for Dog, 2 for Cat, or 3 for Rabbit.");
                        continue;
                }
                break;
            }


            Console.Write($"You have adopted a {petType}\n");

            Console.Write("Enter the name of your pet: ");
            string petName = Console.ReadLine();
            Console.WriteLine($"Welcome {petName}! Let's take care of it");

            // Initialize pet stats
            int hunger = 5;
            int happiness = 5;
            int health = 8;

            while (true)
            {
                // Display menu
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine($"1. Feed {petName}");
                Console.WriteLine($"2. Play with {petName}");
                Console.WriteLine($"3. Let your {petName} rest");
                Console.WriteLine($"4. Check {petName} status");
                Console.WriteLine($"5. Exit");

                // Get user input and convert it to an integer
                string choiceInput = Console.ReadLine();
                int choice;
                bool isValidChoice = int.TryParse(choiceInput, out choice);

                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    continue;
                }

                // Perform actions based on user choice
                switch (choice)
                {
                    case 1:
                        hunger = hunger - 1;
                        if(hunger < 0)
                        {
                            hunger = 0;
                        }
                        health =  health + 1;
                        if(health > 10)
                        {
                            health = 10;
                        }
                        Console.WriteLine($"{petName} has been fed. Hunger: {hunger}, Health: {health}");
                        break;
                    case 2:
                        if(hunger > 8)
                        {
                            Console.WriteLine($"{petName} refused to play due to hunger");
                        }
                        else
                        {
                            happiness = happiness + 1;
                            if (happiness > 10)
                            {
                                happiness = 10;
                            }
                            hunger = hunger + 1;
                            if (hunger > 10)
                            {
                                hunger = 10;
                            }
                            Console.WriteLine($"{petName} played. Happiness: {happiness}, Hunger: {hunger}");
                        }
                        
                        break;
                    case 3:
                        if(happiness < 2)
                        {
                            Console.WriteLine($"{petName} is not resting due to illness");
                        }
                        else
                        {
                            health = health + 1;
                            if (health > 10)
                            {
                                health = 10;
                            }
                            happiness = happiness - 1;
                            if (happiness < 0)
                            {
                                happiness = 0;
                            }
                            Console.WriteLine($"{petName} is resting. Health: {health}, Happiness: {happiness}");
                        }
                        break;
                    case 4:
                        Console.WriteLine($"Status of {petName} \n Hunger: {hunger} \n Happiness: {happiness} \n Health: {health}");
                        break;
                    case 5:
                        Console.WriteLine("Exiting the game. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
                hunger =  hunger + 1;
                happiness =  happiness - 1;

                if(happiness < 0)
                {
                    happiness = 0;
                }
                if(hunger > 10)
                {
                    hunger = 10;
                }

                // Check for neglect
                if (hunger >= 10 || happiness <= 0 || health <= 0)
                {
                    Console.WriteLine($"Warning! {petName} is not doing well.");
                    if (hunger >= 10)
                    {
                        health = health - 1 ;
                        Console.WriteLine($"{petName} is starving! Health: {health}");
                    }
                    if (happiness <= 0)
                    {
                        health = health - 1;
                        Console.WriteLine($"{petName} is extremely unhappy! Health: {health}");
                    }
                }

                // Check for special messages
                if (hunger >= 8) Console.WriteLine($"{petName} is very hungry and may refuse to play!");
                if (happiness <= 2) Console.WriteLine($"{petName} is very unhappy and may refuse to rest!");


            }
        }

       
    }
}
