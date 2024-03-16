// Arkan501
// This is my attempt at creating a chess game in C# in the terminal.
namespace ChessCLI;

class Program {
    public static void Main(string[] args) {
        Board board = new Board();
        board.PrintBoard();
    }
}
