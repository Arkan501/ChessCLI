// This is where all the pieces are created
namespace ChessCLI;

// set to abstract so we never accidentally create a generic piece.
public abstract class Piece {
    private PieceColour _colour;
    private string? _pieceName;
    private char? _symbol;

    // This is the colour of the piece
    public PieceColour Colour {
        get => _colour;
        set => _colour = value;
    }

    // This is the name of the piece
    public string? PieceName {
        get => _pieceName;
        set => _pieceName = value;
    }

    // This is the symbol of the piece used in the terminal.
    public char? Symbol {
        get => _symbol;
        set => _symbol = value;
    }

    // This is the string representation of the piece. Used for debugging.
    public string toString() {
        return $"{_colour} {_pieceName}";
    }
}
// the following classes are the pieces
class Pawn : Piece {
    public Pawn(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Pawn";

        if (colour == PieceColour.White) {
            base.Symbol = '♟';
        }
        else {
            base.Symbol = '♙';
        }
    }
}

class Knight : Piece {
    public Knight(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Knight";

        if (colour == PieceColour.White) {
            base.Symbol = '♞';
        }
        else {
            base.Symbol = '♘';
        }
    }
}

class Bishop : Piece {
    public Bishop(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Bishop";

        if (colour == PieceColour.White) {
            base.Symbol = '♝';
        }
        else {
            base.Symbol = '♗';
        }
    }
}

class Rook : Piece {
    public Rook(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Rook";

        if (colour == PieceColour.White) {
            base.Symbol = '♜';
        }
        else {
            base.Symbol = '♖';
        }
    }
}

class Queen : Piece {
    public Queen(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Queen";

        if (colour == PieceColour.White) {
            base.Symbol = '♛';
        }
        else {
            base.Symbol = '♕';
        }
    }
}

class King : Piece {
    public King(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "King";

        if (colour == PieceColour.White) {
            base.Symbol = '♚';
        }
        else {
            base.Symbol = '♔';
        }
    }
}
