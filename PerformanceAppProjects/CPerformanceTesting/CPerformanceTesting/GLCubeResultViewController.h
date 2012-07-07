//
//  GLCubeResultViewController.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "GLCubeResults.h"
#import "PerformanceTestingDataServiceSvc.h"

@interface GLCubeResultViewController : UITableViewController <BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>

-(id) initWithResults: (GLCubeResults*) res;

+(GLCubeResultViewController*) fromRemoteResults;

@end
