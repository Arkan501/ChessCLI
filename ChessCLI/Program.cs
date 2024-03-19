// Arkan501
// This is my attempt at creating a chess game in C# in the terminal.

namespace ChessCLI;

public class Program {
    public static void Main(string[] args) {
        //                Piece Placement / Active Colour / Castling Rights / En Passant Target Square / Halfmove Clock / Fullmove Number
        // string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        int roundNumber = 0;
        PieceColour currentPlayer = 0;      // This is allowed for some reason.
        Board chessBoard = new Board();

        RunGame(chessBoard, roundNumber, currentPlayer);
    }

    // This is the loop that runs the game.
    private static void RunGame(Board board, int roundNumber, PieceColour player) {
        do {
            Console.Clear();
            Console.WriteLine("\tChessCLI");
            player = GetNextPlayer(player);
            board.PrintBoard();
            
            Console.WriteLine($"\t{player} to move");
                
            if (roundNumber == 50) {
                Console.WriteLine("Draw by 50 move rule");
                return;
            }
            board = PlayerMove(board, player);
            roundNumber++;
        }
        while(true);        // This will be changed to something more appropriate later.
    }
    
    private static Board PlayerMove(Board board, PieceColour player) {
        string? pieceToMove;
        string? moveToMake;

        Console.WriteLine("Choose a piece to move");
        pieceToMove = Console.ReadLine();

        Console.WriteLine("Choose where to move the piece to");
        moveToMake = Console.ReadLine();

        if (pieceToMove != null && moveToMake != null)
            board.MovePiece(pieceToMove, moveToMake);
        board.PrintBoard();

           return board;
    }

    private static PieceColour GetNextPlayer(PieceColour player) {
        if (player == PieceColour.White)
            return PieceColour.Black;
        return PieceColour.White;
    }
}
