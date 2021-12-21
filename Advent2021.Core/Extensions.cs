namespace Advent2021.Core;

using System.Runtime.Versioning;

public static class Extensions
{
    
    [RequiresPreviewFeatures]
    public static IEnumerable<TResult> Diff<T, TResult>(this IReadOnlyList<T> data) 
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[data.Count- 1];
        for (var i = 0; i < result.Length; ++i)
        {
            var next = TResult.Create(data[i + 1]);
            var prev = TResult.Create(data[i]);
            result[i] = next - prev;
        }

        return result;
    }
    
    [RequiresPreviewFeatures]
    public static TResult Median<T, TResult>(this IReadOnlyList<T> data)      
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var sorted = data.ToList();
        sorted.Sort();

        var medianIndex = Math.Floor(sorted.Count / 2.0) ;
        medianIndex = sorted.Count % 2 == 0 ? Math.Floor(medianIndex) - 1 : Math.Ceiling(medianIndex);
        var result = TResult.Create(sorted[(int)medianIndex]);
        return result;
    }
}