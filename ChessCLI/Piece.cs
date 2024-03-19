// This is where all the pieces are created
namespace ChessCLI;

// set to abstract so we never accidentally create a generic piece.
public abstract class Piece {
    public PieceColour Colour { get; set; }

    public string? PieceName { get; set; }

    public char? PieceSymbol { get; set; }

    // This is the string representation of the piece. Used for debugging.
    public string toString() {
        return $"{Colour} {PieceName}";
    }
}

// the following classes are the pieces
class Pawn : Piece {
    public Pawn(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Pawn";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♟';
        }
        else {
            base.PieceSymbol = '♙';
        }
    }
}

class Knight : Piece {
    public Knight(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Knight";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♞';
        }
        else {
            base.PieceSymbol = '♘';
        }
    }
}

class Bishop : Piece {
    public Bishop(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Bishop";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♝';
        }
        else {
            base.PieceSymbol = '♗';
        }
    }
}

class Rook : Piece {
    public Rook(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Rook";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♜';
        }
        else {
            base.PieceSymbol = '♖';
        }
    }
}

class Queen : Piece {
    public Queen(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "Queen";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♛';
        }
        else {
            base.PieceSymbol = '♕';
        }
    }
}

class King : Piece {
    public King(PieceColour colour) {
        base.Colour = colour;
        base.PieceName = "King";

        if (colour == PieceColour.White) {
            base.PieceSymbol = '♚';
        }
        else {
            base.PieceSymbol = '♔';
        }
    }
}
