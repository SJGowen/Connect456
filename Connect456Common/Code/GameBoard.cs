namespace Connect456Common.Code;

public class GameBoard
{
    public GamePiece[,] Board { get; set; }

    public GameBoard(int cols, int rows)
    {
        Board = new GamePiece[cols, rows];
       
        //Populate the Board with blank pieces
        for(int col = 0; col < cols; col++)
        {
            for(int row = 0; row < rows; row++)
            {
                Board[col, row] = new GamePiece(PieceColor.Blank);
            }
        }
    }
}
