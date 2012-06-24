#import <Foundation/Foundation.h>
#import "USAdditions.h"
#import <libxml/tree.h>
#import "USGlobals.h"
@class PerformanceTestingDataServiceSvc_AddDevice;
@class PerformanceTestingDataServiceSvc_AddDeviceResponse;
@class PerformanceTestingDataServiceSvc_FindDeviceInfo;
@class PerformanceTestingDataServiceSvc_FindDeviceInfoResponse;
@class PerformanceTestingDataServiceSvc_GetDeviceList;
@class PerformanceTestingDataServiceSvc_GetDeviceListResponse;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResult;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResults;
@class PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResults;
@class PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse;
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
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetDeviceListUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters ;
- (void)GetDeviceListAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters ;
- (void)AddPerformanceCubeResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters ;
- (void)AddPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters ;
- (void)GetPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate;
@end
@interface BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation : NSOperation {
	BasicHttpBinding_IPerformanceTestingDataServiceBinding *binding;
	BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *response;
	//id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate> delegate;
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
