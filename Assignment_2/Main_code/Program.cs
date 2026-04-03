using PathFinder;
using PathFinder.MapGeneration;
using System;
using System.Collections.Generic;


partial class Program
{
    static void Main()
    {
        var options = new MapGeneratorOptions
        {
            Width = 100,
            Height = 10,
            Noise = (float)0.3,
            Seed = 1
        };
        
        var generator = new MapGenerator(options);
        string[,] map = generator.Generate();
        
        Point start = new Point(0, 0);
        Point destination = new Point(60, 0);
        
        map[start.Column, start.Row] = ".";
        map[destination.Column, destination.Row] = ".";
        
        IPathFinder bfs = new BreadthFirstSearch();
        var result = bfs.FindPath(map, start, destination);
        
        List<Point> path = result.Item1;
        int distance = result.Item2;

        Console.WriteLine($"Distance: {distance}");
        Console.WriteLine($"Path: {path.Count}");

        MapPrinter printer = new MapPrinter();
        
        printer.Print(map, path);
        
    }
}