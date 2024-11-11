public struct Location
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override string ToString()
    {
        return $"ball location: ({X}, {Y}, {Z})";
    }

    public override bool Equals(object? obj)
    {
        return obj is Location location &&
               X == location.X &&
               Y == location.Y &&
               Z == location.Z;
    }

    public static bool operator ==(Location left, Location right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Location left, Location right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
