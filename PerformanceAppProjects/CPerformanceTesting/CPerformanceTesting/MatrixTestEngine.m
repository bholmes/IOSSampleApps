//
//  MatrixTestEngine.m
//  CPerformanceTesting
//
//  Created by William Holmes on 7/18/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "MatrixTestEngine.h"
#include "../../PerformanceAppLib/PerformanceAppLib/PerformanceAppLib.h"

@implementation MatrixTestEngine

-(MatrixTest*) runSingleTest: (int) matrixSize: (int) iterations: (BOOL) withBLAS
{
    struct MatrixMultInfo info;
    info.matrixSize = matrixSize;
    info.numberIterations = iterations;
    info.useblas = withBLAS ? true : false;
    
    RunMatrixTest(&info);
    
    MatrixTest* ret = [[MatrixTest alloc]init];
    ret.matrixSize = matrixSize;
    ret.iterations = iterations;
    ret.seconds = info.matrixMultiplyTime;
    
    return ret;
}

-(MatrixTest*) runCTest: (BOOL) withBLAS
{
    MatrixTest* test = nil;
    int matrixSize = 128;
    int iterations = 1;
    while (test == nil) {
        test = [self runSingleTest:matrixSize :iterations :withBLAS];
        if (test.seconds < 1)
            matrixSize *= 2;
        else if (test.seconds < 2.5) 
        {
            iterations *= 3;
        }
        else if (test.seconds < 5) 
        {
            iterations *= 2;
        }
        else
            continue;
        test = nil;
    }
    return test;
}

@end
