using PathFinder;
using PathFinder.MapGeneration;
using System.Collections.Generic;

namespace  PathFinder
{
    public class BreadthFirstSearch : IPathFinder
    {

    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);


        Queue<Point> queue = new Queue<Point>();
        int[,] distances = new int[height, width];
        Point[,] fromwhere = new Point[height, width];
        // int head = 0;

        queue.Enqueue(start);
        distances[start.Row, start.Column] = 1;

        // int right = 1;
        // int left = -1;
        // int down = 1;
        // int up = -1;
        // int permanent = 0;

        int[] x = { 1, -1, 0, 0 };
        int[] y = { 0, 0, 1, -1 };

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

            for (int i = 0; i < 4; i++)
            {
                int newRow = current.Row + y[i];
                int newColumn = current.Column + x[i];


                if (newRow >= 0 && newRow < height
                                && newColumn >= 0 && newColumn < width
                                && map[newColumn, newRow] != "█"
                                && distances[newRow, newColumn] == 0)
                {
                    Point neighbour = new Point(newColumn, newRow);

                    queue.Enqueue(neighbour);
                    distances[newRow, newColumn] = distances[current.Row, current.Column] + 1;
                    fromwhere[newRow, newColumn] = current;
                }
            }
        }

        List<Point> path = new List<Point>();

        if (!found)
        {
            return (path, visitedCount);
        }

        Point d = destination;
        while (!d.Equals(start))
        {
            path.Add(d);
            d = fromwhere[d.Row, d.Column];
        }

        path.Add(start);
        path.Reverse();

        return (path, visitedCount);
    }
    }
}


