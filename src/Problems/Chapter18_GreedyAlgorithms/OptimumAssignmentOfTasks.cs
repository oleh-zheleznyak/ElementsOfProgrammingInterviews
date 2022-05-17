namespace Problems.Chapter18_GreedyAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;

public class OptimumAssignmentOfTasks
{
    public uint FindOptimumAssignment(uint[] tasks)
    {
        if (tasks is null) throw new ArgumentNullException(nameof(tasks));
        if (tasks.Length ==0) throw new ArgumentException("tasks is empty", nameof(tasks));
        if (tasks.Length == 1) return tasks[0];
        // example: 5,2,1,6,4,4
        // result 5+2,1+6,4+4 
        // option 1: sort & max + min = first + last on every step - O(nlgn) time, O(n) space
        // option 2: DP T[i] - optimum time for tasks 0...2*(i-1), then T[i] = T[i-1] + min(t(j)+t(k)), where j<>k - unallocated tasks

        var sortedTasks = tasks.OrderByDescending(x=>x).ToArray();
        uint totalTime=uint.MinValue;
        var isEven = tasks.Length % 2 == 0;
        for (var i=0; i<tasks.Length / 2; i++)
        {
            var firstTask = sortedTasks[i];
            var secondTask = isEven ? sortedTasks[tasks.Length-1-i] : 0;
            uint taskPair = firstTask + secondTask;
            totalTime = Math.Max(totalTime, firstTask+secondTask);
        }
        return totalTime;
    }
}