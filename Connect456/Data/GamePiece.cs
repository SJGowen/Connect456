namespace Connect456.Data;

public class GamePiece
{
    public PieceColor Color;

    public GamePiece()
    {
        Color = PieceColor.Blank;
    }

    public GamePiece(PieceColor color)
    {
        Color = color;
    }
}
