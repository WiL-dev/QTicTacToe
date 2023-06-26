namespace QTicTacToe.Api.Models;

public class MoveInput
{
    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }

    public override string ToString()
    {
        return $"x: {x} - y: {y} - z: {z}";
    }
}