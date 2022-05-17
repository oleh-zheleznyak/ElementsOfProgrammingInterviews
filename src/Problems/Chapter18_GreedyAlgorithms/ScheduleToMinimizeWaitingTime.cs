namespace Problems.Chapter18_GreedyAlgorithms;
using System;
using System.Linq;

public readonly record struct OrderedTasksWithWaitTime(int[] tasks, int waitTime);

public class ScheduleToMinimizeWaitingTime
{


    public OrderedTasksWithWaitTime OrderOfMinWaitTime(int[] taskDurations)
    {
        if (taskDurations is null) throw new ArgumentNullException(nameof(taskDurations));
        if (taskDurations.Length <=1) return new OrderedTasksWithWaitTime(taskDurations,0);

        var orderedTasks = taskDurations.OrderBy(x=>x).ToArray();
        var totalWaitTime = 0;
        var runningSum =0;
        for (var i=0; i<orderedTasks.Length-1;i++)
        {
            runningSum+=orderedTasks[i];
            totalWaitTime+=runningSum;
        }
        return new OrderedTasksWithWaitTime(orderedTasks,totalWaitTime);
    }
}