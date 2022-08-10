using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problems.Chapter17_DynamicProgramming;

public class PrettyPrintingByTheBook
{
    public int CalculateMessiness(string[] words, int maxLineWidth)
    {
        // formula M[i]=min(j<=i ; f(i,j) + M[j-1] )
        // f(i,j) messiness of line that has words i..j, M[i] - total messiness of placement of words 0..i

        var messiness = new int[words.Length];
        var remainingWidth = maxLineWidth - words[0].Length;
        messiness[0] = remainingWidth * remainingWidth;

        for (var i = 1; i < words.Length; ++i)
        {
            remainingWidth = maxLineWidth - words[i].Length;
            messiness[i] = messiness[i-1] + remainingWidth * remainingWidth;

            for (var j = i - 1; j >= 0; --j)
            {
                remainingWidth -= (words[j].Length + 1);
                if (remainingWidth < 0) 
                    break;
                Debug.Write($"{words[j]} ");

                var prev_messiness = j - 1 < 0 ? 0 : messiness[j - 1];
                var lineMessiness = remainingWidth * remainingWidth;

                messiness[i] = Math.Min(messiness[i], lineMessiness + prev_messiness);
            }
            Debug.Write(messiness[i]);
            Debug.Write(Environment.NewLine);
        }
        return messiness.Last();
    }
}