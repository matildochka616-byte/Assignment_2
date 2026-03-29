using PathFinder.MapGeneration;

var optionsToGenerate = new MapGeneratorOptions()
{
    Height = 10,
    Width = 100,
};

var generator = new MapGenerator(optionsToGenerate);
string[,]? map = generator.Generate();

new MapPrinter().Print(map);
