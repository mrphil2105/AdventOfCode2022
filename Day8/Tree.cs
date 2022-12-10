namespace Day8;

public record Tree(int X, int Y, int Height)
{
    public IEnumerable<Tree> Left(Forest forest)
    {
        var row = forest.GetRow(Y);
        var index = row.IndexOf(this);

        return row.Take(index);
    }

    public IEnumerable<Tree> Right(Forest forest)
    {
        var row = forest.GetRow(Y);
        var index = row.IndexOf(this);

        return row.Skip(index + 1);
    }

    public IEnumerable<Tree> Above(Forest forest)
    {
        var column = forest.GetColumn(X);
        var index = column.IndexOf(this);

        return column.Take(index);
    }

    public IEnumerable<Tree> Below(Forest forest)
    {
        var column = forest.GetColumn(X);
        var index = column.IndexOf(this);

        return column.Skip(index + 1);
    }

    public bool TallerThanAll(IEnumerable<Tree> trees)
    {
        return trees.All(t => t.Height < Height);
    }
}
