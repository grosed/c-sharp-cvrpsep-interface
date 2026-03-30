#include <cstdlib>
#include <cstdio>


#include <stdlib.h>
#include <stdio.h>
#include "memmod.h"
#include "basegrph.h"
#include "sort.h"
#include "cnstrmgr.h"
#include "cutbase.h"
#include "compcuts.h"
#include "compress.h"
#include "fcapfix.h"
#include "grsearch.h"


#include "capsep.h"
#include "cnstrmgr.h"


extern "C" // __declspec(dllexport)
void CAPSEP_SeparateCapCuts_CPlusPlus_Wrapper(
    int NoOfCustomers,
    int* Demand,
    int CAP,
    int NoOfEdges,
    int* EdgeTail,
    int* EdgeHead,
    double* EdgeX,
    int MaxNoOfCuts,
    double EpsForIntegrality,
    int* Results
)
{
    CnstrMgrPointer ExistingCutsCMP = NULL;
    CnstrMgrPointer CutsCMP = NULL;

    CMGR_CreateCMgr(&ExistingCutsCMP, 0);
    CMGR_CreateCMgr(&CutsCMP, MaxNoOfCuts);

    char IntegerAndFeasible = 0;
    double MaxViolation = 0.0;

    // --- Call CVRPSEP ---
    CAPSEP_SeparateCapCuts(
        NoOfCustomers,
        Demand,
        CAP,
        NoOfEdges,
        EdgeTail,
        EdgeHead,
        EdgeX,
        ExistingCutsCMP,
        MaxNoOfCuts,
        EpsForIntegrality,
        &IntegerAndFeasible,
        &MaxViolation,
        CutsCMP
    );

    
    int nCuts = CutsCMP->Size;

    // int pos = 0;
    int cursor = 0;
    Results[cursor] = nCuts;
    cursor++;
    for (int c = 0; c < nCuts; ++c)
    {
        CnstrPointer cut = CutsCMP->CPL[c];

        
        if (cut->CType != CMGR_CT_CAP && cut->CType != CMGR_CT_GENCAP)
            continue;

        int sz = cut->IntListSize;
        int* S = cut->IntList;
        S++;
	Results[cursor] = sz;
	cursor++;
        for(int i = 0; i < sz; i++)
	  {
	    Results[cursor] = *S;
	    S++;
	    cursor++;
	  }
	
	
    }

    CMGR_FreeMemCMgr(&ExistingCutsCMP);
    CMGR_FreeMemCMgr(&CutsCMP);
}
