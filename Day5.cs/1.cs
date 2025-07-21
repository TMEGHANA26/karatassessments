using System;
class Program
{
    static void Main(string[] args)
    {
        ArrayPrinter ap = new ArrayPrinter();
        int[] array1 = new int[] { 23, 25, 27, 29 };
 
        ap.PrintElementAtIndex(array1, 2);  // Valid index
        ap.PrintElementAtIndex(array1, 4);  // Invalid index (out of bounds)
        ap.PrintElementAtIndex(array1, -1); // Invalid index (negative)
    }
} 
class ArrayPrinter
{
    public void PrintElementAtIndex(int[] arr, int index)
    {
        if (arr == null)
        {
            Console.WriteLine("Array is null.");
            return;
        }
 
        if (index >= 0 && index < arr.Length)
        {
            Console.WriteLine("Element at index " + index + ": " + arr[index]);
        }
        else
        {
            Console.WriteLine("Error: Invalid index " + index + ". Valid range is 0 to " + (arr.Length - 1));
        }
    }
}
 