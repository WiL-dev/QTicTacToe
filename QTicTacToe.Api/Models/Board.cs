namespace QTicTacToe.Api.Models;

public class Board {
    private readonly string[] cubes = new string[3*3*3];

    public MoveOutput MakeMove(MoveInput move)
    {

        if(cubes[move.CubePos] is not null)
        {
            return new MoveOutput
            {
                isValid = false
            };
        }

        if (IsWinner(move))
        {
            return new MoveOutput {
                isValid = true,
                IsWinner = true
            };
        }

        return new MoveOutput
        {
            isValid = true
        };
    }

    private static bool IsWinner(MoveInput move)
    {
        return move.CubePos == 13;
    }
}