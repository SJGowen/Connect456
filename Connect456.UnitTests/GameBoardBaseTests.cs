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
    public void GetWinner_DetectsVerticalWin()
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

    [Fact]
    public void GetWinner_DetectsHorizontalWin()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0)); // Red
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 1)); // Yellow
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0)); // Red
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 1)); // Yellow
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0)); // Red
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 1)); // Yellow
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0)); // Red

        // Assert
        var winner = cut.Instance.GetWinner(3, 5);
        Assert.NotNull(winner);
        Assert.Equal(PieceColor.Red, winner.WinningColor);
    }

    [Fact]
    public void GetWinner_DetectSlopeUpWin()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act - Pieces fall to bottom row which is empty
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(5, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));

        // Assert
        var winner = cut.Instance.GetWinner(4, 2);
        Assert.NotNull(winner);
        Assert.Equal(PieceColor.Red, winner.WinningColor);
    }

    [Fact]
    public void GetWinner_DetectSlopeDownWin()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act - Pieces fall to bottom row which is empty
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(5, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(4, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(3, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(1, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));
        cut.InvokeAsync(() => cut.Instance.PieceClicked(2, 0));

        // Assert
        var winner = cut.Instance.GetWinner(2, 2);
        Assert.NotNull(winner);
        Assert.Equal(PieceColor.Yellow, winner.WinningColor);
    }

    [Fact]
    public async Task PieceClicked_HandlesInvalidColumn()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => cut.InvokeAsync(() => cut.Instance.PieceClicked(-1, 0)));
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => cut.InvokeAsync(() => cut.Instance.PieceClicked(7, 0)));
    }

    [Fact]
    public async Task PieceClicked_HandlesInvalidRow()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => cut.InvokeAsync(() => cut.Instance.PieceClicked(0, -1)));
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 6)));
    }

    [Fact]
    public void Reset_MakesAllPiecesBlank()
    {
        // Arrange
        var cut = RenderComponent<GameBoardBase>(parameters => parameters
            .Add(p => p.Cols, 7)
            .Add(p => p.Rows, 6)
            .Add(p => p.InARow, 4)
        );

        // Act
        cut.InvokeAsync(() => cut.Instance.PieceClicked(0, 0));
        Assert.Equal(PieceColor.Red, cut.Instance.GetValidPiece(0, 5).Color);
        cut.InvokeAsync(() => cut.Instance.Reset());

        // Assert
        var piece = cut.Instance.GetValidPiece(0, 5);
        Assert.Equal(PieceColor.Blank, piece.Color);
    }
}
