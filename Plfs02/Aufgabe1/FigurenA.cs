namespace Aufgabe1;

public class FigurenA
{
    private List<FigurA> _figuren;

    public FigurenA()
    {
        _figuren = new List<FigurA>();
    }

    public void Add(FigurA figur)
    {
        try
        {
            _figuren.Add(figur);
        }
        catch (Exception e)
        {
            throw new Exception("An Error has occured whilst attempting to add a figure: " + e);
        }
    }

    public double Durchschnitt()
    {
        return _figuren.Average(f => f.Flaeche);
    }

    public IEnumerable<FigurA> Sortiert(bool aufSteigend)
    {
        if (aufSteigend) return _figuren.OrderBy(a => a.Flaeche);
        return _figuren.OrderByDescending(a => a.Flaeche);
    }
    
    
}