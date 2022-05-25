namespace Robots.Core;

public class Robot
{
    public string Execute(string command)
    {
        var direction = command.ToCharArray()
            .Aggregate(Direction.Default, (current, directionCommand) => directionCommand switch
            {
                'R' => current.RotateRight(),
                'L' => current.RotateLeft(),
                _ => current
            });

        return $"0:0:{direction.GetValue()}";
    }
}