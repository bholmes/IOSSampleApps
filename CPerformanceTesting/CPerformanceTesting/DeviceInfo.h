//
//  DeviceInfo.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/23/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DeviceInfo : NSObject
{
    NSString* _specificHWVersion;
}

+ (DeviceInfo*) current;

@property(nonatomic,readonly) NSString *deviceName;
@property(nonatomic,readonly) NSString *osName;
@property(nonatomic,readonly) NSString *osVersion;
@property(nonatomic,readonly) NSString *modelName;
@property(nonatomic,readonly) NSString *specificHWVersion;
@property(nonatomic,readonly) NSString *uniqueId;
@property(nonatomic,readonly) NSString *uiIdion;
@property(nonatomic,retain) NSString *ownerName;
@property(nonatomic) int databaseId;

@end
