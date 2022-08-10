namespace Problems.Chapter17_DynamicProgramming;
using System;
using System.Linq;

public class PrettyPrinting
{
    public record struct Line(string[] Words, uint Messiness, uint Level);
    public record struct Decomposition(Line[] Lines, uint Messiness);

    public Decomposition DecomposeIntoLines(string initialText, uint maxLineWidth)
    {
        if (initialText == null) throw new ArgumentNullException(nameof(initialText));
        if (string.IsNullOrWhiteSpace(initialText)) throw new ArgumentException("whitespace"); // todo better message
        if (maxLineWidth == 0) throw new ArgumentException("width = 0");


        var words = initialText.Split(' ');
        var cache = new Decomposition?[words.Length, words.Length];
        var result = DecomposeIntoLines(words, words.Length-1, maxLineWidth, (uint)words.Length-1, cache);
        return result;
    }

    // TODO: refactor
    private Decomposition DecomposeIntoLines(string[] words, int offset, uint maxLineWidth, uint level, Decomposition?[,] cache)
    {
        if (offset < 0 || level <0) return new Decomposition(Array.Empty<Line>(),0);
        if (cache[level,offset].HasValue) return cache[level,offset].Value;

        var min = new Decomposition(Array.Empty<Line>(), uint.MaxValue);
        var lineWidth =-1; // to account for first word not preceded by space
        for (var i = 0; i <= offset; i++)
        {
            var newLineWidth = lineWidth + 1 + words[offset - i].Length; // space plus word
            if (newLineWidth > maxLineWidth) break;
            lineWidth = newLineWidth;
            var lineMessiness = (uint)Math.Pow(maxLineWidth - lineWidth,2);
            var line = new Line(words[(offset-i)..(offset+1)],lineMessiness ,level); // TODO: much copying for prod code
            var value = DecomposeIntoLines(words, offset - i - 1, maxLineWidth, level - 1, cache);
            if (value.Messiness + lineMessiness < min.Messiness) {
                min = new Decomposition(value.Lines.Union(new [] {line}).ToArray(), value.Messiness+lineMessiness); // TODO: this is too much copying for prod code
            };
        }
        cache[level,offset]=min;
        return min;
    }
}
