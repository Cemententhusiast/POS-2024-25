namespace Abgabe06;

public class FileReader
{
    private string _filename;
    private IEnumerable<string> _output;

    public FileReader(string filename)
    {
        _filename = filename;
        _output = File.ReadLines(_filename);
        //Console.WriteLine(_output);
    }
    
    public List<string> ToList() => _output.ToList();
}