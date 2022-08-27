namespace Iterators;

public static class ArrayExtensions
{
    public static long CountElements<T>(this T[][] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        long count = 0;
        
        for (long i = 0; i < array.LongLength; i++)
            count += array[i]?.LongLength ?? 0;

        return count;
    }
    
    public static JaggedArrayEnumerable<T> Flatten<T>(this T[][] array) => new(array);

    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
    
    public static MultidimensionalArrayEnumerable<T> AsSequential<T>(this T[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,] array) => new(array);
}