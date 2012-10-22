#import <Foundation/Foundation.h>
#import "USAdditions.h"
#import <libxml/tree.h>
#import "USGlobals.h"
@class PerformanceTestingDataServiceSvc_AddDevice;
@class PerformanceTestingDataServiceSvc_AddDeviceResponse;
@class PerformanceTestingDataServiceSvc_FindDeviceInfo;
@class PerformanceTestingDataServiceSvc_FindDeviceInfoResponse;
@class PerformanceTestingDataServiceSvc_FindFullDeviceInfo;
@class PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse;
@class PerformanceTestingDataServiceSvc_GetDeviceList;
@class PerformanceTestingDataServiceSvc_GetDeviceListResponse;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResult;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResults;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResults;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse;
@class PerformanceTestingDataServiceSvc_FindPerformanceCubeResult;
@class PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse;
@class PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult;
@class PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResultResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouchResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC;
@class PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveCResponse;
#import "tns1.h"
@interface PerformanceTestingDataServiceSvc_AddDevice : NSObject {
	
/* elements */
	tns1_FullDeviceInfo * deviceInfo;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddDevice *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_FullDeviceInfo * deviceInfo;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddDeviceResponse : NSObject {
	
/* elements */
	NSNumber * AddDeviceResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddDeviceResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * AddDeviceResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindDeviceInfo : NSObject {
	
/* elements */
	NSNumber * databaseId;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindDeviceInfo *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * databaseId;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindDeviceInfoResponse : NSObject {
	
/* elements */
	tns1_DeviceInfo * FindDeviceInfoResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindDeviceInfoResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_DeviceInfo * FindDeviceInfoResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindFullDeviceInfo : NSObject {
	
/* elements */
	NSString * uniqueId;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSString * uniqueId;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse : NSObject {
	
/* elements */
	tns1_FullDeviceInfo * FindFullDeviceInfoResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_FullDeviceInfo * FindFullDeviceInfoResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetDeviceList : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetDeviceList *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetDeviceListResponse : NSObject {
	
/* elements */
	tns1_ArrayOfDeviceInfo * GetDeviceListResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetDeviceListResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfDeviceInfo * GetDeviceListResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceCubeResult : NSObject {
	
/* elements */
	tns1_PerformanceCubeResult * result;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_PerformanceCubeResult * result;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse : NSObject {
	
/* elements */
	NSNumber * AddPerformanceCubeResultResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * AddPerformanceCubeResultResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceCubeResults : NSObject {
	
/* elements */
	tns1_ArrayOfPerformanceCubeResult * results;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfPerformanceCubeResult * results;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResults : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse : NSObject {
	
/* elements */
	tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse : NSObject {
	
/* elements */
	tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsForMonoTouchResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsForMonoTouchResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse : NSObject {
	
/* elements */
	tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsForObjectiveCResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfPerformanceCubeResult * GetPerformanceCubeResultsForObjectiveCResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindPerformanceCubeResult : NSObject {
	
/* elements */
	NSNumber * id_;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * id_;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse : NSObject {
	
/* elements */
	tns1_PerformanceCubeResult * FindPerformanceCubeResultResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_PerformanceCubeResult * FindPerformanceCubeResultResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult : NSObject {
	
/* elements */
	tns1_MatrixTestResult * result;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_MatrixTestResult * result;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResultResponse : NSObject {
	
/* elements */
	NSNumber * AddPerformanceMatrixTestResultResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResultResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) NSNumber * AddPerformanceMatrixTestResultResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsResponse : NSObject {
	
/* elements */
	tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouchResponse : NSObject {
	
/* elements */
	tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsForMonoTouchResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouchResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsForMonoTouchResult;
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC : NSObject {
	
/* elements */
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
/* attributes */
- (NSDictionary *)attributes;
@end
@interface PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveCResponse : NSObject {
	
/* elements */
	tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsForObjectiveCResult;
/* attributes */
}
- (NSString *)nsPrefix;
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix;
- (void)addAttributesToNode:(xmlNodePtr)node;
- (void)addElementsToNode:(xmlNodePtr)node;
+ (PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveCResponse *)deserializeNode:(xmlNodePtr)cur;
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur;
- (void)deserializeElementsFromNode:(xmlNodePtr)cur;
/* elements */
@property (retain) tns1_ArrayOfMatrixTestResult * GetPerformanceMatrixResultsForObjectiveCResult;
/* attributes */
- (NSDictionary *)attributes;
@end
/* Cookies handling provided by http://en.wikibooks.org/wiki/Programming:WebObjects/Web_Services/Web_Service_Provider */
#import <libxml/parser.h>
#import "xs.h"
#import "PerformanceTestingDataServiceSvc.h"
#import "ns1.h"
#import "tns1.h"
#import "tns2.h"
@class BasicHttpBinding_IPerformanceTestingDataServiceBinding;
@interface PerformanceTestingDataServiceSvc : NSObject {
	
}
+ (BasicHttpBinding_IPerformanceTestingDataServiceBinding *)BasicHttpBinding_IPerformanceTestingDataServiceBinding;
@end
@class BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse;
@class BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation;
@protocol BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate <NSObject>
- (void) operation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation completedWithResponse:(BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)response;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding : NSObject <BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate> {
	NSURL *address;
	NSTimeInterval defaultTimeout;
	NSMutableArray *cookies;
	BOOL logXMLInOut;
	BOOL synchronousOperationComplete;
	NSString *authUsername;
	NSString *authPassword;
}
@property (copy) NSURL *address;
@property (assign) BOOL logXMLInOut;
@property (assign) NSTimeInterval defaultTimeout;
@property (nonatomic, retain) NSMutableArray *cookies;
@property (nonatomic, retain) NSString *authUsername;
@property (nonatomic, retain) NSString *authPassword;
- (id)initWithAddress:(NSString *)anAddress;
- (void)sendHTTPCallUsingBody:(NSString *)body soapAction:(NSString *)soapAction forOperation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation;
- (void)addCookie:(NSHTTPCookie *)toAdd;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddDeviceUsingParameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters ;
- (void)AddDeviceAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindDeviceInfoUsingParameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters ;
- (void)FindDeviceInfoAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindFullDeviceInfoUsingParameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters ;
- (void)FindFullDeviceInfoAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetDeviceListUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters ;
- (void)GetDeviceListAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters ;
- (void)AddPerformanceCubeResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters ;
- (void)AddPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters ;
- (void)GetPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsForMonoTouchUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters ;
- (void)GetPerformanceCubeResultsForMonoTouchAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsForObjectiveCUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters ;
- (void)GetPerformanceCubeResultsForObjectiveCAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindPerformanceCubeResultUsingParameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters ;
- (void)FindPerformanceCubeResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceMatrixTestResultUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult *)aParameters ;
- (void)AddPerformanceMatrixTestResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceMatrixResultsUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults *)aParameters ;
- (void)GetPerformanceMatrixResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceMatrixResultsForMonoTouchUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch *)aParameters ;
- (void)GetPerformanceMatrixResultsForMonoTouchAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceMatrixResultsForObjectiveCUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC *)aParameters ;
- (void)GetPerformanceMatrixResultsForObjectiveCAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation : NSOperation {
	BasicHttpBinding_IPerformanceTestingDataServiceBinding *binding;
	BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *response;
	id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate> _delegate;
	NSMutableData *responseData;
	NSURLConnection *urlConnection;
}
@property (retain) BasicHttpBinding_IPerformanceTestingDataServiceBinding *binding;
@property (readonly) BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *response;
@property (nonatomic, assign) id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate> delegate;
@property (nonatomic, retain) NSMutableData *responseData;
@property (nonatomic, retain) NSURLConnection *urlConnection;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_AddDevice * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_AddDevice * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_FindDeviceInfo * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_FindDeviceInfo * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_FindFullDeviceInfo * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_FindFullDeviceInfo * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetDeviceList * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetDeviceList * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResult * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_AddPerformanceCubeResult * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResults * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_AddPerformanceCubeResults * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResults * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceCubeResults * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_FindPerformanceCubeResult * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_FindPerformanceCubeResult * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceMatrixTestResult : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_AddPerformanceMatrixTestResult *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceMatrixResults : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResults *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceMatrixResultsForMonoTouch : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForMonoTouch *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceMatrixResultsForObjectiveC : BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation {
	PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC * parameters;
}
@property (retain) PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC * parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
	parameters:(PerformanceTestingDataServiceSvc_GetPerformanceMatrixResultsForObjectiveC *)aParameters
;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope : NSObject {
}
+ (BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *)sharedInstance;
- (NSString *)serializedFormUsingHeaderElements:(NSDictionary *)headerElements bodyElements:(NSDictionary *)bodyElements;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse : NSObject {
	NSArray *headers;
	NSArray *bodyParts;
	NSError *error;
}
@property (retain) NSArray *headers;
@property (retain) NSArray *bodyParts;
@property (retain) NSError *error;
@end
