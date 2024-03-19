// This is where all the pieces are created
namespace ChessCLI;

// set to abstract, so we never accidentally create a generic piece.
public abstract class Piece {
    protected PieceColour Colour { get; init; }

    protected string? PieceName { get; init; }

    public char? PieceSymbol { get; protected init; }

    // This is the string representation of the piece. Used for debugging.
    public override string ToString() {
        return $"{Colour} {PieceName}";
    }
}

// the following classes are the pieces
class Pawn : Piece {
    public Pawn(PieceColour colour) {
        Colour = colour;
        PieceName = "Pawn";

        if (colour == PieceColour.White) {
            PieceSymbol = '♟';
        }
        else {
            PieceSymbol = '♙';
        }
    }
}

class Knight : Piece {
    public Knight(PieceColour colour) {
        Colour = colour;
        PieceName = "Knight";

        if (colour == PieceColour.White) {
            PieceSymbol = '♞';
        }
        else {
            PieceSymbol = '♘';
        }
    }
}

class Bishop : Piece {
    public Bishop(PieceColour colour) {
        Colour = colour;
        PieceName = "Bishop";

        if (colour == PieceColour.White) {
            PieceSymbol = '♝';
        }
        else {
            PieceSymbol = '♗';
        }
    }
}

class Rook : Piece {
    public Rook(PieceColour colour) {
        Colour = colour;
        PieceName = "Rook";

        if (colour == PieceColour.White) {
            PieceSymbol = '♜';
        }
        else {
            PieceSymbol = '♖';
        }
    }
}

class Queen : Piece {
    public Queen(PieceColour colour) {
        Colour = colour;
        PieceName = "Queen";

        if (colour == PieceColour.White) {
            PieceSymbol = '♛';
        }
        else {
            PieceSymbol = '♕';
        }
    }
}

class King : Piece {
    public King(PieceColour colour) {
        Colour = colour;
        PieceName = "King";

        if (colour == PieceColour.White) {
            PieceSymbol = '♚';
        }
        else {
            PieceSymbol = '♔';
        }
    }
}
