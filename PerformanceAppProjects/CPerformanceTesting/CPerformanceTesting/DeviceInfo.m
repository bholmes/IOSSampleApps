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

-(void) fetchInfoFromServer
{
    BasicHttpBinding_IPerformanceTestingDataServiceBinding* binding =
    [PerformanceTestingDataServiceSvc BasicHttpBinding_IPerformanceTestingDataServiceBinding];
    binding.logXMLInOut = NO;
    
    PerformanceTestingDataServiceSvc_FindFullDeviceInfo* params =
    [[PerformanceTestingDataServiceSvc_FindFullDeviceInfo alloc]init];
    
    params.uniqueId = self.uniqueId;
    
    [binding FindFullDeviceInfoAsyncUsingParameters:params delegate:self];
}

- (void) operation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation completedWithResponse:(BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)response
{
    NSString* buff;
    
    for (id mine in response.bodyParts)
    {
        if ([mine isKindOfClass:[SOAPFault class]]) {
            // You can get the error like this:
            buff = ((SOAPFault *)mine).simpleFaultString;
            continue;
        }
        
        if ([mine isKindOfClass:[PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse class]])
        {
            tns1_FullDeviceInfo* di =
            ((PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse*)mine).FindFullDeviceInfoResult;
            
            self.ownerName = di.OwnerName;
            self.databaseId = di.DatabaseId.intValue;
        }

    }
}

+ (DeviceInfo*) current
{
    static DeviceInfo* g_current = nil;
    
    if (!g_current)
    {
        g_current = [[DeviceInfo alloc]init];
        [g_current fetchInfoFromServer];
        
    }
    
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
