using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JulUppgift
{
    class Player
    {
        public string Name { get; set; }
        //public int Position { get; set; }
        public int Score { get; set; }
        public static int WrongGuess { get; set; }

        internal static List<Player> CreatePlayer()
        {
            int players;
            List<Player> playerList = new List<Player>();

            do
            {
                Console.WriteLine("Select players (1-2):");
                players = int.Parse(Console.ReadLine());

                Console.Clear();

            } while (players != 1 && players != 2);

            for (int i = 1; i <= players; i++)
            {
                Player newPlayer = new Player();
                Console.WriteLine($"Name Player {i}:");
                newPlayer.Name = Console.ReadLine();
                playerList.Add(newPlayer);
                Console.WriteLine();
            }

            Console.Clear();
            return playerList;

        }

        internal static void GenerateScore(List<Player> playerList, int turn)
        {
            Console.WriteLine($"Turns: {(turn-1)/2}\n");
            foreach (var player in playerList)
            {
                Console.WriteLine($"{player.Name} score: {player.Score}");
            }
            Console.WriteLine();

            string hiscores = @"C:\Project\AcceleratedLearning\JulUppgift\scores.txt";
            List<string> scoreList;

            if (File.Exists(hiscores))
            {
                scoreList = File.ReadAllLines(hiscores).ToList();
            }
            else
            {
                scoreList = new List<string>();
            }

            foreach (var player in playerList)
            {
                scoreList.Add(player.Name + "\t" + player.Score.ToString());
                IOrderedEnumerable<string> sortedScoreList = scoreList.OrderByDescending(ss => int.Parse(ss.Substring(ss.LastIndexOf("\t") + 1)));
                File.WriteAllLines(hiscores, sortedScoreList.ToArray());
            }

            string[] scorelines = File.ReadAllLines(hiscores);
            Console.WriteLine("High Scores:\n");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\t{scorelines[i]}");
            }
           
            Console.ReadKey();
        }
    }
}
