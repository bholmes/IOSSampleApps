//
//  MatrixTest.h
//  CPerformanceTesting
//
//  Created by William Holmes on 7/18/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MatrixTest : NSObject

@property (nonatomic) int matrixSize;
@property (nonatomic) int iterations;
@property (nonatomic) int seconds;

@property (readonly) double mFlops;
@property (readonly) double mFlopsPerSecond;

-(id) init;

@end
