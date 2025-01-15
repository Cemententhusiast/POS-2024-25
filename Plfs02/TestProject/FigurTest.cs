using Aufgabe1;

namespace TestProject {
    public class FigurTest {
        [Fact]
        public void TestQuadratForValueBelow1()
        {
            Assert.Throws<Exception>(() => new QuadratA(0));
        }
        
        [Fact]
        public void TestQuadratForValueAbove1()
        {
            Assert.Equal(9, new QuadratA(3).Flaeche);
        }
        
        [Fact]
        public void TestQuadratToString()
        {
            Assert.Equal($"Flaeche: 9\nA: 3", new QuadratA(3).ToString());
        }
    }
}
