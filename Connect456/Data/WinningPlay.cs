using System.Collections.Generic;

namespace Connect456.Data;

public class WinningPlay
{
    public List<string> WinningMoves { get; set; }
    public EvaluationDirection WinningDirection { get; set; }
    public PieceColor WinningColor { get; set; }
}
