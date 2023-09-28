public class VideoGame : IComparable<VideoGame>
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Platform { get; set; }
    public string Publisher {get; set;}

    public override string ToString()
    {
        return $"The game is {Title}, in the style {Genre}, on the {Platform} platform, and the publisher is {Publisher}";
    }

    public int CompareTo(VideoGame other)
    {
        // Compare by the Title property in ascending order
        return string.Compare(this.Title, other.Title, StringComparison.Ordinal);
    }
}