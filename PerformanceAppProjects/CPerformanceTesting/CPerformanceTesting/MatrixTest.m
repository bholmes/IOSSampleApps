//
//  MatrixTest.m
//  CPerformanceTesting
//
//  Created by William Holmes on 7/18/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "MatrixTest.h"

@implementation MatrixTest

@synthesize matrixSize;
@synthesize iterations;
@synthesize seconds;

-(double) mFlops
{
    int size = self.matrixSize;
    return 2.0*size*size*size*self.iterations / 1000000.0;
}

-(double) mFlopsPerSecond
{
    if (self.seconds < .00000000001)
        return 0;
    
    return self.mFlops/self.seconds;
}

-(id) init
{
    self = [super init];
    if (self) {
        self.matrixSize = 128;
        self.iterations = 1;
    }
    return self;
}

@end
