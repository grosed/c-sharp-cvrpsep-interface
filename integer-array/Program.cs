using System;
using System.Runtime.InteropServices;

class Program
{
    // Import the native function from the DLL
    // The C# int[] parameter automatically marshals as a C-style int*
    [DllImport("libinteger-array.so", EntryPoint="process_int_array")]
    public static extern int process_int_array(int[] arr, int size);

    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int arraySize = numbers.Length;

        Console.WriteLine("C# array before call:");
        foreach (int n in numbers)
        {
            Console.Write($"{n} ");
        }
	Console.WriteLine();

        // Call the C function, passing the array and its size
        int sum = process_int_array(numbers, arraySize);

        Console.WriteLine($"Sum from C function: {sum}");

        Console.WriteLine("C# array after call (modified by C function):");
        foreach (int n in numbers)
        {
            Console.Write($"{n} ");
        }
        Console.WriteLine();
    }
}



// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
