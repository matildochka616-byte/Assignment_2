namespace PathFinder.MapGeneration
{
    using System;
    using System.Collections.Generic;

    public class MapPrinter
    {
        public void Print(string[,] maze, List<Point> path)
        {
            PrintTopLine();
            
            Point start = new Point(0, 0);
            Point end = new Point(8, 8);

            if (path.Count > 0)
            {
                start = path[0];
                end = path[path.Count - 1];
            }
            for (var row = 0; row < maze.GetLength(1); row++)
            {
                
                Console.Write($"{row}\t");
                for (var column = 0; column < maze.GetLength(0); column++)
                {
                    Point current = new Point(column, row);

                    if (path.Contains(current))
                    {
                        if (current.Equals(start))
                        {
                            Console.Write("A");
                        }
                        else if (current.Equals(end))
                        {
                            Console.Write("B");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    else
                    { 
                        Console.Write(maze[column, row]);
                    }
                }

                Console.WriteLine();
            }

            void PrintTopLine()
            {
                Console.Write($" \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10 == 0? i / 10 : " ");
                }
    
                Console.Write($"\n \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10);
                }
    
                Console.WriteLine("\n");
            }
        }
    }
}