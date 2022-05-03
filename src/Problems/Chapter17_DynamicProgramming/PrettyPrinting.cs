namespace Problems.Chapter17_DynamicProgramming;
using System;

public class PrettyPrinting
{

    public uint DecomposeIntoLines(string initialText, uint maxLineWidth)
    {
        if (initialText == null) throw new ArgumentNullException(nameof(initialText));
        if (string.IsNullOrWhiteSpace(initialText)) throw new ArgumentException("whitespace"); // todo better message
        if (maxLineWidth == 0) throw new ArgumentException("width = 0");


        var words = initialText.Split(' ');
        var cache = new uint?[words.Length, words.Length];
        var result = DecomposeIntoLines(words, words.Length-1, maxLineWidth, words.Length-1, cache);
        return result;
    }

    private uint DecomposeIntoLines(string[] words, int offset, uint maxLineWidth, int level, uint?[,] cache)
    {
        if (offset < 0 || level <0) return 0;
        if (cache[level,offset].HasValue) return cache[level,offset].Value;

        var min = uint.MaxValue;
        var lineWidth =(uint)words[offset].Length;
        var newLineWidth = 0u;
        for (var i = 1; i < offset; i++)
        {
            newLineWidth = (uint)(lineWidth + 1 + words[offset - i].Length); // space plus word
            if (newLineWidth >= maxLineWidth) break;
            lineWidth = newLineWidth;
            var value = DecomposeIntoLines(words, offset - i, maxLineWidth, level - 1, cache);
            if (value < min) min = value; // or Math.Min
        }
        var messiness = min + (uint)Math.Pow(maxLineWidth - lineWidth,2);
        cache[level,offset]=messiness;

        return messiness;
    }
}
