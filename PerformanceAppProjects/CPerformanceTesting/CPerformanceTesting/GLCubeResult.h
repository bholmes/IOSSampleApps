//
//  GLCubeResult.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface GLCubeResult : NSObject

@property (nonatomic) int numberOfTriangles;
@property (nonatomic) double framesPerSecond;

- (id)initWithNumberOfTriangles: (int) numTriangles framesPerSecond: (double) fps;

@end
