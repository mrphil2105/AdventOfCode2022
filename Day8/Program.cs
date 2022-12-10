namespace Day8;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = new ForestBuilder();
        var forest = Enumerable.Range(0, int.MaxValue)
            .Select(_ => Console.ReadLine())
            .TakeWhile(l => l != null)
            .Select(builder.Append!)
            .Last()
            .Build();

        var partString = args.Length > 0 ? args[0] : "1";

        if (!int.TryParse(partString, out var part))
        {
            Console.WriteLine($"Invalid part '{args[0]}' specified.");

            return;
        }

        var parts = new Dictionary<int, Action<Forest>> { { 1, PartOne }, { 2, PartTwo } };

        if (!parts.TryGetValue(part, out var action))
        {
            var validParts = string.Join(", ", parts.Keys);
            Console.WriteLine($"Invalid part '{args[0]}' specified. Must be one of: {validParts}");

            return;
        }

        action(forest);
    }

    private static void PartOne(Forest forest)
    {
        var visible = forest.Width * 2 + forest.Height * 2 - 4;

        for (var x = 1; x < forest.Width - 1; x++)
        {
            for (var y = 1; y < forest.Height - 1; y++)
            {
                var tree = forest.GetTree(x, y);

                if (tree.TallerThanAll(tree.DirectionTrees(Left, forest)) ||
                    tree.TallerThanAll(tree.DirectionTrees(Right, forest)) ||
                    tree.TallerThanAll(tree.DirectionTrees(Above, forest)) ||
                    tree.TallerThanAll(tree.DirectionTrees(Below, forest)))
                {
                    visible++;
                }
            }
        }

        Console.WriteLine(visible);
    }

    private static void PartTwo(Forest forest)
    {
        var directions = Enum.GetValues<Direction>();
        var maxScore = 0;

        for (var x = 0; x < forest.Width; x++)
        {
            for (var y = 0; y < forest.Height; y++)
            {
                var tree = forest.GetTree(x, y);
                var distances = directions.Select(direction => tree.DistanceToScenicTree(direction, forest));

                var score = distances.Aggregate((a, b) => a * b);

                if (score > maxScore)
                {
                    maxScore = score;
                }
            }
        }

        Console.WriteLine(maxScore);
    }
}
