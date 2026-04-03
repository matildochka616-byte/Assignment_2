// using PathFinder;
// using PathFinder.MapGeneration;
//
// var optionsToGenerate = new MapGeneratorOptions()
// {
//     Height = 10,
//     Width = 100,
// };
//
// var generator = new MapGenerator(optionsToGenerate);
// string[,]? map = generator.Generate();
//
// Point start = new Point(0,0);
// Point destination = new Point(99, 9);
//
// IPathFinder bfs = new BreadthFirstSearch();
// var result = bfs.FindPath(map, start, destination);
//
// List<Point> path = result.Item1;
// int distance = result.Item2;
//
// Console.WriteLine($"Distance: {distance}");
// Console.WriteLine($"Path: {path.Count}");
//
// new MapPrinter().Print(map, path);
