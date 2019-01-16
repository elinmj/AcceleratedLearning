using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JulUppgift
{
    public class PlayingCardGame
    {
        public void Game()
        {
            WelcomeUser();
            Menu();
            Quit();
        }

        private void WelcomeUser()
        {
            Console.WriteLine("Welcome to play 'High or Low'!\n");

            Console.ReadKey();
            Console.Clear();
        }

        private void Menu()
        {
            int menuChoice;

            do
            {
                Console.WriteLine("Select:\n");
                Console.Write("1. Play\n2. Rules\n3. High Score\n4. Quit\n");

                menuChoice = int.Parse(Console.ReadLine());

                Console.Clear();

            } while (menuChoice != 1 && menuChoice != 2 && menuChoice != 3 && menuChoice != 4);

            if (menuChoice == 1)
            {
                StartingGame();
            }
            if (menuChoice == 2)
            {
                Rules();
            }
            if (menuChoice == 3)
            {
                CheckScore();
            }
            if (menuChoice == 4)
            {
                Quit();
            }
            else
            {
                Quit();
            }

        }

        private void Rules()
        {
            Console.WriteLine("Rules:\n");
            Console.WriteLine("Two cards are given to you from the deck.\nGuess if the one you're holding is higher or lower than the one visible on the table.\n");
            Console.WriteLine("You win over me, the machine, if you get five points or more! Go play!");


            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        private void CheckScore()
        {
            string hiscores = @"C:\Project\AcceleratedLearning\JulUppgift\scores.txt";
            string[] scorelines = File.ReadAllLines(hiscores);
            Console.WriteLine("High Scores:\n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\t{scorelines[i]}");
            }

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        private void Quit()
        {
            Console.WriteLine("Welcome back!");

            Console.ReadKey();
            Console.Clear();
        }

        public void StartingGame()
        {
            Player.WrongGuess = 0;

            List<Player> playerList = Player.CreatePlayer();

            Play(playerList);
            
            Console.Clear();

        }

        public void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Play again?");

            Console.WriteLine("1. Menu\n2. Quit\n");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.Clear();
                Menu();
                
            }
            else
            {
                Console.Clear();
                Quit();
            }

        }

        private void Play(List<Player> playerList)
        {
            PlayingCardDeck deck = new PlayingCardDeck();
            List<PlayingCard> deckList = deck.Deck();
            List<PlayingCard> deckListShuffled = deck.Shuffle(deckList);

            bool GameOver;
            int counter = 0;
            int turn = 1;

            do
            {
                if (playerList.Count == 1)
                {
                    if (playerList[0].Score == 0)
                    {
                        Console.WriteLine($"Hi, {playerList[0].Name}! Draw the two top cards\n");
                    }
                    else
                    {
                        Console.WriteLine($"Way to go, {playerList[0].Name}! Draw the two top cards\n");
                    }
                }
                else
                {
                    if (playerList[0].Score == 0)
                    {
                        Console.WriteLine($"Hi, {playerList[counter].Name}! Draw the two top cards\n");
                    }
                    else
                    {
                        Console.WriteLine($"Your turn, {playerList[counter].Name}! Draw the two top cards\n");
                    }

                }

                Console.ReadKey();
                Console.Clear();

                deck.TakeFirstCards(deckListShuffled); 

                GameOver = deck.Guess(deckListShuffled, playerList, counter, turn);
                 
                deckListShuffled = deck.AddLastCards(deckListShuffled);


                Console.ReadKey();
                Console.Clear();

                turn++;

                if (playerList.Count == 2)
                {
                    if ((counter % 2) == 0)
                    {
                        counter++;
                    }
                    else
                    {
                        counter--;
                    }
                }

            } while (GameOver == true);

            if (playerList.Count == 1)
            {
                if (playerList[0].Score > 4)
                {
                    Console.WriteLine($"Wow! You got {playerList[0].Score} and WON over the machine!!" );
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }
            }
            else
            {
                if (playerList[0].Score > playerList[1].Score)
                {
                    Console.WriteLine($"{playerList[0].Name} got {playerList[0].Score} points and WON over {playerList[1].Name}!!\n");
                }
                else if (playerList[0].Score == playerList[1].Score)
                {
                    Console.WriteLine("Wow! It's a draw! Rematch perhaps??\n");
                }
                else
                {
                    Console.WriteLine($"{playerList[1].Name} got {playerList[1].Score} points and WON over {playerList[0].Name}!!\n");
                }
            }

            Console.ReadKey();
            Console.Clear();

            Player.GenerateScore(playerList, turn);
            
            EndGame();

        }

          
    }
}
