//
//  PerformanceAppLib.m
//  PerformanceAppLib
//
//  Created by William Holmes on 7/7/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#include "PerformanceAppLib.h"

#include <stdlib.h>
#include <stdio.h>
#include <sys/time.h>
#include <Accelerate/Accelerate.h>

static void mallocOnDevice(size_t numBytes, void** memPtr);
static void freeOnDevice(void* memPtr);
static void matrixMult (int n, double *A, double *B, double *C);
static void matrixMultBLAS (int n, double *A, double *B, double *C);

static void mallocOnDevice(size_t numBytes, void** memPtr)
{
    *memPtr = malloc(numBytes);
}

static void freeOnDevice(void* memPtr)
{
    free(memPtr);
}

static void matrixMult (int n, double *A, double *B, double *C)
{
    int i, j, k;
    double sum, a, b;
    
    for (i=0; i<n; i++) {
        for (j=0; j<n; j++) {
            sum = 0.0;
            for (k=0; k<n; k++) {
                a = A[i * n + k];
                b = B[k * n + j];
                sum += a * b;
            }
            C[i * n + j] = sum;
        }
    }
}

static void matrixMultBLAS (int n, double *A, double *B, double *C)
{
    double scale = 1;
    double scale2 = 0;
    cblas_dgemm (CblasRowMajor, CblasNoTrans, CblasNoTrans,
                 n, n, n,scale, A, n, B, n, scale2, C, n);
}

void RunMatrixTest (struct MatrixMultInfo* info)
{
    int i, n, numRepeats;
    size_t numBytes;
    double *aMat, *bMat, *cMat, *dMat;
    
    
    /*************************************************************************************/
    /****************          INITIALIZATION AND SETUP          *************************/
    /*************************************************************************************/
    
    n = info->matrixSize;         /* change this to be what user inputs from APP */
    numRepeats = info->numberIterations;   /* change this to be what user inputs from APP */
    
    struct timeval totalStart;
    gettimeofday(&totalStart, NULL); 
    
    /* Allocate memory to store the matrices on the device */
    numBytes = n*n*sizeof(double);
    mallocOnDevice(numBytes, (void**)&aMat);
    mallocOnDevice(numBytes, (void**)&bMat);
    mallocOnDevice(numBytes, (void**)&cMat);
    mallocOnDevice(numBytes, (void**)&dMat);
    
    /* Fill matrices with some random values */
    for (i=0; i<n*n; i++) {
        aMat[i] = rand() / (double)RAND_MAX;
    }
    for (i=0; i<n*n; i++) {
        bMat[i] = rand() / (double)RAND_MAX;
    }
    
    /*************************************************************************************/
    /**********************    MATRIX MULTIPLY TESTING      ******************************/
    /*************************************************************************************/
    
    struct timeval multStart;
    gettimeofday(&multStart, NULL);   
    
    /* execute the matrix multiply */
    for (i=0; i<numRepeats; i++) {
        if (!info->useblas)
            matrixMult(n, aMat, bMat, cMat);
        else
            matrixMultBLAS(n, aMat, bMat, cMat);
    }
    
    /*    matrixMultBLAS (n, aMat, bMat, dMat);
     
     for (i=0; i<n*n; i++) {
     double diff = fabs(cMat[i] - dMat[i]);
     if (diff > .0000005)
     diff = diff;
     }
     */    
    struct timeval multEnd;
    gettimeofday(&multEnd, NULL);   
    
    /*************************************************************************************/
    /******************          SHUTDOWN AND CLEANUP          ***************************/
    /*************************************************************************************/
    
    /* deallocate memory */
    freeOnDevice(aMat);
    freeOnDevice(bMat);
    freeOnDevice(cMat);
    freeOnDevice(dMat);
    
    struct timeval totalEnd;
    gettimeofday(&totalEnd, NULL); 
    
    /* count the number of MFLOPS for this operation */
    info->MFlops = 2.0*n*n*n*numRepeats / 1000000.0;
    
    long elapsed_seconds  = multEnd.tv_sec  - multStart.tv_sec;
    long elapsed_useconds = multEnd.tv_usec - multStart.tv_usec;
    
    info->matrixMultiplyTime = ((double)elapsed_seconds) + (((double)elapsed_useconds)/1000000);
    
    elapsed_seconds  = totalEnd.tv_sec  - totalStart.tv_sec;
    elapsed_useconds = totalEnd.tv_usec - totalStart.tv_usec;
    
    info->totalTime = ((double)elapsed_seconds) + (((double)elapsed_useconds)/1000000);
}





