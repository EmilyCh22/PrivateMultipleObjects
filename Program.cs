using System;
namespace Lesson4_PrivateMultipleObjects
{
    class Game
    {
        private string title;
        private string type;
        private double price;

        public Game()
        {
            title = string.Empty;
            type = string.Empty;
            price = 0;
        }
        public Game(string title, string type, int price)
        {
            this.title = title;
            this.type = type;
            this.price = price;
        }

        public void setTitle(string title) { this.title = title; }
        public string getTitle() { return title; }
        public void setType(string type) { this.type = type; }
        public string getType() { return type; }
        public void setPrice(double price) { this.price = price; }
        public double getPrice() { return price; }

        public virtual void addChange()
        {
            setTitle(Validator.InputValidString("What is the game title? "));
            setType(Validator.InputValidString("What type of game is it? "));
            setPrice(Validator.InputValidDouble("How much does it cost? "));
        }
        public virtual void Display()
        {
            Console.WriteLine("\n~*~*~*~*~*~ Game Info ~*~*~*~*~*~");
            Console.WriteLine($"      Title: {title}");
            Console.WriteLine($"       Type: {type}");
            Console.WriteLine($"      Price: {price:C}");
        }
    }
    class VideoGame : Game
    {
        private int copiesSold;
        private string platform;

        public VideoGame()
            :base()
        {
            copiesSold = 0;
            platform = string.Empty;
        }
        public VideoGame(string title, string type, int price, int copiesSold, string platform)
            :base(title, type, price)
        {
            this.copiesSold = copiesSold;
            this.platform = platform;
        }

        public void setCopies(int copies) { copiesSold = copies; }
        public int getCopies() { return copiesSold; }
        public void setPlatform(string platform) { this.platform = platform; }
        public string getPlatform() { return platform; }

        public override void addChange()
        {
            base.addChange();
            setCopies(Validator.InputValidInt("How many copies of this game have been sold? "));
            setPlatform(Validator.InputValidString("What platform(s) is this game available on? "));
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Copies Sold: {copiesSold:n0}");
            Console.WriteLine($"Platform(s): {platform}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int maxGames = Validator.InputValidInt("How many games would you like to enter? ");
            Game[] games = new Game[maxGames];
            int maxVidGam = Validator.InputValidInt("How many video games would you like to enter? ");
            VideoGame[] videoGames = new VideoGame[maxVidGam];

            int gameCount = 0, VGCount = 0, index;

            int choice = Menu();
            while (choice != 4)
            {
                int type = Validator.InputValidInt("1 for Games, 2 for Video Games : ");
                try
                {
                    switch (choice)
                    {
                        case 1: //Add
                            if (type == 1) //Games
                            {
                                if (gameCount <= maxGames)
                                {
                                    games[gameCount] = new Game(); //Places new game into array
                                    games[gameCount].addChange();
                                    gameCount++;
                                }
                                else
                                    Console.WriteLine("You have the maximum number of games added.");
                            }
                            else if (type == 2) //Video Games
                            {
                                if (VGCount <= maxVidGam)
                                {
                                    videoGames[VGCount] = new VideoGame(); //Places new video game into array
                                    videoGames[VGCount].addChange();
                                    VGCount++;
                                }
                                else
                                    Console.WriteLine("You have the maximun number of video games added.");
                            }
                            else
                                Console.WriteLine("You made an invalid choice.");
                            break;
                        case 2: //Change
                            index = Validator.InputValidInt("Enter the item number you would like to change: ") - 1;
                            if (type == 1) //Games
                            {
                                if (gameCount == 0)
                                {
                                    Console.WriteLine("You don't have anything in your list yet!");
                                    break;
                                }
                                else
                                {
                                    while (index > gameCount - 1 || index < 0)
                                    {
                                        Console.WriteLine("The number you entered was out of range. Try again.");
                                        index = Validator.InputValidInt("Enter the item number you would like to change: ") - 1;
                                    }
                                    games[index].addChange();
                                }
                            }
                            else if (type == 2) //Video Games
                            {
                                if (VGCount == 0)
                                {
                                    Console.WriteLine("You don't have anything in your list yet!");
                                    break;
                                }
                                else
                                {
                                    while (index > gameCount - 1 || index < 0)
                                    {
                                        Console.WriteLine("The number you entered was out of range. Try again.");
                                        index = Validator.InputValidInt("Enter the item number you would like to change: ") - 1;
                                    }
                                    videoGames[index].addChange();
                                }
                            }
                            else
                                Console.WriteLine("You made an invalid selection.");
                            break;
                        case 3: //Print
                            if (type == 1)
                            {
                                for (int i = 0; i < gameCount; i++)
                                    games[i].Display();
                            }
                            else if (type == 2)
                            {
                                for (int i = 0; i < gameCount; i++)
                                    videoGames[i].Display();
                            }
                            else
                                Console.WriteLine("You made an invalid selection.");
                            break;
                    }
                }
                catch (IndexOutOfRangeException e) { WriteLineRed(e.Message); }
                catch (FormatException e) { WriteLineRed(e.Message); }
                catch (Exception e)
                {
                    WriteLineRed("Unknown error encountered.");
                    WriteLineRed($"Error Message: {e.Message}");
                }
                finally { choice = Menu(); }
            }
        }
        private static int Menu()
        {
            int menu = 0;
            while (true)
            {
                Console.WriteLine("\nPlease make a selection from the menu:");
                Console.WriteLine("1:Add   2:Change   3:Print   4:Quit");
                menu = Validator.InputValidInt(" : ");
                if (menu < 1 || menu > 4)
                {
                    Console.WriteLine("\nPlease make a valid selection\n");
                    continue;
                }
                else
                    return menu;
            }
        }
        private static void WriteLineRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}