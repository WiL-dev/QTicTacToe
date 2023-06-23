namespace QTicTacToe.Api.Models;

public class MoveOutput
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public bool IsWinner { get; set; }
}