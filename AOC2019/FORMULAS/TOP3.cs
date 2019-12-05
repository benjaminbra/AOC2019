using System;
using System.Collections.Generic;

namespace AOC2019.FORMULAS
{
    public class TOP3
    {
        public static void DoMyWorkSteps(List<string> run1, List<string> run2)
        {
            Console.WriteLine("START PROCESS - LOAD RUN 1");
            List<Key> keys1 = DoParcour(run1);
            Console.WriteLine("END RUN 1 :" + keys1.Count + " steps - LOAD RUN 2");
            List<Key> keys2 = DoParcour(run2);
            Console.WriteLine("END RUN 2 :" + keys2.Count + " steps - SEARCH INTERSECTIONS");
            int shortTestDistance = -1;
            int step1 = 0;
            foreach (var key1 in keys1)
            {
                step1++;
                int step2 = 0;
                Console.WriteLine("Go Step : " + step1 + " / " + keys1.Count + " - Shortest : " + shortTestDistance);
                foreach (var key2 in keys2)
                {
                    step2++;
                    if (key1.Equals(key2))
                    {
                        int actualDistance = step1 + step2;
                        if (shortTestDistance == -1 || actualDistance < shortTestDistance)
                        {
                            shortTestDistance = actualDistance;
                            Console.WriteLine(shortTestDistance);
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(shortTestDistance);
        }
        
        public static void DoMyWork(List<string> run1, List<string> run2)
        {
            Console.WriteLine("START PROCESS - LOAD RUN 1");
            List<Key> keys1 = DoParcour(run1);
            Console.WriteLine("END RUN 1 :" + keys1.Count + " steps - LOAD RUN 2");
            List<Key> keys2 = DoParcour(run2);
            Console.WriteLine("END RUN 2 :" + keys2.Count + " steps - SEARCH INTERSECTIONS");
            int shortTestDistance = -1;
            int step = 0;
            foreach (var key1 in keys1)
            {
                step++;
                Console.WriteLine("Go Step : " + step + " / " + keys1.Count + " - Shortest : " + shortTestDistance);
                foreach (var key2 in keys2)
                {
                    if (key1.Equals(key2))
                    {
                        int actualDistance = GetDistance(key2);
                        if (shortTestDistance == -1 || actualDistance < shortTestDistance)
                        {
                            shortTestDistance = actualDistance;
                            Console.WriteLine(shortTestDistance);
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(shortTestDistance);
        }

        public static int GetDistance(Key distance)
        {
            return Math.Abs(distance.x) + Math.Abs(distance.y);
        }

        public static List<Key> DoParcour(List<string> run)
        {
            List<Key> keys = new List<Key>();
            Key start = new Key(0, 0);
            keys.Add(start);
            foreach (var command in run)
            {
                keys.AddRange(DoMove(keys[keys.Count - 1], command));
            }

            keys.Remove(start);
            return keys;
        }

        public static List<Key> DoMove(Key key, string command)
        {
            int x = 0;
            int y = 0;
            string distance = command.Substring(1);
            List<Key> keys = new List<Key>();
            if (command[0] == 'U')
            {
                x += Int32.Parse(distance);
                for (int i = 1; i <= x; i++)
                {
                    keys.Add(new Key(key.x + i, key.y));
                }
            }
            else if (command[0] == 'R')
            {
                y += Int32.Parse(distance);
                for (int i = 1; i <= y; i++)
                {
                    keys.Add(new Key(key.x, key.y + i));
                }
            }
            else if (command[0] == 'D')
            {
                x -= Int32.Parse(distance);
                for (int i = -1; i >= x; i--)
                {
                    keys.Add(new Key(key.x + i, key.y));
                }
            }
            else if (command[0] == 'L')
            {
                y -= Int32.Parse(distance);
                for (int i = -1; i >= y; i--)
                {
                    keys.Add(new Key(key.x, key.y + i));
                }
            }

            return keys;
        }
    }
}