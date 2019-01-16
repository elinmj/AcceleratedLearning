using System;
using System.Collections.Generic;
using System.Text;

namespace JulUppgift
{
    class PlayingCardDeck
    {
        private bool shown = false;

        public List<PlayingCard> Deck()
        {

            List<PlayingCard> deckList = new List<PlayingCard>();

            foreach (PlayingCard.Suit suit in Enum.GetValues(typeof(PlayingCard.Suit)))
            {
                foreach (PlayingCard.Value value in Enum.GetValues(typeof(PlayingCard.Value)))
                {
                    deckList.Add(new PlayingCard(value, suit, shown));
                }
            }

            return deckList;

        }

        

        public void TakeFirstCards(List<PlayingCard> deckListShuffled)
        {
            Console.WriteLine($"{deckListShuffled[0].value} of {deckListShuffled[0].suit}\n");

        }

        public List<PlayingCard> AddLastCards(List<PlayingCard> deckListShuffled)
        {
            for (int i = 0; i < 2; i++)
            {
                var first = deckListShuffled[0];
                deckListShuffled.RemoveAt(0);
                deckListShuffled.Add(first); 
            }

            return deckListShuffled;
        }

        public List<PlayingCard> Shuffle(List<PlayingCard> deckList)
        {
            Random random = new Random();
            int n = deckList.Count;

            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                PlayingCard x = deckList[r];
                deckList[r] = deckList[i];
                deckList[i] = x;
            }

            return deckList;
        }

        public bool Guess(List<PlayingCard> deckList, List<Player> playerList, int counter, int turn)
        {
            Console.WriteLine("Higher or lower(h/l)?");
            string userInput = Console.ReadLine();
            Console.Clear();

            if (userInput.ToLower() == "h" && deckList[0].value < deckList[1].value)
            {
                playerList[counter].Score++;
                Console.WriteLine($"Yay!\nIt was {deckList[1].value} of {deckList[1].suit}!\nScore: {playerList[counter].Score}");
                if (Player.WrongGuess > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (userInput.ToLower() == "h" && deckList[0].value == deckList[1].value && deckList[0].suit < deckList[1].suit)
            {
                playerList[counter].Score++;
                Console.WriteLine($"Yay!\nIt was {deckList[1].value} of {deckList[1].suit}!\nScore: {playerList[counter].Score}");
                if (Player.WrongGuess > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (userInput.ToLower() == "l" && deckList[0].value > deckList[1].value)
            {
                playerList[counter].Score++;
                Console.WriteLine($"Yay!\nIt was {deckList[1].value} of {deckList[1].suit}!\nScore: {playerList[counter].Score}");
                if (Player.WrongGuess > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (userInput.ToLower() == "l" && deckList[0].value == deckList[1].value && deckList[0].suit > deckList[1].suit)
            {
                playerList[counter].Score++;
                Console.WriteLine($"Yay!\nIt was {deckList[1].value} of {deckList[1].suit}\nScore: {playerList[counter].Score}");
                if (Player.WrongGuess > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"No!\nIt was {deckList[1].value} of {deckList[1].suit}\n");
                Console.Beep();

                
                if (turn % 2 == 0)
                {
                    return false;
                }
                else
                {
                    Player.WrongGuess++;
                    return true;
                }
                
            }


        }
    }
}
