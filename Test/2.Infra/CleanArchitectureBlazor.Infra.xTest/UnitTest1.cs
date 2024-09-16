namespace CleanArchitectureBlazor.Infra.xTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //  Arrange
            int a = 1;
            int b = 2;
            //  Act
            int c = a+b;
            //  Assert
            Assert.Equal(3, c);
        }
    }
}