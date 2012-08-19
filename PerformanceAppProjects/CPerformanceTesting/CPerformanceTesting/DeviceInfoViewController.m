//
//  DeviceInfoViewController.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/23/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "DeviceInfoViewController.h"
#import "DeviceInfo.h"
#import "TextEditCell.h"

@interface DeviceInfoViewController ()

@end

@implementation DeviceInfoViewController

- (id)init
{
    self = [super initWithStyle:UITableViewStyleGrouped];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];

    UIBarButtonItem* registerButton = 
    [[UIBarButtonItem alloc] initWithTitle:@"Register" style:UIBarButtonItemStylePlain target:self action:@selector(registerButtonClicked:)];
    
    self.navigationItem.rightBarButtonItem = registerButton;
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return YES;
}

-(IBAction)registerButtonClicked:(id)sender
{
    BasicHttpBinding_IPerformanceTestingDataServiceBinding* binding = 
    [PerformanceTestingDataServiceSvc BasicHttpBinding_IPerformanceTestingDataServiceBinding];
    binding.logXMLInOut = NO;
    
    PerformanceTestingDataServiceSvc_AddDevice* params = [[PerformanceTestingDataServiceSvc_AddDevice alloc]init];
    params.deviceInfo = [[tns1_FullDeviceInfo alloc]init];
    
    params.deviceInfo.UniqueId = [DeviceInfo current].uniqueId;
    params.deviceInfo.OSName = [DeviceInfo current].osName;
    params.deviceInfo.OSVersion = [DeviceInfo current].osVersion;
    params.deviceInfo.ModelName = [DeviceInfo current].modelName;
    params.deviceInfo.SpecificHWVersion = [DeviceInfo current].specificHWVersion;
    params.deviceInfo.UIIdion = [DeviceInfo current].uiIdion;
    params.deviceInfo.SystemName = [DeviceInfo current].deviceName;
    params.deviceInfo.OwnerName = [DeviceInfo current].ownerName;    
    
    [binding AddDeviceAsyncUsingParameters:params delegate:self];
}

- (void) operation:(BasicHttpBinding_IPerformanceTestingDataServiceBindingOperation *)operation completedWithResponse:(BasicHttpBinding_IPerformanceTestingDataServiceBindingResponse *)response;
{
    // step 1 fill in the blanks.
    for (id mine in response.bodyParts)
    {
        if ([mine isKindOfClass:[PerformanceTestingDataServiceSvc_AddDeviceResponse class]])
        {
            [DeviceInfo current].databaseId = [[mine AddDeviceResult] intValue];
        }
    }
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    // Return the number of rows in the section.
    return 6;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *ret = nil;
    
    if (indexPath.row < 5)
    {
        ret = [tableView dequeueReusableCellWithIdentifier:@"RootItem1"];
        
        if (ret == nil) 
        {
            ret = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleValue1 reuseIdentifier:@"RootItem1" ];
            ret.selectionStyle = UITableViewCellSelectionStyleNone;
        }
        
        switch (indexPath.row)
        {
            case 0:
                ret.textLabel.text = @"Device Name";
                ret.detailTextLabel.text = DeviceInfo.current.deviceName ;
                break;
            case 1:
                ret.textLabel.text = @"OS Name";
                ret.detailTextLabel.text = DeviceInfo.current.osName;
                break;
            case 2:
                ret.textLabel.text = @"OS Version";
                ret.detailTextLabel.text = DeviceInfo.current.osVersion;
                break;
            case 3:
                ret.textLabel.text = @"Model Name";
                ret.detailTextLabel.text = DeviceInfo.current.modelName;
                break;
            case 4:
                ret.textLabel.text = @"Model Id";
                ret.detailTextLabel.text = DeviceInfo.current.specificHWVersion;
                break;
            case 5:
                ret.textLabel.text = @"Owner Name";
                ret.detailTextLabel.text = DeviceInfo.current.ownerName;
                break;
                
            default:
                break;
        }
    }
    else
    {
        TextEditCell* txtCell = [tableView dequeueReusableCellWithIdentifier: @"RootItem2"];
        if (txtCell == nil) 
        {
            txtCell = [[TextEditCell alloc]initWithReuseIdentifier:@"RootItem2"];
        }	
        
        txtCell.textLabel.text = @"Owner Name";
        
        txtCell.textField.text = [DeviceInfo current].ownerName;
        ret = txtCell;
    }
    
    return ret;
}

#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Navigation logic may go here. Create and push another view controller.
    /*
     <#DetailViewController#> *detailViewController = [[<#DetailViewController#> alloc] initWithNibName:@"<#Nib name#>" bundle:nil];
     // ...
     // Pass the selected object to the new view controller.
     [self.navigationController pushViewController:detailViewController animated:YES];
     */
}

@end
