namespace ChessCLI;

public class Board { 
    private readonly Piece?[,] _board;

    // This constructor will initialize the board in starting position
    public Board() {
        /* I want to eventually initialize the starting position using FEN notation.
         * It's fine as is for now, but when I turn it into a GUI, using FEN will
         * make a lot of the planned features easier to implement
         */

        // creates an 8x8 empty matrix.
        // This is where the pieces will be placed.
        _board = new Piece?[8, 8];

        // This fills the 2nd and 7th rank with pawns.
        for (int i = 0; i < 8; i++) {
            _board[1, i] = new Pawn(PieceColour.White);
            _board[6, i] = new Pawn(PieceColour.Black);
        }

        // Filling out the 1st and 8th rank with the rest of the pieces.
                    /* White pieces */
        RankInit(0, PieceColour.White, _board);
        RankInit(7, PieceColour.Black, _board);
    }

    private void RankInit(int rank, PieceColour colour, Piece?[,] board) {
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
    //    _board = new Piece?[8, 8];
    //    // parse the FEN string and initialize the board accordingly.
    //    // I'll do this later.
    // }

    // This method prints out the current board state.
    public void DrawBoard() {
        int termWidth = Console.WindowWidth;
        int boardWidth = _board.GetLength(1) * 2;
        int padding = (termWidth - boardWidth) / 2;
        
        for (int row = 7; row >= 0; row--) {
            Console.Write(new string(' ', padding));
            Console.Write($"{row + 1} ");
            for (int col = 0; col < 8; col++) {
                switch (_board[row, col]) {
                    case null:
                        Console.Write("0 ");
                        break;
                    default:
                        Console.Write($"{_board[row, col]?.PieceSymbol} ");
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
    private void AddPiece(Piece? piece, int x, int y) {
        _board[y, x] = piece;
    }
    
    // This method removes a piece at the specified position.
    private void RemovePiece(int x, int y) {
        _board[y, x] = null;
    }

    private (int, int) ParseCoords(string square) {
        int x = char.ToLower(square[0]) - 'a';
        int y = square[1] - '1';
        return (x, y);
    }
    
    // This method moves a piece from one position to another.
    public void MovePiece(string originSquare, string destinationSquare) {
        var (x1, y1) = ParseCoords(originSquare);
        // With the origin square parsed, we can now get the piece to move.
        Piece? pieceToMove = _board[y1, x1];

        var (x2, y2) = ParseCoords(destinationSquare);
        // Now we make use of the add and remove methods to move the piece.
        // The piece is first added to the destination square,
        // then removed from the origin square.
        AddPiece(pieceToMove, x2, y2);
        RemovePiece(x1, y1);
    }

    public Piece? GetPiece(string? checkSquare) {
        if (checkSquare == null)
            return null;
        
        var (x, y) = ParseCoords(checkSquare);

        return _board[y, x];
    }
}
