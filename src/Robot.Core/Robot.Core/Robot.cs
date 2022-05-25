namespace Robots.Core;

public class Robot
{
    private string _direction = "N";

    public string Execute(string command)
    {
        var commands = new Stack<char>(command.ToCharArray());

        while (commands.Count > 0)
        {
            char orientation = commands.Pop();

            _direction = orientation switch
            {
                'R' => RotateRight(),
                'L' => RotateLeft(),
                _ => _direction
            };
        }

        return $"0:0:{_direction}";
    }

    private string RotateLeft()
    {
        return _direction switch
        {
            "N" => "W",
            "W" => "S",
            "S" => "E",
            "E" => "N",
            _ => "N"
        };
    }

    private string RotateRight()
    {
        return _direction switch
        {
            "N" => "E",
            "E" => "S",
            "S" => "W",
            "W" => "N",
            _ => "N"
        };
    }
}