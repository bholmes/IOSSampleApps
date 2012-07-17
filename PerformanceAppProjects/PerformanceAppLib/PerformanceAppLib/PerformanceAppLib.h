//
//  PerformanceAppLib.h
//  PerformanceAppLib
//
//  Created by William Holmes on 7/7/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//


#ifndef TestMatrixLibrary_mainLibFile_h
#define TestMatrixLibrary_mainLibFile_h

#include <stdbool.h>

struct MatrixMultInfo
{
    int matrixSize;
    int numberIterations;
    double MFlops;
    double totalTime;
    double matrixMultiplyTime;
    bool useblas;
};

void RunMatrixTest (struct MatrixMultInfo* info);

#endif
