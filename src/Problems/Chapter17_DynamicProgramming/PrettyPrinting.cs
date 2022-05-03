namespace Problems.Chapter17_DynamicProgramming;
using System;

public class PrettyPrinting
{

    public uint DecomposeIntoLines(string initialText, uint maxLineWidth)
    {
        if (initialText == null) throw new ArgumentNullException(nameof(initialText));
        if (string.IsNullOrWhitespace(initialText)) throw new ArgumentException("whitespace"); // todo better message
        if (maxLineWidth = 0) throw new ArgumentException("width = 0");

        var cache = new …

        var words = initialText.Split(‘ ‘);
        var level = 0;
        var result = DecomposeIntoLines(words, words.Length, maxLineWidth, int level, cache);
        return result;
    }

    private uint DecomposeIntoLines(string[] words, int offset, uint maxLineWidth, int level,  … cache)
    {
        if (offset == 0) return 0;

        var min = int.MaxValue;
        var lineWidth = words[offset].Length;
        var newLineWidth = 0;
        for (var i = 1; i < offset; i++)
        {
            newLineWidth = lineWidth + 1 + words[offset - i].Length; // space plus word
            if (newLineWidth >= maxLineWidth) break;
            lineWidth = newLineWidth;
            var value = DecomposeIntoLines(words, offset - i, maxLineWidth, level - 1, cache);
            if (value < min) min = value; // or Math.Min
        }
        var messiness = min + lineWidth;
        return messiness;

    }

}
