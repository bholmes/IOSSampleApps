//
//  MatrixTestEngine.h
//  CPerformanceTesting
//
//  Created by William Holmes on 7/18/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MatrixTest.h"

@interface MatrixTestEngine : NSObject

-(MatrixTest*) runCTest: (BOOL) withBLAS;

@end
