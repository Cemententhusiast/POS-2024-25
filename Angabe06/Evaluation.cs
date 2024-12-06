namespace Abgabe06;
using Abgabe06;

public class Evaluation
{
    private List<string> _inputList1;
    private List<string> _inputList2;

    public Evaluation()
    {
        _inputList1 = new FileReader("../../../wahlzettel1.txt").ToList();
        _inputList2 = new FileReader("../../../wahlzettel2.txt").ToList();
        AllocateSeats(Evaluate(_inputList1));
        AllocateSeats(Evaluate(_inputList2));
    }

    public Dictionary<string, int> Evaluate(List<string> input)
    {
        List<string> parties = input.GroupBy(x => x).Select(x => x.First()).ToList();
        //input.ForEach(party => Console.WriteLine(party));
        var votes = input
            .GroupBy(n => n)
            .ToDictionary(g => g.Key,
                g => g.Count());
        Console.WriteLine("Value counts:");
        foreach (var pair in votes)
        {
            //Console.WriteLine($"Value {pair.Key}: {pair.Value} time(s)");
        }

        return votes;
    }

    public void AllocateSeats(Dictionary<string, int> votes)
    {
        int toAllocate = 10;
        var seatAllocation = votes.ToDictionary(kvp => kvp.Key, kvp => 0);
        var scores = votes.ToDictionary(kvp => kvp.Key, kvp => (double)kvp.Value);

        for (int i = 0; i < toAllocate; i++)
        {
            var highestScoringParty = scores.OrderByDescending(s => s.Value).First().Key;
            seatAllocation[highestScoringParty]++;
            scores[highestScoringParty] = (double)votes[highestScoringParty] / (seatAllocation[highestScoringParty] + 1);
        }
        foreach (var keyValuePair in seatAllocation)
        {
            Console.WriteLine($"Seat {keyValuePair.Key}: {keyValuePair.Value} time(s)");
        }
    }

}