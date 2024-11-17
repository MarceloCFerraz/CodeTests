using Exercicios.Implements;
using Xunit;

namespace Exercicios.Tests;

public class Q1Test
{
    [Fact]
    public void TestFirstQuestion()
    {
        var q = new ECondicionaisQ1();
        var result = q.TestCode();
        var expected = 0;

        Assert.Equal(expected, result);
    }
}