namespace QTicTacToe.Api.Models;

public class MoveOutput
{
    public bool isValid { get; set; }
    public bool IsWinner { get; set; }
}