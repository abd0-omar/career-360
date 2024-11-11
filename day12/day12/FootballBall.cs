class FootballBall
{
    public int Id { get; set; }
    public string BallName { get; set; } = "Adidas";
    private Location location;
    public Location Location
    {
        get { return location; }
        set
        {
            if (value != location)
            {

                // fire event
                location = value;
                BallLocationChanged(location);
            }
            location = value;
        }
    }

    public event Action<Location> BallLocationChanged = delegate { };
}