public class Team
{
    public string Name { get; private set; }
    public bool IsHome { get; set; }
    public bool IsAway { get; set; }

    public virtual int ScoreStart { get; set; }
    public virtual int ScoreEnd { get; set; }
    public Team(string name)
    {
        Name = name;
        IsHome = false;
        IsAway = false;
    }
}
