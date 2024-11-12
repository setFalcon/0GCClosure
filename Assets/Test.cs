using System;
using System.Collections.Generic;
using Closure;
using UnityEngine;
using UnityEngine.Profiling;
using Random = System.Random;

static class ListExtension
{
    public static int FindIndex<T>(this List<T> list, Func<T, T, bool> fun, T find)
    {
        for (int i = 0; i < list.Count; i++)
        {
            FuncClosure closure = FuncClosure.Create(fun, list[i], find);
            bool match = closure.Invoke<T, T, bool>();
            if (match)
            {
                return i;
            }
        }

        return -1;
    }
}

public class Test : MonoBehaviour
{
    Random random = new();
    List<int> list = new() { 1, 2, 3 };

    private void Update()
    {
        int find = random.Next(1, 4);

        Profiler.BeginSample("FindIndex-GC");
        int indexGC = list.FindIndex((x) => x == find);
        Profiler.EndSample();

        Profiler.BeginSample("FindIndex-NoGC");
        int indexNoGC = list.FindIndex((x, y) => x == y, find);
        Profiler.EndSample();

        Debug.Log($"indexGC = {indexGC}, indexNoGC = {indexNoGC}");
    }
}
