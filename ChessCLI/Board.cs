namespace ChessCLI;

public class Board {
    private Piece?[,] _board;

    // This constructor will initialize the board in starting position
    public Board() {
        // creates an 8x8 empty matrix.
        // This is where the pieces will be placed.
        _board = new Piece?[8, 8];

        // This fills the 2nd and 7th rank with pawns.
        for (int i = 0; i < 8; i++) {
            _board[6, i] = new Pawn(PieceColour.White);
            _board[1, i] = new Pawn(PieceColour.Black);
        }

        // Filling out the 1st and 8th rank with the rest of the pieces.
                    /* White pieces */
        _board[7, 0] = new Rook(PieceColour.White);
        _board[7, 7] = new Rook(PieceColour.White);
        _board[7, 1] = new Knight(PieceColour.White);
        _board[7, 6] = new Knight(PieceColour.White);
        _board[7, 2] = new Bishop(PieceColour.White);
        _board[7, 5] = new Bishop(PieceColour.White);
        _board[7, 3] = new Queen(PieceColour.White);
        _board[7, 4] = new King(PieceColour.White);

                    /* Black pieces */
        _board[0, 0] = new Rook(PieceColour.Black);
        _board[0, 7] = new Rook(PieceColour.Black);
        _board[0, 1] = new Knight(PieceColour.Black);
        _board[0, 6] = new Knight(PieceColour.Black);
        _board[0, 2] = new Bishop(PieceColour.Black);
        _board[0, 5] = new Bishop(PieceColour.Black);
        _board[0, 3] = new Queen(PieceColour.Black);
        _board[0, 4] = new King(PieceColour.Black);
    }

    // This method prints out the current board state.
    public void PrintBoard() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (_board[i, j] == null) {
                    Console.Write("0 ");
                }
                else {
                    Console.Write(_board[i, j]?.Symbol + " ");
                }
            }
            Console.WriteLine();
        }

    }

    // This method adds a piece at the specified position.
    public void AddPiece(Piece piece, int x, int y) {
        _board[x, y] = piece;
    }

    // This method removes a piece at the specified position.
    public void RemovePiece(int x, int y) {
        _board[x, y] = null;
    }
}
