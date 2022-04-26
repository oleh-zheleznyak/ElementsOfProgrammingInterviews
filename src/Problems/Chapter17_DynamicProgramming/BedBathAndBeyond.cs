namespace Chapter17_DynamicProgramming;
using System;

public class KeywordDecomposition
{
    public string[] FindAnyDecomposition(string name, Dictionary<string> dictionary)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));
        if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
        if (string.IsNullOrWhitespace(name)) throw new ArgumentException(nameof(name));

        var nameSpan = new ReadOnlySpan(name);
        var keywords = new List<string>();
        var found = FindDecomposition(nameSpan, dictionary, keywords);

        return found ? keywords.ToArray() : null;
    }

    private bool FindDecomposition(ReadonlySpan<string> name, Dictionary<string> dictionary, ICollection<string> keywords)
    {
        if (name.IsEmpty) return true;

        for (int i = 1; i < name.Length; i++)
        {
            var prefix = name.ToString().Substring(0, i) // TODO: specific span method like Take or Splice ?? i = length

            if (dictionary.Contains(prefix))
            {
                // take the keyword
                keywords.Add(prefix);
                var nameSuffix = name.Slice(i - 1); // incl index to cut off 
                var found = FindDecomposition(nameSuffix, dictionary, keywords);
                if (found) return true;
                // do not take the keyword // just continue
                keywords.Remove(prefix);
            }
        }
        return false;
    }


}
