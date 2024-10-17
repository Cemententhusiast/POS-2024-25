using System;
using System.IO.Pipes;
using System.Runtime.InteropServices.JavaScript;
using Angabe01_2;
using Xunit;

namespace SimpleStackTest;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(10, 10)]
    public void TestSimpleStackValues(int a, int expected)
    {
        SimpleStack stack = new SimpleStack(a);
        int result = stack.GetSize();
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void TestSimpleStackError()
    {
        Assert.Throws<ArgumentException>(() => new SimpleStack(0));
    }

    [Fact]
    public void TestPushPopTop()
    {
        SimpleStack stack = new SimpleStack(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.Equal(2, stack.GetTopIndex());
        Assert.Throws<IndexOutOfRangeException>(() => stack.Push(4));
        
        SimpleStack stack2 = new SimpleStack(3);
        stack2.Push(4);
        object poppedVar = stack2.Pop();
        Assert.Equal(4, poppedVar);
        Assert.Throws<IndexOutOfRangeException>(() => stack2.Pop());
        
        SimpleStack stack3 = new SimpleStack(3);
        Assert.Throws<IndexOutOfRangeException>(() => stack3.Top());
        stack3.Push(5);
        Assert.Equal(5, stack3.Top());
    }
    
    [Theory]
    [InlineData("()", -1)]
    [InlineData("(()", 0)]
    [InlineData("())", -2)]
    public void TestEvalBrackets(string a, int expected)
    {
        int result = SimpleStack.EvalBrackets(a);
        Assert.Equal(expected, result);
    }
    
    
}