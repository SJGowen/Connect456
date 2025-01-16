using Bunit;
using Connect456.Pages;

namespace Connect456.UnitTests;

public class ConnectSixTests : TestContext
{
    [Fact]
    public void ConnectSix_RendersCorrectly()
    {
        // Act
        var cut = RenderComponent<ConnectSix>();

        // Assert
        cut.MarkupMatches(@"
<h1>Connect Six</h1>
<h2>Red's Turn!</h2>
<div class=""board"" style=""background-color: blue; display: flex; flex-direction: row; max-width: fit-content"">
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
  <div class=""column"">
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
    <div class=""gamepiece blank""  style=""""></div>
  </div>
</div>");
    }
}

