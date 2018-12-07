using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint02
{
    class Program
    {
        static void Main(string[] args)
        {
            //RoomListLevel1();
            RoomListLevel2();

        }


        private static void RoomListLevel1()
        {

            Console.WriteLine("Ange rum:");

            string userInput = Console.ReadLine();
            string[] userInputArray = userInput.Split('|');
            List<Room> roomList = new List<Room>();

            foreach (var item in userInputArray)
            {
                Room newRoom = new Room();
                string rooms = item.Trim().Replace("m2", "");
                string[] roomsSplit = rooms.Split(' ');
                newRoom.Name = roomsSplit[0];
                newRoom.Area = int.Parse(roomsSplit[1]);
                roomList.Add(newRoom);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            int counter = 1;

            foreach (var room in roomList)
            {
                Console.WriteLine($"* Rumnamn {counter}: {room.Name}" );
                counter++;
            }

            foreach (var room in roomList.OrderByDescending(x => x.Area))
            {
                    Console.WriteLine($"* Det största rummet är {room.Name} på {room.Area}m2");
                    break;
            }

            Console.WriteLine();
            Console.ResetColor();
        }


        private static void RoomListLevel2()
        {
            Console.WriteLine("Ange rum i lägenheten:");

            string userInput = Console.ReadLine();
            string[] userInputArray = userInput.Split('|');
            List<Room> roomList = new List<Room>();

            foreach (var item in userInputArray)
            {
                Room newRoom = new Room();
                string rooms = item.Trim().Replace("m2", "");
                string[] roomsSplit = rooms.Split(' ');

                newRoom.Name = roomsSplit[0];
                newRoom.Area = int.Parse(roomsSplit[1]);
                newRoom.Lights = roomsSplit[2];

                roomList.Add(newRoom);
            }

           
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            List<string> lightsOnList = new List<string>();

            foreach (var room in roomList)
            {
                if (room.Lights == "On")
                {
                    lightsOnList.Add(room.Name);
                }
            }

            if (lightsOnList.Count > 0)
            {
                string lightsOn = string.Join(" och ", lightsOnList);
                Console.WriteLine($"Ljuset är tänt i {lightsOn}");
            }
            else if (lightsOnList.Count == 0)
            {
                Console.WriteLine("Inget rum är tänt");
            }

            foreach (var room in roomList.OrderByDescending(x => x.Area))
            {
                Console.WriteLine($"Det största rummet är {room.Name}, på {room.Area}m2");
                break;
            }

            Console.WriteLine($"Lägenheten består av {roomList.Count} rum");


            Console.WriteLine();
            Console.ResetColor();
        }

    }               
}
