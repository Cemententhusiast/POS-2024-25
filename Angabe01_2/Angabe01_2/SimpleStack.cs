using System;

namespace Angabe01_2;

public class SimpleStack
{
    private object[] _values;
    private int topIndex;

    public SimpleStack(int size)
    {
        if (size<1)
        {
            throw new ArgumentException("Stack size must be higher than 1");
        }
        _values = new object[size];
        topIndex = -1;
    }

    public void Push(object x)
    {
        try
        {
            topIndex++;
            _values[topIndex] = x;
        }
        catch (IndexOutOfRangeException iex)
        {
            Console.WriteLine(iex.Message);
            throw;
        }
    }

    public object Pop() //ich entscheide mich hier das Element nicht zu löschen, da es eigentlich in dem Fall eine unnötige Operation ist
    {
        if (topIndex<0)
        {
            throw new IndexOutOfRangeException("Stack is empty");
        }
        topIndex--;
        return _values[topIndex+1];
    }

    public object Top()
    {
        if (topIndex<0)
        {
            throw new IndexOutOfRangeException("Stack is empty");
        }
        return _values[topIndex];
    }

    public static int EvalBrackets(string input)
    {
        if (input.Equals(null)||input.Equals(""))
        {
            Console.Write("Ihre Eingabe: ");
            input = Console.ReadLine();
            
            if (input is null || input.Length == 0)
            {
                throw new IndexOutOfRangeException("Empty input");
            }
        }
        
        SimpleStack stack = new SimpleStack(input.Length);
        foreach (char c in input)
        {
            if (c.Equals('('))
            {
                stack.Push(c);
            }
            else if (c.Equals(')'))
            {
                if (stack.topIndex>=0)
                {
                    stack.Pop();
                }
                else
                {
                    stack.topIndex = -2;
                    break;
                }
            }
        }

        if (stack.topIndex==-1)
        {
            Console.WriteLine("All brackets closed, success!");
        }
        else if (stack.topIndex == -2)
        {
            Console.WriteLine("A bracket was closed without opening, failure!");
        }
        else
        {
            Console.WriteLine("A bracket was not closed, failure");
        }
        return stack.topIndex;
    }

    public int GetSize()
    {
        return _values.Length;
    }

    public int GetTopIndex()
    {
        return topIndex;
    }

    public static void Main(String[] args)
    {
        EvalBrackets("");
    }
}