namespace ChessCLI;

public static class ChessUtils{

    public static (int, int) ParseCoords(string square) {
        int x = char.ToLower(square[0]) - 'a';
        int y = square[1] - '1';
        return (x, y);
    }

    public static PieceColour GetNextPlayer(PieceColour player) {
        
        return player switch {
            PieceColour.White => PieceColour.Black,
            PieceColour.Black => PieceColour.White,
            _=> PieceColour.White
        };
    }

    public static void RankInit(int rank, PieceColour colour, Piece?[,] board) {
        board[rank, 0] = new Rook(colour);
        board[rank, 7] = new Rook(colour);
        board[rank, 1] = new Knight(colour);
        board[rank, 6] = new Knight(colour);
        board[rank, 2] = new Bishop(colour);
        board[rank, 5] = new Bishop(colour);
        board[rank, 3] = new Queen(colour);
        board[rank, 4] = new King(colour);
        
    }
    
    //public Board(string fen) {
    //    board = new Piece?[8, 8];
    //    // parse the FEN string and initialize the board accordingly.
    //    // I'll do this later.
    // }

    // This method prints out the current board state.
    public static void DrawBoard(Piece?[,] board) {
        int termWidth = Console.WindowWidth;
        int boardWidth = board.GetLength(1) * 2;
        int padding = (termWidth - boardWidth) / 2;
        
        for (int row = 7; row >= 0; row--) {
            Console.Write(new string(' ', padding));
            Console.Write($"{row + 1} ");
            for (int col = 0; col < 8; col++) {
                switch (board[row, col]) {
                    case null:
                        Console.Write("0 ");
                        break;
                    default:
                        Console.Write($"{board[row, col]?.PieceSymbol} ");
                        break;
                }
            }
            Console.WriteLine();
        }
        Console.Write(new string(' ', padding));
        Console.WriteLine("  a b c d e f g h");
    }

    /* The next two methods on their own won't directly be used in the CLI
     * version. However, when I move on to making a GUI version, it will be
     * used, so it will be nice having these ahead of time.
     */

    // This method adds a piece at the specified position.
    public static void AddPiece(Piece?[,] board, Piece? piece, int x, int y) {
        board[y, x] = piece;
    }
    
    // This method removes a piece at the specified position.
    public static void RemovePiece(Piece?[,] board, int x, int y) {
        board[y, x] = null;
    }

    
    // This method moves a piece from one position to another.
    public static void MovePiece(Piece?[,] board, string originSquare, string destinationSquare) {
        var (x1, y1) = ParseCoords(originSquare);
        // With the origin square parsed, we can now get the piece to move.
        Piece? pieceToMove = board[y1, x1];

        var (x2, y2) = ParseCoords(destinationSquare);
        // Now we make use of the add and remove methods to move the piece.
        // The piece is first added to the destination square,
        // then removed from the origin square.
        AddPiece(board, pieceToMove, x2, y2);
        RemovePiece(board, x1, y1);
    }

    public static Piece? GetPiece(Piece?[,] board, string? checkSquare) {
        if (checkSquare == null)
            return null;
        var (x, y) = ChessUtils.ParseCoords(checkSquare);

        return board[y, x];
    }
}
