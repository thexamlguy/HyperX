namespace HyperX.Widgets;

public class Widget
{
    public Dictionary<string, object> Arguments { get; set; } = [];

    public int Column { get; set; }

    public int ColumnSpan { get; set; }

    public required string Component { get; set; }

    public required string Name { get; set; }

    public int Row { get; set; }

    public int RowSpan { get; set; }
}