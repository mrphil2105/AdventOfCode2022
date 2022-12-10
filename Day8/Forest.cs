namespace Day8;

public class Forest
{
    private readonly List<List<int>> _matrix;

    public Forest(List<List<int>> matrix)
    {
        _matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
    }

    public int Width => _matrix.Count != 0
        ? _matrix[0]
            .Count
        : 0;

    public int Height => _matrix.Count;

    public Tree GetTree(int x, int y)
    {
        var height = _matrix[y][x];

        return new Tree(x, y, height);
    }

    public List<Tree> GetRow(int y)
    {
        return _matrix[y]
            .Select((h, x) => new Tree(x, y, h))
            .ToList();
    }

    public List<Tree> GetColumn(int x)
    {
        return _matrix.Select(t => t[x])
            .Select((h, y) => new Tree(x, y, h))
            .ToList();
    }
}
