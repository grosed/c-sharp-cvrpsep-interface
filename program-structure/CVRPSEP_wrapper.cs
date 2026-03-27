using System;
using System.Runtime.InteropServices;


namespace Main 
{
    public class CVRPSEP_Wrapper
    {
	
	
	[DllImport("libcvrpsep_interface.so", EntryPoint = "CAPSEP_SeparateCapCuts_Wrapper")]
	
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
	    int[] EdgeHeadPadded = new int[EdgeHead.Length+1];
	    Array.Copy(EdgeHead,0,EdgeHeadPadded,1,EdgeHead.Length);
	    double[] EdgeXPadded = new double[EdgeX.Length+1];
	    Array.Copy(EdgeX,0,EdgeXPadded,1,EdgeX.Length);
	    
	    // call C++
	    CAPSEP_SeparateCapCuts_Wrapper(NoCustomers,
					   DemandPadded,
					   CAP,
					   NoOfEdges,
					   EdgeTailPadded,
					   EdgeHeadPadded,
					   EdgeXPadded,
					   MaxNoOfCuts,
					   EpsForIntegrality);
	    
	    int[][] blob = new int[2][];
	    return blob;
	    
        }
    }
}
