#import "PerformanceTestingDataServiceSvc.h"
#import <libxml/xmlstring.h>
#if TARGET_OS_IPHONE
#import <CFNetwork/CFNetwork.h>
#endif
@implementation PerformanceTestingDataServiceSvc_AddDevice
- (id)init
{
	if((self = [super init])) {
		deviceInfo = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(deviceInfo != nil) deviceInfo = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.deviceInfo != 0) {
		xmlAddChild(node, [self.deviceInfo xmlNodeForDoc:node->doc elementName:@"deviceInfo" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize deviceInfo;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddDevice *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddDevice *newObject = [PerformanceTestingDataServiceSvc_AddDevice new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "deviceInfo")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_FullDeviceInfo class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.deviceInfo = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_AddDeviceResponse
- (id)init
{
	if((self = [super init])) {
		AddDeviceResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(AddDeviceResult != nil) AddDeviceResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.AddDeviceResult != 0) {
		xmlAddChild(node, [self.AddDeviceResult xmlNodeForDoc:node->doc elementName:@"AddDeviceResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize AddDeviceResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddDeviceResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddDeviceResponse *newObject = [PerformanceTestingDataServiceSvc_AddDeviceResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "AddDeviceResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [NSNumber  class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.AddDeviceResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindDeviceInfo
- (id)init
{
	if((self = [super init])) {
		databaseId = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(databaseId != nil) databaseId = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.databaseId != 0) {
		xmlAddChild(node, [self.databaseId xmlNodeForDoc:node->doc elementName:@"databaseId" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize databaseId;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindDeviceInfo *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindDeviceInfo *newObject = [PerformanceTestingDataServiceSvc_FindDeviceInfo new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "databaseId")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [NSNumber  class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.databaseId = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindDeviceInfoResponse
- (id)init
{
	if((self = [super init])) {
		FindDeviceInfoResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(FindDeviceInfoResult != nil) FindDeviceInfoResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.FindDeviceInfoResult != 0) {
		xmlAddChild(node, [self.FindDeviceInfoResult xmlNodeForDoc:node->doc elementName:@"FindDeviceInfoResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize FindDeviceInfoResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindDeviceInfoResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindDeviceInfoResponse *newObject = [PerformanceTestingDataServiceSvc_FindDeviceInfoResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "FindDeviceInfoResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_DeviceInfo class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.FindDeviceInfoResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindFullDeviceInfo
- (id)init
{
	if((self = [super init])) {
		uniqueId = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(uniqueId != nil) uniqueId = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.uniqueId != 0) {
		xmlAddChild(node, [self.uniqueId xmlNodeForDoc:node->doc elementName:@"uniqueId" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize uniqueId;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindFullDeviceInfo *newObject = [PerformanceTestingDataServiceSvc_FindFullDeviceInfo new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "uniqueId")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [NSString  class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.uniqueId = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse
- (id)init
{
	if((self = [super init])) {
		FindFullDeviceInfoResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(FindFullDeviceInfoResult != nil) FindFullDeviceInfoResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.FindFullDeviceInfoResult != 0) {
		xmlAddChild(node, [self.FindFullDeviceInfoResult xmlNodeForDoc:node->doc elementName:@"FindFullDeviceInfoResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize FindFullDeviceInfoResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse *newObject = [PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "FindFullDeviceInfoResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_FullDeviceInfo class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.FindFullDeviceInfoResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_GetDeviceList
- (id)init
{
	if((self = [super init])) {
	}
	
	return self;
}
- (void)dealloc
{
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
}
/* elements */
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetDeviceList *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetDeviceList *newObject = [PerformanceTestingDataServiceSvc_GetDeviceList new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
}
@end
@implementation PerformanceTestingDataServiceSvc_GetDeviceListResponse
- (id)init
{
	if((self = [super init])) {
		GetDeviceListResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(GetDeviceListResult != nil) GetDeviceListResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.GetDeviceListResult != 0) {
		xmlAddChild(node, [self.GetDeviceListResult xmlNodeForDoc:node->doc elementName:@"GetDeviceListResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize GetDeviceListResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetDeviceListResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetDeviceListResponse *newObject = [PerformanceTestingDataServiceSvc_GetDeviceListResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "GetDeviceListResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_ArrayOfDeviceInfo class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.GetDeviceListResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_AddPerformanceCubeResult
- (id)init
{
	if((self = [super init])) {
		result = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(result != nil) result = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.result != 0) {
		xmlAddChild(node, [self.result xmlNodeForDoc:node->doc elementName:@"result" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize result;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *newObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResult new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "result")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_PerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.result = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse
- (id)init
{
	if((self = [super init])) {
		AddPerformanceCubeResultResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(AddPerformanceCubeResultResult != nil) AddPerformanceCubeResultResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.AddPerformanceCubeResultResult != 0) {
		xmlAddChild(node, [self.AddPerformanceCubeResultResult xmlNodeForDoc:node->doc elementName:@"AddPerformanceCubeResultResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize AddPerformanceCubeResultResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse *newObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "AddPerformanceCubeResultResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [NSNumber  class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.AddPerformanceCubeResultResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_AddPerformanceCubeResults
- (id)init
{
	if((self = [super init])) {
		results = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(results != nil) results = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.results != 0) {
		xmlAddChild(node, [self.results xmlNodeForDoc:node->doc elementName:@"results" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize results;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *newObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResults new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "results")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_ArrayOfPerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.results = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse
- (id)init
{
	if((self = [super init])) {
	}
	
	return self;
}
- (void)dealloc
{
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
}
/* elements */
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse *newObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResults
- (id)init
{
	if((self = [super init])) {
	}
	
	return self;
}
- (void)dealloc
{
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
}
/* elements */
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResults new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse
- (id)init
{
	if((self = [super init])) {
		GetPerformanceCubeResultsResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(GetPerformanceCubeResultsResult != nil) GetPerformanceCubeResultsResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.GetPerformanceCubeResultsResult != 0) {
		xmlAddChild(node, [self.GetPerformanceCubeResultsResult xmlNodeForDoc:node->doc elementName:@"GetPerformanceCubeResultsResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize GetPerformanceCubeResultsResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "GetPerformanceCubeResultsResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_ArrayOfPerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.GetPerformanceCubeResultsResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch
- (id)init
{
	if((self = [super init])) {
	}
	
	return self;
}
- (void)dealloc
{
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
}
/* elements */
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse
- (id)init
{
	if((self = [super init])) {
		GetPerformanceCubeResultsForMonoTouchResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(GetPerformanceCubeResultsForMonoTouchResult != nil) GetPerformanceCubeResultsForMonoTouchResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.GetPerformanceCubeResultsForMonoTouchResult != 0) {
		xmlAddChild(node, [self.GetPerformanceCubeResultsForMonoTouchResult xmlNodeForDoc:node->doc elementName:@"GetPerformanceCubeResultsForMonoTouchResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize GetPerformanceCubeResultsForMonoTouchResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "GetPerformanceCubeResultsForMonoTouchResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_ArrayOfPerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.GetPerformanceCubeResultsForMonoTouchResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC
- (id)init
{
	if((self = [super init])) {
	}
	
	return self;
}
- (void)dealloc
{
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
}
/* elements */
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
}
@end
@implementation PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse
- (id)init
{
	if((self = [super init])) {
		GetPerformanceCubeResultsForObjectiveCResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(GetPerformanceCubeResultsForObjectiveCResult != nil) GetPerformanceCubeResultsForObjectiveCResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.GetPerformanceCubeResultsForObjectiveCResult != 0) {
		xmlAddChild(node, [self.GetPerformanceCubeResultsForObjectiveCResult xmlNodeForDoc:node->doc elementName:@"GetPerformanceCubeResultsForObjectiveCResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize GetPerformanceCubeResultsForObjectiveCResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse *newObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "GetPerformanceCubeResultsForObjectiveCResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_ArrayOfPerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.GetPerformanceCubeResultsForObjectiveCResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindPerformanceCubeResult
- (id)init
{
	if((self = [super init])) {
		id_ = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(id_ != nil) id_ = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.id_ != 0) {
		xmlAddChild(node, [self.id_ xmlNodeForDoc:node->doc elementName:@"id" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize id_;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *newObject = [PerformanceTestingDataServiceSvc_FindPerformanceCubeResult new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "id")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [NSNumber  class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.id_ = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse
- (id)init
{
	if((self = [super init])) {
		FindPerformanceCubeResultResult = 0;
	}
	
	return self;
}
- (void)dealloc
{
	if(FindPerformanceCubeResultResult != nil) FindPerformanceCubeResultResult = nil;
	
	
}
- (NSString *)nsPrefix
{
	return @"PerformanceTestingDataServiceSvc";
}
- (xmlNodePtr)xmlNodeForDoc:(xmlDocPtr)doc elementName:(NSString *)elName elementNSPrefix:(NSString *)elNSPrefix
{
	NSString *nodeName = nil;
	if(elNSPrefix != nil && [elNSPrefix length] > 0)
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", elNSPrefix, elName];
	}
	else
	{
		nodeName = [NSString stringWithFormat:@"%@:%@", @"PerformanceTestingDataServiceSvc", elName];
	}
	
	xmlNodePtr node = xmlNewDocNode(doc, NULL, [nodeName xmlString], NULL);
	
	
	[self addAttributesToNode:node];
	
	[self addElementsToNode:node];
	
	return node;
}
- (void)addAttributesToNode:(xmlNodePtr)node
{
	
}
- (void)addElementsToNode:(xmlNodePtr)node
{
	
	if(self.FindPerformanceCubeResultResult != 0) {
		xmlAddChild(node, [self.FindPerformanceCubeResultResult xmlNodeForDoc:node->doc elementName:@"FindPerformanceCubeResultResult" elementNSPrefix:@"PerformanceTestingDataServiceSvc"]);
	}
}
/* elements */
@synthesize FindPerformanceCubeResultResult;
/* attributes */
- (NSDictionary *)attributes
{
	NSMutableDictionary *attributes = [NSMutableDictionary dictionary];
	
	return attributes;
}
+ (PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse *)deserializeNode:(xmlNodePtr)cur
{
	PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse *newObject = [PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse new] ;
	
	[newObject deserializeAttributesFromNode:cur];
	[newObject deserializeElementsFromNode:cur];
	
	return newObject;
}
- (void)deserializeAttributesFromNode:(xmlNodePtr)cur
{
}
- (void)deserializeElementsFromNode:(xmlNodePtr)cur
{
	
	
	for( cur = cur->children ; cur != NULL ; cur = cur->next ) {
		if(cur->type == XML_ELEMENT_NODE) {
			xmlChar *elementText = xmlNodeListGetString(cur->doc, cur->children, 1);
			NSString *elementString = nil;
			
			if(elementText != NULL) {
				elementString = [NSString stringWithCString:(char*)elementText encoding:NSUTF8StringEncoding];
				[elementString self]; // avoid compiler warning for unused var
				xmlFree(elementText);
			}
			if(xmlStrEqual(cur->name, (const xmlChar *) "FindPerformanceCubeResultResult")) {
				
				Class elementClass = nil;
				xmlChar *instanceType = xmlGetNsProp(cur, (const xmlChar *) "type", (const xmlChar *) "http://www.w3.org/2001/XMLSchema-instance");
				if(instanceType == NULL) {
					elementClass = [tns1_PerformanceCubeResult class];
				} else {
					NSString *elementTypeString = [NSString stringWithCString:(char*)instanceType encoding:NSUTF8StringEncoding];
					
					NSArray *elementTypeArray = [elementTypeString componentsSeparatedByString:@":"];
					
					NSString *elementClassString = nil;
					if([elementTypeArray count] > 1) {
						NSString *prefix = [elementTypeArray objectAtIndex:0];
						NSString *localName = [elementTypeArray objectAtIndex:1];
						
						xmlNsPtr elementNamespace = xmlSearchNs(cur->doc, cur, [prefix xmlString]);
						
						NSString *standardPrefix = [[USGlobals sharedInstance].wsdlStandardNamespaces objectForKey:[NSString stringWithCString:(char*)elementNamespace->href encoding:NSUTF8StringEncoding]];
						
						elementClassString = [NSString stringWithFormat:@"%@_%@", standardPrefix, localName];
					} else {
						elementClassString = [elementTypeString stringByReplacingOccurrencesOfString:@":" withString:@"_" options:0 range:NSMakeRange(0, [elementTypeString length])];
					}
					
					elementClass = NSClassFromString(elementClassString);
					xmlFree(instanceType);
				}
				
				id newChild = [elementClass deserializeNode:cur];
				
				self.FindPerformanceCubeResultResult = newChild;
			}
		}
	}
}
@end
@implementation PerformanceTestingDataServiceSvc
+ (void)initialize
{
	[[USGlobals sharedInstance].wsdlStandardNamespaces setObject:@"xs" forKey:@"http://www.w3.org/2001/XMLSchema"];
	[[USGlobals sharedInstance].wsdlStandardNamespaces setObject:@"PerformanceTestingDataServiceSvc" forKey:@"http://tempuri.org/"];
	[[USGlobals sharedInstance].wsdlStandardNamespaces setObject:@"ns1" forKey:@"http://tempuri.org/Imports"];
	[[USGlobals sharedInstance].wsdlStandardNamespaces setObject:@"tns1" forKey:@"http://schemas.datacontract.org/2004/07/PerformanceTestingWebApp"];
	[[USGlobals sharedInstance].wsdlStandardNamespaces setObject:@"tns2" forKey:@"http://schemas.microsoft.com/2003/10/Serialization/"];
}
+ (BasicHttpBinding_IPerformanceTestingDataServiceBinding *)BasicHttpBinding_IPerformanceTestingDataServiceBinding
{
	return [[BasicHttpBinding_IPerformanceTestingDataServiceBinding alloc] initWithAddress:@"http://apps.slapholmesproductions.com/apps/PerformanceTesting/Service.svc/basic"] ;
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding
@synthesize address;
@synthesize defaultTimeout;
@synthesize logXMLInOut;
@synthesize cookies;
@synthesize authUsername;
@synthesize authPassword;
- (id)init
{
	if((self = [super init])) {
		address = nil;
		cookies = nil;
		defaultTimeout = 10;//seconds
		logXMLInOut = NO;
		synchronousOperationComplete = NO;
	}
	
	return self;
}
- (id)initWithAddress:(NSString *)anAddress
{
	if((self = [self init])) {
		self.address = [NSURL URLWithString:anAddress];
	}
	
	return self;
}
- (void)addCookie:(NSHTTPCookie *)toAdd
{
	if(toAdd != nil) {
		if(cookies == nil) cookies = [[NSMutableArray alloc] init];
		[cookies addObject:toAdd];
	}
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)performSynchronousOperation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation
{
	synchronousOperationComplete = NO;
	[operation start];
	
	// Now wait for response
	NSRunLoop *theRL = [NSRunLoop currentRunLoop];
	
	while (!synchronousOperationComplete && [theRL runMode:NSDefaultRunLoopMode beforeDate:[NSDate distantFuture]]);
	return operation.response;
}
- (void)performAsynchronousOperation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation
{
	[operation start];
}
- (void) operation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation completedWithResponse:(BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)response
{
	synchronousOperationComplete = YES;
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddDeviceUsingParameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)AddDeviceAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindDeviceInfoUsingParameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)FindDeviceInfoAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindFullDeviceInfoUsingParameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)FindFullDeviceInfoAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetDeviceListUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)GetDeviceListAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)AddPerformanceCubeResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)AddPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)AddPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)GetPerformanceCubeResultsAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsForMonoTouchUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)GetPerformanceCubeResultsForMonoTouchAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)GetPerformanceCubeResultsForObjectiveCUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)GetPerformanceCubeResultsForObjectiveCAsyncUsingParameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)FindPerformanceCubeResultUsingParameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters 
{
	return [self performSynchronousOperation:[(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult alloc] initWithBinding:self delegate:self
																							parameters:aParameters
																							] ];
}
- (void)FindPerformanceCubeResultAsyncUsingParameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters  delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
{
	[self performAsynchronousOperation: [(BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult*)[BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult alloc] initWithBinding:self delegate:responseDelegate
																							 parameters:aParameters
																							 ] ];
}
- (void)sendHTTPCallUsingBody:(NSString *)outputBody soapAction:(NSString *)soapAction forOperation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation
{
	NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:self.address 
																												 cachePolicy:NSURLRequestReloadIgnoringLocalAndRemoteCacheData
																										 timeoutInterval:self.defaultTimeout];
	NSData *bodyData = [outputBody dataUsingEncoding:NSUTF8StringEncoding];
	
	if(cookies != nil) {
		[request setAllHTTPHeaderFields:[NSHTTPCookie requestHeaderFieldsWithCookies:cookies]];
	}
	[request setValue:@"wsdl2objc" forHTTPHeaderField:@"User-Agent"];
	[request setValue:soapAction forHTTPHeaderField:@"SOAPAction"];
	[request setValue:@"text/xml; charset=utf-8" forHTTPHeaderField:@"Content-Type"];
	[request setValue:[NSString stringWithFormat:@"%u", [bodyData length]] forHTTPHeaderField:@"Content-Length"];
	[request setValue:self.address.host forHTTPHeaderField:@"Host"];
	[request setHTTPMethod: @"POST"];
	// set version 1.1 - how?
	[request setHTTPBody: bodyData];
		
	if(self.logXMLInOut) {
		NSLog(@"OutputHeaders:\n%@", [request allHTTPHeaderFields]);
		NSLog(@"OutputBody:\n%@", outputBody);
	}
	
	NSURLConnection *connection = [[NSURLConnection alloc] initWithRequest:request delegate:operation];
	
	operation.urlConnection = connection;
	connection = nil;
}
- (void) dealloc
{
	address = nil;
	cookies = nil;
	
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation
@synthesize binding;
@synthesize response;
@synthesize delegate;
@synthesize responseData;
@synthesize urlConnection;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)aDelegate
{
	if ((self = [super init])) {
		self.binding = aBinding;
		response = nil;
		self.delegate = aDelegate;
		self.responseData = nil;
		self.urlConnection = nil;
	}
	
	return self;
}
-(void)connection:(NSURLConnection *)connection didReceiveAuthenticationChallenge:(NSURLAuthenticationChallenge *)challenge
{
	if ([challenge previousFailureCount] == 0) {
		NSURLCredential *newCredential;
		newCredential=[NSURLCredential credentialWithUser:self.binding.authUsername
												 password:self.binding.authPassword
											  persistence:NSURLCredentialPersistenceForSession];
		[[challenge sender] useCredential:newCredential
			   forAuthenticationChallenge:challenge];
	} else {
		[[challenge sender] cancelAuthenticationChallenge:challenge];
		NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Authentication Error" forKey:NSLocalizedDescriptionKey];
		NSError *authError = [NSError errorWithDomain:@"Connection Authentication" code:0 userInfo:userInfo];
		[self connection:connection didFailWithError:authError];
	}
}
- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)urlResponse
{
	NSHTTPURLResponse *httpResponse;
	if ([urlResponse isKindOfClass:[NSHTTPURLResponse class]]) {
		httpResponse = (NSHTTPURLResponse *) urlResponse;
	} else {
		httpResponse = nil;
	}
	
	if(binding.logXMLInOut) {
		NSLog(@"ResponseStatus: %u\n", [httpResponse statusCode]);
		NSLog(@"ResponseHeaders:\n%@", [httpResponse allHeaderFields]);
	}
	
	NSMutableArray *cookies = [[NSHTTPCookie cookiesWithResponseHeaderFields:[httpResponse allHeaderFields] forURL:binding.address] mutableCopy];
	
	binding.cookies = cookies;
	cookies = nil;
    if ([urlResponse.MIMEType rangeOfString:@"text/xml"].length == 0) {
		NSError *error = nil;
		[connection cancel];
		if ([httpResponse statusCode] >= 400) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:[NSHTTPURLResponse localizedStringForStatusCode:[httpResponse statusCode]] forKey:NSLocalizedDescriptionKey];
				
			error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseHTTP" code:[httpResponse statusCode] userInfo:userInfo];
		} else {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:
																[NSString stringWithFormat: @"Unexpected response MIME type to SOAP call:%@", urlResponse.MIMEType]
																													 forKey:NSLocalizedDescriptionKey];
			error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseHTTP" code:1 userInfo:userInfo];
		}
				
		[self connection:connection didFailWithError:error];
  }
}
- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data
{
  if (responseData == nil) {
		responseData = [data mutableCopy];
	} else {
		[responseData appendData:data];
	}
}
- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error
{
	if (binding.logXMLInOut) {
		NSLog(@"ResponseError:\n%@", error);
	}
	response.error = error;
	[delegate operation:self completedWithResponse:response];
}
- (void)dealloc
{
	binding = nil;
	response = nil;
	delegate = nil;
	responseData = nil;
	urlConnection = nil;
	
	
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddDevice
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_AddDevice *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{

	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"AddDevice"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/AddDevice" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "AddDeviceResponse")) {
									PerformanceTestingDataServiceSvc_AddDeviceResponse *bodyObject = [PerformanceTestingDataServiceSvc_AddDeviceResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindDeviceInfo
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_FindDeviceInfo *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{

	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"FindDeviceInfo"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/FindDeviceInfo" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "FindDeviceInfoResponse")) {
									PerformanceTestingDataServiceSvc_FindDeviceInfoResponse *bodyObject = [PerformanceTestingDataServiceSvc_FindDeviceInfoResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindFullDeviceInfo
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_FindFullDeviceInfo *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{

	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"FindFullDeviceInfo"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/FindFullDeviceInfo" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding ]);
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "FindFullDeviceInfoResponse")) {
									PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse *bodyObject = [PerformanceTestingDataServiceSvc_FindFullDeviceInfoResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetDeviceList
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_GetDeviceList *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"GetDeviceList"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/GetDeviceList" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "GetDeviceListResponse")) {
									PerformanceTestingDataServiceSvc_GetDeviceListResponse *bodyObject = [PerformanceTestingDataServiceSvc_GetDeviceListResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResult
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResult *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"AddPerformanceCubeResult"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResult" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "AddPerformanceCubeResultResponse")) {
									PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse *bodyObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResultResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_AddPerformanceCubeResults
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_AddPerformanceCubeResults *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"AddPerformanceCubeResults"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/AddPerformanceCubeResults" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "AddPerformanceCubeResultsResponse")) {
									PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse *bodyObject = [PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResults
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResults *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"GetPerformanceCubeResults"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResults" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "GetPerformanceCubeResultsResponse")) {
									PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse *bodyObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForMonoTouch
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouch *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"GetPerformanceCubeResultsForMonoTouch"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForMonoTouch" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "GetPerformanceCubeResultsForMonoTouchResponse")) {
									PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse *bodyObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForMonoTouchResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_GetPerformanceCubeResultsForObjectiveC
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveC *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"GetPerformanceCubeResultsForObjectiveC"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/GetPerformanceCubeResultsForObjectiveC" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "GetPerformanceCubeResultsForObjectiveCResponse")) {
									PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse *bodyObject = [PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsForObjectiveCResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_FindPerformanceCubeResult
@synthesize parameters;
- (id)initWithBinding:(BasicHttpBinding_IPerformanceTestingDataServiceBinding *)aBinding delegate:(id<BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseDelegate>)responseDelegate
parameters:(PerformanceTestingDataServiceSvc_FindPerformanceCubeResult *)aParameters
{
	if((self = [super initWithBinding:aBinding delegate:responseDelegate])) {
		self.parameters = aParameters;
	}
	
	return self;
}
- (void)dealloc
{
	if(parameters != nil) parameters = nil;
	
	
}
- (void)main
{
	response = [BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse new];
	
	BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *envelope = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope sharedInstance];
	
	NSMutableDictionary *headerElements = nil;
	headerElements = [NSMutableDictionary dictionary];
	
	NSMutableDictionary *bodyElements = nil;
	bodyElements = [NSMutableDictionary dictionary];
	if(parameters != nil) [bodyElements setObject:parameters forKey:@"FindPerformanceCubeResult"];
	
	NSString *operationXMLString = [envelope serializedFormUsingHeaderElements:headerElements bodyElements:bodyElements];
	
	[binding sendHTTPCallUsingBody:operationXMLString soapAction:@"http://tempuri.org/IPerformanceTestingDataService/FindPerformanceCubeResult" forOperation:self];
}
- (void)connectionDidFinishLoading:(NSURLConnection *)connection
{
	if (responseData != nil && self.delegate != nil)
	{
		xmlDocPtr doc;
		xmlNodePtr cur;
		
		if (binding.logXMLInOut) {
			NSLog(@"ResponseBody:\n%@", [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding] );
		}
		
		doc = xmlParseMemory([responseData bytes], [responseData length]);
		
		if (doc == NULL) {
			NSDictionary *userInfo = [NSDictionary dictionaryWithObject:@"Errors while parsing returned XML" forKey:NSLocalizedDescriptionKey];
			
			response.error = [NSError errorWithDomain:@"BasicHttpBinding_IPerformanceTestingDataServiceBindingResponseXML" code:1 userInfo:userInfo];
			[self.delegate operation:self completedWithResponse:response];
		} else {
			cur = xmlDocGetRootElement(doc);
			cur = cur->children;
			
			for( ; cur != NULL ; cur = cur->next) {
				if(cur->type == XML_ELEMENT_NODE) {
					
					if(xmlStrEqual(cur->name, (const xmlChar *) "Body")) {
						NSMutableArray *responseBodyParts = [NSMutableArray array];
						
						xmlNodePtr bodyNode;
						for(bodyNode=cur->children ; bodyNode != NULL ; bodyNode = bodyNode->next) {
							if(cur->type == XML_ELEMENT_NODE) {
								if(xmlStrEqual(bodyNode->name, (const xmlChar *) "FindPerformanceCubeResultResponse")) {
									PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse *bodyObject = [PerformanceTestingDataServiceSvc_FindPerformanceCubeResultResponse deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
								if (xmlStrEqual(bodyNode->ns->prefix, cur->ns->prefix) && 
									xmlStrEqual(bodyNode->name, (const xmlChar *) "Fault")) {
									SOAPFault *bodyObject = [SOAPFault deserializeNode:bodyNode];
									//NSAssert1(bodyObject != nil, @"Errors while parsing body %s", bodyNode->name);
									if (bodyObject != nil) [responseBodyParts addObject:bodyObject];
								}
							}
						}
						
						response.bodyParts = responseBodyParts;
					}
				}
			}
			
			xmlFreeDoc(doc);
		}
		
		xmlCleanupParser();
		[self.delegate operation:self completedWithResponse:response];
	}
}
@end
static BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *BasicHttpBinding_IPerformanceTestingDataServiceBindingSharedEnvelopeInstance = nil;
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope
+ (BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope *)sharedInstance
{
	if(BasicHttpBinding_IPerformanceTestingDataServiceBindingSharedEnvelopeInstance == nil) {
		BasicHttpBinding_IPerformanceTestingDataServiceBindingSharedEnvelopeInstance = [BasicHttpBinding_IPerformanceTestingDataServiceBinding_envelope new];
	}
	
	return BasicHttpBinding_IPerformanceTestingDataServiceBindingSharedEnvelopeInstance;
}
- (NSString *)serializedFormUsingHeaderElements:(NSDictionary *)headerElements bodyElements:(NSDictionary *)bodyElements
{
    xmlDocPtr doc;
	
	doc = xmlNewDoc((const xmlChar*)XML_DEFAULT_VERSION);
	if (doc == NULL) {
		NSLog(@"Error creating the xml document tree");
		return @"";
	}
	
	xmlNodePtr root = xmlNewDocNode(doc, NULL, (const xmlChar*)"Envelope", NULL);
	xmlDocSetRootElement(doc, root);
	
	xmlNsPtr soapEnvelopeNs = xmlNewNs(root, (const xmlChar*)"http://schemas.xmlsoap.org/soap/envelope/", (const xmlChar*)"soap");
	xmlSetNs(root, soapEnvelopeNs);
	
	xmlNsPtr xslNs = xmlNewNs(root, (const xmlChar*)"http://www.w3.org/1999/XSL/Transform", (const xmlChar*)"xsl");
	xmlNewNs(root, (const xmlChar*)"http://www.w3.org/2001/XMLSchema-instance", (const xmlChar*)"xsi");
	
	xmlNewNsProp(root, xslNs, (const xmlChar*)"version", (const xmlChar*)"1.0");
	
	xmlNewNs(root, (const xmlChar*)"http://www.w3.org/2001/XMLSchema", (const xmlChar*)"xs");
	xmlNewNs(root, (const xmlChar*)"http://tempuri.org/", (const xmlChar*)"PerformanceTestingDataServiceSvc");
	xmlNewNs(root, (const xmlChar*)"http://tempuri.org/Imports", (const xmlChar*)"ns1");
	xmlNewNs(root, (const xmlChar*)"http://schemas.datacontract.org/2004/07/PerformanceTestingWebApp", (const xmlChar*)"tns1");
	xmlNewNs(root, (const xmlChar*)"http://schemas.microsoft.com/2003/10/Serialization/", (const xmlChar*)"tns2");
	
	if((headerElements != nil) && ([headerElements count] > 0)) {
		xmlNodePtr headerNode = xmlNewDocNode(doc, soapEnvelopeNs, (const xmlChar*)"Header", NULL);
		xmlAddChild(root, headerNode);
		
		for(NSString *key in [headerElements allKeys]) {
			id header = [headerElements objectForKey:key];
			xmlAddChild(headerNode, [header xmlNodeForDoc:doc elementName:key elementNSPrefix:nil]);
		}
	}
	
	if((bodyElements != nil) && ([bodyElements count] > 0)) {
		xmlNodePtr bodyNode = xmlNewDocNode(doc, soapEnvelopeNs, (const xmlChar*)"Body", NULL);
		xmlAddChild(root, bodyNode);
		
		for(NSString *key in [bodyElements allKeys]) {
			id body = [bodyElements objectForKey:key];
			xmlAddChild(bodyNode, [body xmlNodeForDoc:doc elementName:key elementNSPrefix:nil]);
		}
	}
	
	xmlChar *buf;
	int size;
	xmlDocDumpFormatMemory(doc, &buf, &size, 1);
	
	NSString *serializedForm = [NSString stringWithCString:(const char*)buf encoding:NSUTF8StringEncoding];
	xmlFree(buf);
	
	xmlFreeDoc(doc);	
	return serializedForm;
}
@end
@implementation BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse
@synthesize headers;
@synthesize bodyParts;
@synthesize error;
- (id)init
{
	if((self = [super init])) {
		headers = nil;
		bodyParts = nil;
		error = nil;
	}
	
	return self;
}
-(void)dealloc {
    self.headers = nil;
    self.bodyParts = nil;
    self.error = nil;	
    
}
@end
