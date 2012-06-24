//
//  DeviceInfo.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/23/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "DeviceInfo.h"
#import <UIKit/UIDevice.h>

#include <sys/types.h>
#include <sys/sysctl.h>

@implementation DeviceInfo

- (id)init
{
    self = [super init];
    if (self) {
        size_t machineTypeSize = 128;
        char machineType[128];
        machineType[0] = 0;
        
        sysctlbyname("hw.machine", machineType, &machineTypeSize, NULL, 0);
        _specificHWVersion = [NSString stringWithUTF8String:machineType];
    }
    return self;
}

+ (DeviceInfo*) current
{
    static DeviceInfo* g_current = nil;
    
    if (!g_current)
        g_current = [[DeviceInfo alloc]init];
    
    return g_current;
}

-(NSString*) deviceName
{
    return UIDevice.currentDevice.name;
}

-(NSString*) osName
{
    return UIDevice.currentDevice.systemName;
}

-(NSString*) osVersion
{
    return UIDevice.currentDevice.systemVersion;
}

-(NSString*) modelName
{
    return UIDevice.currentDevice.model;
}

-(NSString*) uniqueId
{
    return UIDevice.currentDevice.uniqueIdentifier;
}

-(NSString*) uiIdion
{
    if (!UIDevice.currentDevice.userInterfaceIdiom)
        return @"Phone";
    
    return @"Pad";
}

@synthesize specificHWVersion=_specificHWVersion;
@synthesize ownerName;
@synthesize databaseId;

@end
