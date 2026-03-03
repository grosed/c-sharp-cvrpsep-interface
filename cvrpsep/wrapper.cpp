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

#include <iostream>

extern "C" // __declspec(dllexport)
void CAPSEP_SeparateCapCuts_Wrapper(
    int NoOfCustomers,
    int* Demand,
    int CAP,
    int NoOfEdges,
    int* EdgeTail,
    int* EdgeHead,
    double* EdgeX,
    int MaxNoOfCuts,
    double EpsForIntegrality
)
{
  std::cout << "in CAPSEP_SeparateCapCuts_Wrapper" << std::endl;
    CnstrMgrPointer ExistingCutsCMP = NULL;
    CnstrMgrPointer CutsCMP = NULL;

    CMGR_CreateCMgr(&ExistingCutsCMP, 0);
    CMGR_CreateCMgr(&CutsCMP, MaxNoOfCuts);

    char IntegerAndFeasible = 0;
    double MaxViolation = 0.0;

    std::cout << "calling CAPSEP_SeparateCapCuts" << std::endl;
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

    std::cout << "returned from call to CAPSEP_SeparateCapCuts" << std::endl;

    
    int nCuts = CutsCMP->Size;

    int pos = 0;

    for (int c = 0; c < nCuts; ++c)
    {
        CnstrPointer cut = CutsCMP->CPL[c];

        
        if (cut->CType != CMGR_CT_CAP && cut->CType != CMGR_CT_GENCAP)
            continue;

        int sz = cut->IntListSize;
        int* S = cut->IntList;
    }

    CMGR_FreeMemCMgr(&ExistingCutsCMP);
    CMGR_FreeMemCMgr(&CutsCMP);


    
}
