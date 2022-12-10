namespace Day8;

public static class Program
{
    public static void Main()
    {
        var builder = new ForestBuilder();
        var forest = Enumerable.Range(0, int.MaxValue)
            .Select(_ => Console.ReadLine())
            .TakeWhile(l => l != null)
            .Select(builder.Append!)
            .Last()
            .Build();

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
}
