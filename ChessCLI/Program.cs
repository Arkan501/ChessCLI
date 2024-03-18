// Arkan501
// This is my attempt at creating a chess game in C# in the terminal.
namespace ChessCLI;

class Program {
    public static void Main(string[] args) {
        int roundNumber = 0;
        string player = "white";
        Board board = new Board();

        RunGame(board, roundNumber, player);
    }

    public static void RunGame(Board board, int roundNumber, string player) {
        do {
            // Console.Clear();
            Console.WriteLine("\tChessCLI");
            board.PrintBoard();
            if (roundNumber == 30) {
                Console.WriteLine("Draw by 30 move rule");
                return;
            }
            PlayerMove(player);
            roundNumber++;
        }
        while(roundNumber != 3);        // This will be changed to something more appropriate later.
                                        // Console.WriteLine(roundNumber);
    }

    public static string?[] PlayerMove(string player) {
        string? pieceToMove;
        string? moveToMake;
        string?[] foo = new string[2];

        Console.WriteLine($"\t{player} to move");

        Console.WriteLine("Choose a piece to move");
        pieceToMove = Console.ReadLine();
        foo[0] = pieceToMove;

        Console.WriteLine("Choose where to move the piece to");
        moveToMake = Console.ReadLine();
        foo[1] = moveToMake;

        return foo;
    }
}
