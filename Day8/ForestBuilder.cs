namespace Day8;

public class ForestBuilder
{
    private readonly List<List<int>> _matrix;

    public ForestBuilder()
    {
        _matrix = new List<List<int>>();
    }

    public ForestBuilder Append(string line)
    {
        if (_matrix.Count != 0 && _matrix[0]
                .Count != line.Length)
        {
            throw new ArgumentException("The line length must be equal to the forest width.", nameof(line));
        }

        var list = line.Select(c => c - '0')
            .ToList();
        _matrix.Add(list);

        return this;
    }

    public Forest Build()
    {
        return new Forest(_matrix);
    }
}
