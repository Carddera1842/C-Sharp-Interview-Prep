using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace ConsoleCalculator.Test.MSTest;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void ThrowWhenUnsupportedOperation()
    {
        var sut = new Calculator();

        //Assert.ThrowsException<CalculationOperationNotSupportedException>
        //    (() => sut.Calculate(1, 1, "+"));

        var ex = Assert.ThrowsException<CalculationOperationNotSupportedException>
            (() => sut.Calculate(1, 1, "+"));

        Assert.AreEqual("+", ex.Operation);
    }
}
