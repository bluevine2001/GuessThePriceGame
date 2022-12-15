using System;

namespace GuessThePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Random random = new Random();

            // int correctPrice = random.Next(1,101);
            // bool gameStillRunning = true;
            // Console.WriteLine("Guess the price of the item : ");
            // do{
            //     string userInput = Console.ReadLine();
            //     int guess = int.Parse(userInput);
            //     if(correctPrice == guess){
            //         Console.WriteLine("Yes, the correct price was " + correctPrice);
            //         gameStillRunning = false;
            //     }else{
            //         if(guess > correctPrice){
            //             Console.WriteLine("Sorry, You're still too high !");
            //         }else if(guess < correctPrice && guess > 0){
            //             Console.WriteLine("Sorry, You're still too low !");
            //         }else{
            //             Console.WriteLine("Error, the price is not positive : " + correctPrice);
            //         }
                    
            //     }
            // }while(gameStillRunning == true);

            Game game = new Game();
            game.gameInit();
            game.gameStart();
        }
    }

    class Game{
        public int correctPrice { get; set; }
        public bool gameStillRunning { get; set; }
        public int maxAttempts { get;set; }
        public int score { get;set; }
        public void gameStart(){
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            Guess The Price !          ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Guess the price of the item : ");
            do{
                Console.WriteLine("Available Attempts : " + maxAttempts);
                string userInput = Console.ReadLine();
                int guess = int.Parse(userInput);
                if(correctPrice == guess){
                    Console.WriteLine("Yes, the correct price was " + correctPrice);
                    gameStillRunning = false;
                }else{
                    if(guess > correctPrice){
                        Console.WriteLine("Sorry, You're still too high !");
                        maxAttempts -= 1;
                        score -= 100;
                    }else if(guess < correctPrice && guess > 0){
                        Console.WriteLine("Sorry, You're still too low !");
                        maxAttempts -= 1;
                        score -= 100;
                    }else{
                        Console.WriteLine("Error, the price is not positive : " + correctPrice);
                    }
                    
                }
            }while(gameStillRunning == true && maxAttempts > 0);
            if(maxAttempts == 0 || gameStillRunning == false){
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Game Over");
                Console.WriteLine("Your score is : " + score);
                Console.WriteLine("Would you like to restart ? (Y/N)");
                string userResponse = Console.ReadLine();
                if(userResponse == "Y" || userResponse == "y"){
                    gameInit();
                    gameStart();
                }else{
                    Console.WriteLine("Goodbye");
                }
            }
        }
        public void gameInit(){
            Random random = new Random();
            correctPrice = random.Next(1,101);
            maxAttempts = 10;
            score = 1000;
            gameStillRunning = true;
        }
    }
}