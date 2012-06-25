//
//  ResultData.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "ResultData.h"

@implementation ResultData

@synthesize glCubeResults;

-(id)init
{
    self = [super init];
    if (self)
    {
        self.glCubeResults = [[GLCubeResults alloc]init];
    }
    
    return self;
}

+(ResultData*) results
{
    static ResultData* sResults = nil;
    
    if (!sResults)
        sResults = [[ResultData alloc]init];
    
    return sResults;
}

@end
