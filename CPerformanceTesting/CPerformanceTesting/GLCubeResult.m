//
//  GLCubeResult.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "GLCubeResult.h"

@implementation GLCubeResult

@synthesize numberOfTriangles;
@synthesize framesPerSecond;

- (id)initWithNumberOfTriangles: (int) numTriangles framesPerSecond: (double) fps
{
    self = [super init];
    if (self) {
        self.numberOfTriangles = numTriangles;
        self.framesPerSecond = fps;
    }
    return self;
}

@end
