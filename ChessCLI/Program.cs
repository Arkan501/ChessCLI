// Arkan501
// This is my attempt at creating a chess game in C# in the terminal.
namespace ChessCLI;

public class Program {
    public static void Main(string[] args) {
        //                Piece Placement / Active Colour / Castling Rights / En Passant Target Square / Halfmove Clock / Fullmove Number
        // string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        int roundNumber = 0;
        string player = "white";
        Board chessBoard = new Board();

        RunGame(chessBoard, roundNumber, player);
    }

    // This is the loop that runs the game.
    public static void RunGame(Board board, int roundNumber, string player) {
        do {
            // Console.Clear();
            Console.WriteLine("\tChessCLI");
            board.PrintBoard();
            if (roundNumber == 50) {
                Console.WriteLine("Draw by 50 move rule");
                return;
            }
            board = PlayerMove(board, player);
            roundNumber++;
        }
        while(true);        // This will be changed to something more appropriate later.
    }
    public static Board PlayerMove(Board board, string player) {
        string? pieceToMove;
        string? moveToMake;
        /* rename this array to something more appropriate */

        Console.WriteLine($"\t{player} to move");

        Console.WriteLine("Choose a piece to move");
        pieceToMove = Console.ReadLine();

        Console.WriteLine("Choose where to move the piece to");
        moveToMake = Console.ReadLine();

           board.MovePiece(pieceToMove, moveToMake);
           board.PrintBoard();

           return board;
    }
}
