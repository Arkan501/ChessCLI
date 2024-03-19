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
        _board[0, 0] = new Rook(PieceColour.White);
        _board[0, 7] = new Rook(PieceColour.White);
        _board[0, 1] = new Knight(PieceColour.White);
        _board[0, 6] = new Knight(PieceColour.White);
        _board[0, 2] = new Bishop(PieceColour.White);
        _board[0, 5] = new Bishop(PieceColour.White);
        _board[0, 3] = new Queen(PieceColour.White);
        _board[0, 4] = new King(PieceColour.White);

                    /* Black pieces */
        _board[7, 0] = new Rook(PieceColour.Black);
        _board[7, 7] = new Rook(PieceColour.Black);
        _board[7, 1] = new Knight(PieceColour.Black);
        _board[7, 6] = new Knight(PieceColour.Black);
        _board[7, 2] = new Bishop(PieceColour.Black);
        _board[7, 5] = new Bishop(PieceColour.Black);
        _board[7, 3] = new Queen(PieceColour.Black);
        _board[7, 4] = new King(PieceColour.Black);
    }

    // This method prints out the current board state.
    public void PrintBoard() {
        int termWidth = Console.WindowWidth;
        int boardWidth = _board.GetLength(1) * 2;
        int padding = (termWidth - boardWidth) / 2;
        
        for (int row = 7; row >= 0; row--) {
            Console.Write(new string(' ', padding));
            Console.Write($"{row + 1} ");
            for (int col = 0; col < 8; col++) {
                if (_board[row, col] == null) {
                    Console.Write("0 ");
                }
                else {
                    Console.Write($"{_board[row, col]?.PieceSymbol} ");
                }
            }
            Console.WriteLine();
        }
        Console.Write(new string(' ', padding));
        Console.WriteLine("  a b c d e f g h");
    }

    /* The next two methods on their own won't directly be used in the CLI
     * version. However, when I move on ta making a GUI version, it will be
     * used, so it will be nice having these ahead of time.
     */

    // This method adds a piece at the specified position.
    public void AddPiece(Piece? piece, int x, int y) {
        _board[y, x] = piece;
    }
    
    // This method removes a piece at the specified position.
    public void RemovePiece(int x, int y) {
        _board[y, x] = null;
    }

    // This method moves a piece from one position to another.
    public void MovePiece(string originSquare, string destinationSquare) {
        // This is apparently how to do this.
        int x1 = char.ToLower(originSquare[0]) - 'a';
        int y1 = originSquare[1] - '1';

        // With the origin square parsed, we can now get the piece to move.
        Piece? pieceToMove = _board[y1, x1];

        int x2 = char.ToLower(destinationSquare[0]) - 'a';
        int y2 = destinationSquare[1] - '1';

        // Now we make use of the add and remove methods to move the piece.
        // The piece is first added to the destination square,
        // then removed from the origin square.
        AddPiece(pieceToMove, x2, y2);
        RemovePiece(x1, y1);
    }
}
