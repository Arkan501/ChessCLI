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
        ChessUtils.RankInit(0, PieceColour.White, _board);
        ChessUtils.RankInit(7, PieceColour.Black, _board);
    }

    public Piece?[,] BoardState => _board;

}
