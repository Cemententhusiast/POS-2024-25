namespace Aufgabe1;

public abstract class FigurA
{
    public double Flaeche { get; }

    protected FigurA(double flacheche)
    {
        Flaeche = flacheche;
    }

    public override string ToString()
    {
        return $"Flaeche: {Flaeche}";
    }
}