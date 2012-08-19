#import <Foundation/Foundation.h>
#import "USAdditions.h"
#import <libxml/tree.h>
#import "USGlobals.h"
@class tns1_FullDeviceInfo;
@class tns1_DeviceInfo;
@class tns1_ArrayOfDeviceInfo;
@class tns1_PerformanceCubeResult;
@class tns1_ArrayOfPerformanceCubeResult;
@class tns1_MatrixTestResult;
@class tns1_ArrayOfMatrixTestResult;
@interface tns1_FullDeviceInfo : NSObject {
	
/* elements */
	NSNumber * DatabaseId;
	NSString * ModelName;
	NSString * OSName;
	NSString * OSVersion;
	NSString * OwnerName;
	NSString * SpecificHWVersion;
	NSString * SystemName;
	NSString * UIIdion;
	NSString * UniqueId;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_FullDeviceInfo *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * DatabaseId;
@property (retain) NSString * ModelName;
@property (retain) NSString * OSName;
@property (retain) NSString * OSVersion;
@property (retain) NSString * OwnerName;
@property (retain) NSString * SpecificHWVersion;
@property (retain) NSString * SystemName;
@property (retain) NSString * UIIdion;
@property (retain) NSString * UniqueId;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_DeviceInfo : NSObject {
	
/* elements */
	NSNumber * DatabaseId;
	NSString * ModelName;
	NSString * OSName;
	NSString * OSVersion;
	NSString * SpecificHWVersion;
	NSString * UIIdion;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_DeviceInfo *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * DatabaseId;
@property (retain) NSString * ModelName;
@property (retain) NSString * OSName;
@property (retain) NSString * OSVersion;
@property (retain) NSString * SpecificHWVersion;
@property (retain) NSString * UIIdion;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_ArrayOfDeviceInfo : NSObject {
	
/* elements */
	NSMutableArray *DeviceInfo;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_ArrayOfDeviceInfo *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
- (void)addDeviceInfo:(tns1_DeviceInfo *)toAdd;
@property (readonly) NSMutableArray * DeviceInfo;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_PerformanceCubeResult : NSObject {
	
/* elements */
	NSNumber * DatabaseId;
	NSNumber * DeviceDatabaseId;
	NSNumber * FramesPerSecond;
	USBoolean * IsMonoTouch;
	NSNumber * NumberOfTriangles;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_PerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * DatabaseId;
@property (retain) NSNumber * DeviceDatabaseId;
@property (retain) NSNumber * FramesPerSecond;
@property (retain) USBoolean * IsMonoTouch;
@property (retain) NSNumber * NumberOfTriangles;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_ArrayOfPerformanceCubeResult : NSObject {
	
/* elements */
	NSMutableArray *PerformanceCubeResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_ArrayOfPerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
- (void)addPerformanceCubeResult:(tns1_PerformanceCubeResult *)toAdd;
@property (readonly) NSMutableArray * PerformanceCubeResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_MatrixTestResult : NSObject {
	
/* elements */
	NSNumber * BLASTestResult;
	NSNumber * CSTestResult;
	NSNumber * CTestResult;
	NSNumber * DatabaseId;
	NSNumber * DeviceDatabaseId;
	USBoolean * IsMonoTouch;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_MatrixTestResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * BLASTestResult;
@property (retain) NSNumber * CSTestResult;
@property (retain) NSNumber * CTestResult;
@property (retain) NSNumber * DatabaseId;
@property (retain) NSNumber * DeviceDatabaseId;
@property (retain) USBoolean * IsMonoTouch;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface tns1_ArrayOfMatrixTestResult : NSObject {
	
/* elements */
	NSMutableArray *MatrixTestResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (tns1_ArrayOfMatrixTestResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
- (void)addMatrixTestResult:(tns1_MatrixTestResult *)toAdd;
@property (readonly) NSMutableArray * MatrixTestResult;
/* attributes */
- (NSDictionary *)attributes;
@end
