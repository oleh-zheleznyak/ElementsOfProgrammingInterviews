namespace Chapter17_DynamicProgramming;
using System;
using System.Collections.Generic;

public class BedBathAndBeyond
{
    public string[] FindAnyDecomposition(string name, ISet<string> dictionary)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));
        if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

        var nameSpan = name.AsSpan();
        var keywords = new List<string>();
        var cache = new HashSet<string>();
        var found = FindDecomposition(nameSpan, dictionary, keywords, cache);

        return found ? keywords.ToArray() : Array.Empty<string>();
    }

    private bool FindDecomposition(ReadOnlySpan<char> name, ISet<string> dictionary, ICollection<string> keywords, ISet<string> cache)
    {
        if (name.IsEmpty) return true;

        for (int i = 1; i <= name.Length; i++)
        {
            var prefix = name.Slice(0, i).ToString();

            if (dictionary.Contains(prefix))
            {
                // take the keyword
                keywords.Add(prefix);
                var nameSuffix = name.Slice(i);
                if (!cache.Contains(nameSuffix.ToString()))
                {
                    var found = FindDecomposition(nameSuffix, dictionary, keywords, cache);
                    if (found) return true;
                }
                keywords.Remove(prefix);
            }
        }
        cache.Add(name.ToString());
        return false;
    }
}
