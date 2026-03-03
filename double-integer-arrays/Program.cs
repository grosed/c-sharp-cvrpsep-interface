
using System;
using System.Runtime.InteropServices;

public class Program
{
    // Import the native function from the DLL (e.g., "NativeLibrary.dll")
    [DllImport("libprocess-double-integer-arrays.so", EntryPoint = "process_double_integer_arrays")]
    public static extern void process_double_integer_arrays([In, Out] int[] int_data, int int_size, double[] double_data, int double_size);

    public static void Main()
    {
        double[] double_data = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        int double_size = double_data.Length;

        int[] int_data = { 1, 2, 3, 4, 5 };
        int int_size = int_data.Length;
	
        Console.WriteLine("Original double array: " + string.Join(", ", double_data));
	Console.WriteLine("Original int array: " + string.Join(", ", int_data));

        // Call the C function, passing the array and its size
        process_double_integer_arrays(int_data, int_size, double_data, double_size);
	 Console.WriteLine("double array after C function call: " + string.Join(", ", double_data));
	 Console.WriteLine("int array after C function call: " + string.Join(", ", int_data));
    }
}
