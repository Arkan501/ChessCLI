// Arkan501
// This is my attempt at creating a chess game in C# in the terminal.

namespace ChessCLI;

public class Program {
    public static void Main(string[] args) {
        //                Piece Placement / Active Colour / Castling Rights / En Passant Target Square / Halfmove Clock / Fullmove Number
        // string FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        // may be eaier to implement with bitboard.
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
            board.DrawBoard();
            
            Console.WriteLine($"\t{player} to move");
                
            if (roundNumber == 50) {
                Console.WriteLine("Draw by 50 move rule");
                return;
            }
            board = PlayerMove(board, player);
            
            roundNumber++;
        } while(roundNumber != 50);        // This will be changed to something more appropriate later.
    }
    
    private static Board PlayerMove(Board board, PieceColour player) {
        string? pieceToMove;
        string? moveToMake;
        bool isPiecePresent = false;
        bool isSquareValid = false;

        do {
            Console.WriteLine("Choose a piece to move");
            pieceToMove = Console.ReadLine();
            // check if the player actually wrote something
            if (pieceToMove == null) {
                Console.WriteLine("a square must be defined");
                continue;
            }

            // create a temporary piece for checks
            Piece? tempPiece = board.GetPiece(pieceToMove);
            // check if the piece exists
            if (tempPiece == null) {
                Console.WriteLine("There is no piece at this square");
                continue;
            }

            // check if the piece belongs to the player
            if (tempPiece.Colour != player) {
                Console.WriteLine("This piece does not belong to you");
                continue;
            }

            isPiecePresent = true;
        } while (!isPiecePresent);

        do {
            Console.WriteLine("Choose where to move the piece to");
            moveToMake = Console.ReadLine();
            
            if (moveToMake == null) {
                Console.WriteLine("You need choose a square to move the piece to");
                continue;
            }
            
            Piece? tempPiece = board.GetPiece(moveToMake);
            // check if new square contains a piece. Will mess with this later to
            // account for captures. For now, it won't be allowed
            if (tempPiece != null) {
                Console.WriteLine("There is a piece in the way");
                continue;
            }

            isSquareValid = true;
        } while (!isSquareValid);

        if (pieceToMove != null && moveToMake != null)
            board.MovePiece(pieceToMove, moveToMake);

        return board;
    }

    private static PieceColour GetNextPlayer(PieceColour player) {
        
        return player switch {
            PieceColour.White => PieceColour.Black,
            PieceColour.Black => PieceColour.White,
            _=> PieceColour.White
        };
    }
}
