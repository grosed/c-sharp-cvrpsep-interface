using System;
using System.Runtime.InteropServices;


namespace Main 
{
    public class CVRPSEP_Wrapper
    {
	
	
	[DllImport("libcvrpsep_interface.so", EntryPoint = "CAPSEP_SeparateCapCuts_CPlusPlus_Wrapper")]
	
	    public static extern void CAPSEP_SeparateCapCuts_CPlusPlus_Wrapper([In, Out]
									       int NoCustomers,
									       int[] Demand,
									       int CAP,
									       int NoOfEdges,
									       int[] EdgeTail,
									       int[] EdgeHead,
									       double[] EdgeX,
									       int MaxNoOfCuts,
									       double EpsForIntegrality,
									       int[] Results);
	
	
        public static int[][] SeparateCapCuts(int NoCustomers,
					      int[] Demand,
					      int CAP,
					      int NoOfEdges,
					      int[] EdgeTail,
					      int[] EdgeHead,
					      double[] EdgeX,
					      int MaxNoOfCuts,
					      double EpsForIntegrality)
        {	    

	    int[] DemandPadded = new int[Demand.Length+1];
	    Array.Copy(Demand,0,DemandPadded,1,Demand.Length);
	    int[] EdgeTailPadded = new int[EdgeTail.Length+1];
	    Array.Copy(EdgeTail,0,EdgeTailPadded,1,EdgeTail.Length);
	    for(int i = 1; i < EdgeTailPadded.Length; i++)
	    {
		if(EdgeTailPadded[i] == 0)
		{
		    EdgeTailPadded[i] = NoCustomers + 1;
		}
	    }
	    int[] EdgeHeadPadded = new int[EdgeHead.Length+1];
	    Array.Copy(EdgeHead,0,EdgeHeadPadded,1,EdgeHead.Length);
	    for(int i = 1; i < EdgeHeadPadded.Length; i++)
	    {
		if(EdgeHeadPadded[i] == 0)
		{
		    EdgeHeadPadded[i] = NoCustomers + 1;
		}
	    }
	    double[] EdgeXPadded = new double[EdgeX.Length+1];
	    Array.Copy(EdgeX,0,EdgeXPadded,1,EdgeX.Length);
	    int[] Results = new int[1 + MaxNoOfCuts * (1 + NoCustomers)];
	    for(int pos = 0; pos < 1 + MaxNoOfCuts * (1 + NoCustomers); pos++)
	    {
		Results[pos] = 0;
	    }
	    
	    // call C++
	    CAPSEP_SeparateCapCuts_CPlusPlus_Wrapper(NoCustomers,
						     DemandPadded,
						     CAP,
						     NoOfEdges,
						     EdgeTailPadded,
						     EdgeHeadPadded,
						     EdgeXPadded,
						     MaxNoOfCuts,
						     EpsForIntegrality,
						     Results);

            // process results
	    int cursor = 0;
	    int cut = 0;
	    int nCuts = Results[cursor];
	    cursor++;
	    int[][] Separated = new int[nCuts][];
	    while(Results[cursor] != 0)
		  {
		      int cut_size = Results[cursor];
		      Separated[cut] = new int[cut_size];
		      for(int pos = 0; pos < cut_size; pos++)
		      {
			  cursor++;
			  Separated[cut][pos] = Results[cursor];
		      }
		      cut++;
		      cursor++;
		  }
	    
	    return Separated;
	    
        }
    }
}
