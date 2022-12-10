namespace Day8;

public record Tree(int X, int Y, int Height)
{
    public IEnumerable<Tree> DirectionTrees(Direction direction, Forest forest)
    {
        var isRow = direction is Left or Right;
        var afterIndex = direction is Right or Below;

        var trees = isRow ? forest.GetRow(Y) : forest.GetColumn(X);
        var index = trees.IndexOf(this);

        return afterIndex ? trees.Skip(index + 1) : trees.Take(index);
    }

    public bool TallerThanAll(IEnumerable<Tree> trees)
    {
        return trees.All(t => t.Height < Height);
    }
}
