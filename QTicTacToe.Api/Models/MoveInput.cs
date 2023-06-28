namespace QTicTacToe.Api.Models;

public class MoveInput
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public required string Mark { get; set; }

    public int CubePos => (X + Y*3 + Z*9);

    public override string ToString()
    {
        return $"x: {X} - y: {Y} - z: {Z}";
    }
}