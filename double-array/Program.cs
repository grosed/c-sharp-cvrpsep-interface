using System;
using System.Runtime.InteropServices;

public class Program
{
    // Import the native function from the DLL (e.g., "NativeLibrary.dll")
    [DllImport("libprocess-double-array.so", EntryPoint = "process_double_array")]
    public static extern void process_double_array([In, Out] double[] data, int size);

    public static void Main()
    {
        double[] data = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        int size = data.Length;

        Console.WriteLine("Original array: " + string.Join(", ", data));

        // Call the C function, passing the array and its size
        process_double_array(data, size);
	 Console.WriteLine("Array after C function call: " + string.Join(", ", data));
    }
}




// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
