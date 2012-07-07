//
//  ResultData.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "GLCubeResults.h"

@interface ResultData : NSObject

@property(retain, nonatomic) GLCubeResults* glCubeResults;

+(ResultData*) results;

@end
