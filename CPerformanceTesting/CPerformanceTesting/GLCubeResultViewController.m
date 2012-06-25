//
//  GLCubeResultViewController.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "GLCubeResultViewController.h"
#import "DeviceInfo.h"

@interface GLCubeResultViewController ()

@property (retain, atomic) GLCubeResults* results;
@property (nonatomic) BOOL isRemote;

@end

@implementation GLCubeResultViewController

@synthesize results;
@synthesize isRemote;

-(id) initWithResults: (GLCubeResults*) res;
{
    self = [super initWithStyle: UITableViewStyleGrouped];
    if (self) {
        self.isRemote = NO;
        self.results = res;
    }
    return self;
}

-(id) init
{
    self = [super initWithStyle: UITableViewStyleGrouped];
    if (self) {
        self.isRemote = NO;
        self.results = [[GLCubeResults alloc]init];
    }
    return self;
}

+(GLCubeResultViewController*) fromRemoteResults
{
    GLCubeResultViewController* ret = [[GLCubeResultViewController alloc]init];
    ret.isRemote = YES;
    
    BasicHttpBinding_IPerformanceTestingDataServiceBinding* binding = 
    [PerformanceTestingDataServiceSvc BasicHttpBinding_IPerformanceTestingDataServiceBinding];
    binding.logXMLInOut = NO;
    
    PerformanceTestingDataServiceSvc_GetPerformanceCubeResults* params = 
        [[PerformanceTestingDataServiceSvc_GetPerformanceCubeResults alloc]init];
    
    [binding GetPerformanceCubeResultsAsyncUsingParameters:params delegate:ret];
    
    
    return ret;
}

- (void) operation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation completedWithResponse:(BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)response;
{
    NSString* buff;
    // step 1 fill in the blanks.
    for (id mine in response.bodyParts)
    {
        if ([mine isKindOfClass:[SOAPFault class]]) {
            // You can get the error like this:
            buff = ((SOAPFault *)mine).simpleFaultString;
            continue;
        }
        
        if ([mine isKindOfClass:[PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse class]])
        {
            NSMutableArray* arr = 
            ((PerformanceTestingDataServiceSvc_GetPerformanceCubeResultsResponse*)mine).GetPerformanceCubeResultsResult.PerformanceCubeResult;
            
            @synchronized (self.results)
            {
                for (tns1_PerformanceCubeResult* result in arr)
                {
                    GLCubeResult* lRes = 
                    [[GLCubeResult alloc]initWithNumberOfTriangles:result.NumberOfTriangles.intValue framesPerSecond:result.FramesPerSecond.doubleValue];
                    [self.results addResult:lRes];
                }
            }

            [self.tableView performSelectorOnMainThread:@selector(reloadData) withObject:nil waitUntilDone:YES];
        }
        
        if ([mine isKindOfClass:[PerformanceTestingDataServiceSvc_AddPerformanceCubeResultsResponse class]])
        {

        }
    }
}


- (void)viewDidLoad
{
    [super viewDidLoad];

    if (!self.isRemote)
    {
        UIBarButtonItem* editButton = 
            [[UIBarButtonItem alloc]initWithTitle:
            @"Edit" style:UIBarButtonItemStylePlain target:self action:@selector(editButtonClicked:)];
        
        UIBarButtonItem* postButton = 
            [[UIBarButtonItem alloc]initWithTitle:
             @"Post" style:UIBarButtonItemStylePlain target:self action:@selector(postButtonClicked:)];
        
        [self.navigationItem setRightBarButtonItems:[NSArray arrayWithObjects:editButton,postButton,nil] animated:NO];
    }
}
                                       
-(IBAction)editButtonClicked:(id)sender
{
    [self setEditing:!self.editing animated:YES];
    
    if (self.editing)
    {
        self.navigationItem.rightBarButtonItem.title = @"Done";
        self.navigationItem.rightBarButtonItem.style = UIBarButtonItemStyleDone;
        
    }
    else
    {
        self.navigationItem.rightBarButtonItem.title = @"Edit";
        self.navigationItem.rightBarButtonItem.style = UIBarButtonItemStylePlain;
    }
}

-(IBAction)postButtonClicked:(id)sender
{
    BasicHttpBinding_IPerformanceTestingDataServiceBinding* binding = 
    [PerformanceTestingDataServiceSvc BasicHttpBinding_IPerformanceTestingDataServiceBinding];
    binding.logXMLInOut = NO;
    
    tns1_ArrayOfPerformanceCubeResult* lresults = [[tns1_ArrayOfPerformanceCubeResult alloc]init];
    int myDeviceId = [DeviceInfo current].databaseId;
    
    for (int i=0;i<self.results.count;i++)
    {
        GLCubeResult* myResult = [results getItemAt:i];
        
        tns1_PerformanceCubeResult* result = [[tns1_PerformanceCubeResult alloc]init];
        result.DeviceDatabaseId = [[NSNumber alloc]initWithInt: myDeviceId];
        result.FramesPerSecond = [[NSNumber alloc]initWithDouble: myResult.framesPerSecond];
        result.NumberOfTriangles = [[NSNumber alloc]initWithInt: myResult.numberOfTriangles];
        
        [lresults addPerformanceCubeResult:result];
    }
    PerformanceTestingDataServiceSvc_AddPerformanceCubeResults* params = 
    [[PerformanceTestingDataServiceSvc_AddPerformanceCubeResults alloc]init];
    params.results = lresults;
    
    [binding AddPerformanceCubeResultsAsyncUsingParameters:params delegate:self];
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    int ret = 0;
    @synchronized (self.results)
    {
        ret = self.results.count;
    }
    return ret;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell* ret = [tableView dequeueReusableCellWithIdentifier:@"GLCubeResultRow"];
    if (ret == nil) {
        ret = [[UITableViewCell alloc]initWithStyle:UITableViewCellStyleValue1 reuseIdentifier:@"GLCubeResultRow"];
    }
    
    GLCubeResult* result;
    
    @synchronized (self.results)
    {
        result = [self.results getItemAt:indexPath.row];
    }
    
    ret.selectionStyle = UITableViewCellSelectionStyleNone;
    ret.textLabel.text = [NSString stringWithFormat:@"%d triangles", result.numberOfTriangles]; 
    ret.detailTextLabel.text = [NSString stringWithFormat:@"%.2f fps", result.framesPerSecond];
    
    return ret;
}

-(UITableViewCellEditingStyle)tableView:(UITableView *)tableView editingStyleForRowAtIndexPath:(NSIndexPath *)indexPath
{
    // No editing style if not editing or the index path is nil.
    if (!self.editing || indexPath == nil)
        return UITableViewCellEditingStyleNone;
    
    if (self.editing) 
    {
        return UITableViewCellEditingStyleDelete;
    }
    
    return UITableViewCellEditingStyleNone;
}


- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (editingStyle == UITableViewCellEditingStyleDelete) 
    {
        [self.results removeAt:indexPath.row];
        [self.tableView reloadData];
    }
}

- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath
{
    GLCubeResult* result = [self.results getItemAt:fromIndexPath.row];
    [self.results removeAt: fromIndexPath.row];
    [self.results insert:result at:toIndexPath.row];
}

- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}


#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{

}

@end
