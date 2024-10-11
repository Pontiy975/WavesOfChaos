using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void SafeRemove<T>(this List<T> list, T item)
    {
        if (list.Contains(item))
        {
            list.Remove(item);
        }
    }
    
    public static void SafeAdd<T>(this List<T> list, T item)
    {
        if (!list.Contains(item))
        {
            list.Add(item);
        }
    }
}
