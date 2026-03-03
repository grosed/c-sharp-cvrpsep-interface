
using System;
using System.Runtime.InteropServices;

public class Program
{
    // Import the native function from the DLL (e.g., "NativeLibrary.dll")
    [DllImport("libcvrpsep_interface.so", EntryPoint = "CAPSEP_SeparateCapCuts_Wrapper")]
    // public static extern void CAPSEP_SeparateCapCuts_Wrapper([In, Out] int[] int_data, int int_size, double[] double_data, int double_size);


    public static extern void CAPSEP_SeparateCapCuts_Wrapper([In, Out]
							     int NoCustomers,
							     int[] Demand,
							     int CAP,
							     int NoOfEdges,
							     int[] EdgeTail,
							     int[] EdgeHead,
							     double[] EdgeX,
							     int MaxNoOfCuts,
							     double EpsForIntegrality);




    public static void Main()
    {
        double[] double_data = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        int double_size = double_data.Length;

        int[] int_data = { 1, 2, 3, 4, 5 };
        int int_size = int_data.Length;

	// from billie - but with changes of variable names
	int NoCustomers = 5; //does not include depot
	int[] Demand = [2, 2, 2, 2, 2];
	int CAP = 4;
	int NoOfEdges = 15;
	int[] EdgeTail = [0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4];
	int[] EdgeHead = [1, 2, 3, 4, 5, 2, 3, 4, 5, 3, 4, 5, 4, 5, 5];
	double[] EdgeX = [0.5, 0.5, 0.5, 0.0, 0.0, 1.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0];

	// extra stuf not provided by billie - guessing what I should put here !!

	int MaxNoOfCuts = 100;
	double EpsForIntegrality = 0.01;


	

        // call wrapper
	CAPSEP_SeparateCapCuts_Wrapper(NoCustomers,
				       Demand,
				       CAP,
				       NoOfEdges,
				       EdgeTail,
				       EdgeHead,
				       EdgeX,
				       MaxNoOfCuts,
				       EpsForIntegrality);

	    

	
        Console.WriteLine("Original double array: " + string.Join(", ", double_data));
	Console.WriteLine("Original int array: " + string.Join(", ", int_data));

        // Call the C function, passing the array and its size
        // process_double_integer_arrays(int_data, int_size, double_data, double_size);
	 Console.WriteLine("double array after C function call: " + string.Join(", ", double_data));
	 Console.WriteLine("int array after C function call: " + string.Join(", ", int_data));
    }
}
