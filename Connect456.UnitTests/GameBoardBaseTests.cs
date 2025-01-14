using Bunit;
using Xunit;
using Connect456.Pages;
using Connect456.Data;

namespace Connect456.UnitTests;

public class GameBoardBaseTests : TestContext
{
    [Fact]
    public void GameBoardBase_InitializesCorrectly()
    {
        // Arrange
        var cols = 7;
        var rows = 6;
        var inARow = 4;

        // Act
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, cols)
            .Add(p => p.Rows, rows)
            .Add(p => p.InARow, inARow)
        );

        // Assert
        Assert.Equal(cols, cut.Instance.Cols);
        Assert.Equal(rows, cut.Instance.Rows);
        Assert.Equal(inARow, cut.Instance.InARow);
    }

    [Fact]
    public void PieceClicked_PlacesPieceCorrectly()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act - Pieces fall to bottom row which is empty
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0));

        // Assert
        var piece = cut.Instance.GetValidPiece(0, 5);
        Assert.Equal(PieceColor.Red, piece.Color);
    }

    [Fact]
    public void PieceClicked_SwitchesTurns()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act - Pieces fall to bottom row which is empty
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0));

        // Assert
        var piece1 = cut.Instance.GetValidPiece(0, 5);
        var piece2 = cut.Instance.GetValidPiece(1, 5);
        Assert.Equal(PieceColor.Red, piece1.Color);
        Assert.Equal(PieceColor.Yellow, piece2.Color);
    }

    [Fact]
    public void GetWinner_DetectsWinningPlay()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act - Pieces fall to bottom row which is empty
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0)); // Red piece at 0, 5
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0)); // Yellow piece at 1, 5
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0)); // Red piece at 0, 4
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0)); // Yellow piece at 1, 4
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0)); // Red piece at 0, 3
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0)); // Yellow piece at 1, 3
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0)); // Red piece at 0, 2

        // Assert
        var winner = cut.Instance.GetWinner(0, 2);
        Assert.NotNull(winner);
        Assert.Equal(PieceColor.Red, winner.WinningColor);
    }
}
