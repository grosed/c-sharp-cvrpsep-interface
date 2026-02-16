#pragma once

extern "C" __declspec(dllexport)
int SeparateCapCutsWrapper(
    int NoOfCustomers,
    int* Demand,
    int CAP,
    int NoOfEdges,
    int* EdgeTail,
    int* EdgeHead,
    double* EdgeX,
    int MaxNoOfCuts,
    double EpsForIntegrality,
);