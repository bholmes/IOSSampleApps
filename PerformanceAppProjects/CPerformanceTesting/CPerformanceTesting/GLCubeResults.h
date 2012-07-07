//
//  GLCubeResults.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "GLCubeResult.h"

@interface GLCubeResults : NSObject


@property(readonly) int count;

-(id) init;
-(GLCubeResult*) getItemAt:(int) index;
-(void) removeAt:(int) index;
-(void) addResult:(GLCubeResult*) result;
-(void) insert:(GLCubeResult*) result at: (int) index;

@end
