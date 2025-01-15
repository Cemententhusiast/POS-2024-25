namespace Aufgabe1;

public class QuadratA : FigurA
{
    public new double Flaeche { get; }
    
    public int A { get;}

    public QuadratA(int a) : base(a)
    {
        if (a > 0)
        {
            Flaeche = a * a;
            A = a;
        }
        else throw new Exception("Seitenlänge zu kurz!");
    }

    public override string ToString()
    {
        return $"Flaeche: {Flaeche}\nA: {A}";
    }
}