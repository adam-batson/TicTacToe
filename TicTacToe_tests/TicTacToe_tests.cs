using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToe_tests
{
    [TestClass]
    public class TicTacToe_tests
    {
        [DataTestMethod]
        [DataRow('X', DisplayName = "When X is entered")]
        [DataRow('O', DisplayName = "When O is entered")]
        public void Grid_AddToGrid_InputXorO_GridIndexChangesToInput(char shape)
        {
            // Arrange
            Player p = new();
            p.ChangeShape(shape);
            
            Grid sut = new();
            var expected = p.Shape;

            // Act
            sut.AddToGrid(p, 1); // 1 is the cell number
            var actual = sut.Moves[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
