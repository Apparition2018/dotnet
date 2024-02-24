namespace dotnet.L.Demo;

public struct Coords
{
    public Coords() : this(double.NaN, double.NaN)
    {
    }

    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; init; }
    public double Y { get; init; }

    public override string ToString() => $"({X}, {Y})";
}
