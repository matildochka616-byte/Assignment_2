using PathFinder;
using PathFinder.MapGeneration;
using System.Collections.Generic;

namespace  PathFinder
{
    public class BreadthFirstSearch : IPathFinder
    {
        public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
        {
            Queue<Point> queue = new Queue<Point>();
            var distances = new Dictionary<Point, int>();
            var origins = new Dictionary<Point, Point>();
            // int head = 0;

            queue.Enqueue(start);
            distances[start] = 0;

            int right = 1;
            int left = -1;
            int down = 1;
            int up = -1;
            int permanent = 0;

            int[] x = { right, left, permanent, permanent };
            int[] y = { permanent, permanent, down, up };

            int visitedCount = 0;

            bool found = false;

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();
                visitedCount++;

                if (current.Equals(destination))
                {
                    found = true;
                    break;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int newx = current.Column + x[i];
                        int newy = current.Row + y[i];
                        Point neighbour = new Point(newy, newx);

                        if (newx >= 0 && newx < map.GetLength(1)
                                      && newy >= 0 && newy < map.GetLength(0)
                                      && map[newy, newx] != "#"
                                      && !distances.ContainsKey(neighbour))
                        {
                            queue.Enqueue(neighbour);
                            distances[neighbour] = distances[current] + 1;
                            origins[neighbour] = current;
                        }
                    }
                }
            }

            List<Point> path = new List<Point>();

            if (!found)
            {
                return (path, 0);
            }

            Point d = destination;
            while (!d.Equals(start))
            {
                path.Add(d);
                d = origins[d];
            }
            path.Add(start);
            path.Reverse();

            return (path, visitedCount);
        }
    }
}


