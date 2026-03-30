using System;

namespace Main 
{
    class Program 
    {
        static void Main(string[] args) 
        {
	    // example from billie-jo
	    int CAP = 4;
	    int NoOfEdges = 15;
	    int MaxNoOfCuts = 100;
	    double EpsForIntegrality = 0.01;
	    int NoCustomers = 5;
	    int[] Demand = [2, 2, 2, 2, 2];
	    int[] EdgeTail = [0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4];
	    int[] EdgeHead = [1, 2, 3, 4, 5, 2, 3, 4, 5, 3, 4, 5, 4, 5, 5];
	    double[] EdgeX = [0.5, 0.5, 0.5, 0.0, 0.0, 1.0, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0];
	    
	    int[][] Results = CVRPSEP_Wrapper.SeparateCapCuts(NoCustomers,
							   Demand,
							   CAP,
							   NoOfEdges,
							   EdgeTail,
							   EdgeHead,
							   EdgeX,
							   MaxNoOfCuts,
							   EpsForIntegrality);

	    Console.WriteLine("Now process the ragged array Result !! - for now, just printing it");
	    for(int i = 0; i < Results.Length; i++)
	    {
		Console.WriteLine("---------------");
		for(int j = 0; j < Results[i].Length; j++)
		{
		    Console.WriteLine(Results[i][j]);
		}	
	    }
	    Console.WriteLine("---------------");
        }
    }
}
