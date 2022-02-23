using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDungeon.DungeonEnums;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Utilities;

namespace DynamicDungeon.DungeonWorld
{
    internal class DungeonGenerator
    {
        private bool[] rooms;
        private RoomType[] roomsType;

        private Random random;

        private Vector2 endPoint;

        private int width;
        private int height;

        private int level = 1;

        public DungeonGenerator(int width, int height, int level = 1)
        {
            this.random = new Random();
            this.rooms = new bool[width * height];
            this.width = width;
            this.height = height;
            this.level = level;
        }

        public void GenerateDungeon()
        {
            var queue = PopulateArray();
            AssignRoom(queue);
        }

        public RoomType[] GetGeneratedDungeon()
        {
            return roomsType;
        }

        public Queue<int> PopulateArray()
        {
            int roomNumber = (int) (random.Next(10, 15) + level * 2.6);

            Point StartingPoint = new Point(width / 2, height / 2);

            Queue<int> pointCollection = new Queue<int>(roomNumber);
            pointCollection.Enqueue(GetIndex(StartingPoint));


            while (pointCollection.Count < roomNumber)
            {
                int[] array = new int[pointCollection.Count];
                pointCollection.CopyTo(array, 0);
                foreach (int i in array)
                {
                    List<int> pointList = GetPointList(i);

                    foreach (int i2 in pointList)
                    {
                        Point pi2 = GetPoint(i2);
                        if (!InBound(GetPoint(i2)) || pointCollection.Contains(i2) || random.Next(0, 2) == 1 || NeighbourContainRoom(pointCollection, GetPointList(i2), i2))
                        {
                            continue;
                        }

                        if (pointCollection.Count > roomNumber)
                        {
                            break;
                        }

                        if (i2 < 0 || i2 > width * height)
                            continue;


                        pointCollection.Enqueue(i2);
                    }
                }
            }

            foreach (int i in pointCollection)
            {
                rooms[i] = true;
            }

            for (int i = 0; i < width; i++)
            {
                Console.Write("        ");
                for (int j = 0; j < height; j++)
                {
                    Console.BackgroundColor = (rooms[i + width * j]) ? ConsoleColor.DarkGreen : ConsoleColor.White;
                    Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            return pointCollection;
        }

        public void AssignRoom(Queue<int> assignedRoom)
        {
            roomsType = new RoomType[rooms.Length];
            for (int i = 0; i < roomsType.Length; i++)
            {
                roomsType[i] = RoomType.noRoom;
            }

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i])
                    roomsType[i] = RoomType.BasicRoom;
            }

            
            roomsType[assignedRoom.Peek()] = RoomType.StartingRoom;

            Queue<int> specialRoomTypesQueue = new Queue<int>();

            int bossRoomPosition = 0;

            foreach (var roomCoordinate in assignedRoom)
            {
                
                if (NeighbourContainsRoom(assignedRoom, GetPointList(roomCoordinate), roomCoordinate))
                {
                    specialRoomTypesQueue.Enqueue(roomCoordinate);
                    bossRoomPosition = roomCoordinate;
                }
            }

            roomsType[bossRoomPosition] = RoomType.BossRoom;



            Queue<RoomType> roomType = new Queue<RoomType>();
            roomType.Enqueue(RoomType.RewardRoom);
            roomType.Enqueue(RoomType.trapRoom);
            roomType.Enqueue(RoomType.InvasionRoom);

            for (int i = 0; i < specialRoomTypesQueue.Count; i++)
            {
                int roomPosition = specialRoomTypesQueue.Dequeue();

                if (roomType.Count != 0 && roomsType[roomPosition] == RoomType.BasicRoom)
                {
                    roomsType[roomPosition] = roomType.Dequeue();
                }
            }
        }


        public Point GetPoint(int index)
        {
            return new Point(GetX(index), GetY(index));
        }

        public int GetX(int index)
        {
            return index % width;
        }

        public int GetY(int index)
        {
            return (index / width) % height;
        }

        public List<int> GetPointList(int i)
        {
            return new List<int>()
                {
                    i + width,
                    i - width,
                    i + 1,
                    i - 1
                };
        }

        public bool NeighbourContainRoom(Queue<int> currentAddedRoom, List<int> roomSet, int currentCheckingRoom)
        {
            int countingRoom = 0;
            foreach (int room in roomSet)
            {
                if (currentAddedRoom.Contains(room) && room != currentCheckingRoom)
                {
                    countingRoom++;
                }
            }
            return countingRoom > 1;
        }

        public bool NeighbourContainsRoom(Queue<int> currentAddedRoom, List<int> roomSet, int currentCheckingRoom)
        {
            int countingRoom = 0;
            foreach (int room in roomSet)
            {
                if (currentAddedRoom.Contains(room) && room != currentCheckingRoom)
                {
                    countingRoom++;
                }
            }
            return countingRoom == 1;
        }

        public int GetIndex(int x, int y)
        {
            return x + width * y;
        }

        public int GetIndex(Point point)
        {
            return GetIndex(point.X, point.Y);
        }

        public bool InBound(Point point)
        {
            return InBound(point.X, point.Y);
        }

        public bool InBound(int x, int y)
        {
            return x >= 0 || y >= 0 || x <= width || y <= height;
        }
    }

}
