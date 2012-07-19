//
//  TopMenu.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/14/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "TopMenu.h"
#import "GLPerformanceCube.h"
#import "DeviceInfoViewController.h"
#import "GLCubeResultViewController.h"
#import "ResultData.h"
#import "MatrixTestViewControllerViewController.h"

@interface TopMenu ()

@end

@implementation TopMenu

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
    
    self.title = @"Menu";

    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
 
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (YES);
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 3;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if (section == 0)
    {
        return 3;
    }
    else if (section == 1)
    {
        return 1;
    }
    else if (section == 2)
    {
        return 1;
    }

    return 0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"RootItem1";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    
    if (!cell)
    {
        cell = [[UITableViewCell alloc]initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    if (indexPath.section == 0)
    {
        switch (indexPath.row)
        {
            case 0 :
                cell.textLabel.Text = @"GL Performance Cube";
                break;
            case 1 :
                cell.textLabel.Text = @"Local GL Results";
                break;
            case 2 :
                cell.textLabel.Text = @"Remote GL Results";
                break;
            default:
                break;
        }
    }
    else if (indexPath.section == 1)
    {
        cell.textLabel.text = @"Matrix Test";	
    }
    
    else if (indexPath.section == 2)
    {
        cell.textLabel.text = @"View Device Info";	
    }
    
    return cell;
}

/*
// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
*/

/*
// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        // Delete the row from the data source
        [tableView deleteRowsAtIndexPaths:[NSArray arrayWithObject:indexPath] withRowAnimation:UITableViewRowAnimationFade];
    }   
    else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }   
}
*/

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath
{
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

#pragma mark - Table view delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    
    if (indexPath.section == 0)
    {
        switch (indexPath.row)
        {
            case 0 :
            {
                GLPerformanceCube* newGLCtrl = [[GLPerformanceCube alloc]init];
                [self.navigationController pushViewController:newGLCtrl animated: YES];
                break;
            }
            case 1 :
            {
                GLCubeResultViewController* newGLResultsCtrl = 
                [[GLCubeResultViewController alloc]initWithResults:[ResultData results].glCubeResults];
                [self.navigationController pushViewController:newGLResultsCtrl animated: YES];
                break;
            }
                break;
            case 2 :
            {
                GLCubeResultViewController* newGLResultsCtrl = [GLCubeResultViewController fromRemoteResults];
                [self.navigationController pushViewController:newGLResultsCtrl animated: YES];
                break;
            }
            default:
                break;
        }
    }
    else if (indexPath.section == 1)
    {
        //this.NavigationController.PushViewController (new DeviceInfoViewController (), true);
        
        MatrixTestViewControllerViewController* newCtrl = [[MatrixTestViewControllerViewController alloc]init];
        [self.navigationController pushViewController:newCtrl animated: YES];
    }

    else if (indexPath.section == 2)
    {
        //this.NavigationController.PushViewController (new DeviceInfoViewController (), true);
        
        DeviceInfoViewController* newCtrl = [[DeviceInfoViewController alloc]init];
        [self.navigationController pushViewController:newCtrl animated: YES];
    }
}

@end
