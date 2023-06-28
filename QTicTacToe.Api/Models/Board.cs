namespace QTicTacToe.Api.Models;

public class Board {

    // private readonly string[] cubes = new string[3*3*3];
    private readonly string[] grid = new string[3*3];

    private static readonly int[][] lines = new int[8][]{
        new int[3] {0, 1, 2},
        new int[3] {3, 4, 5},
        new int[3] {6, 7, 8},
        new int[3] {0, 3, 6},
        new int[3] {1, 4, 7},
        new int[3] {2, 5, 8},
        new int[3] {0, 4, 8},
        new int[3] {2, 4, 6}
    };

    public MoveOutput MakeMove(MoveInput move)
    {
        int cubePos = move.CubePos;

        if(grid[cubePos] is not null)
        {
            return new MoveOutput
            {
                isValid = false
            };
        }

        grid[cubePos] = move.Mark;

        MoveOutput moveOutput = new MoveOutput
        {
            isValid = true
        };

        if (IsWinner(move))
        {
            moveOutput.IsWinner = true;
        }

        return moveOutput;
    }

    private bool IsWinner(MoveInput move)
    {
        IEnumerable<int[]> filteredLines = from line in lines
            where line.Contains(move.CubePos)
            select line;

        foreach (int[] line in filteredLines)
        {
            if (line.All(cubePos => grid[cubePos] == move.Mark))
            {
                Console.WriteLine("WIN");
                return true;
            }
        }

        Console.WriteLine(string.Join(" - ", grid));

        return false;
    }
}