//
//  MatrixTestViewControllerViewController.m
//  CPerformanceTesting
//
//  Created by William Holmes on 7/18/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "MatrixTestViewControllerViewController.h"
#import "MatrixTest.h"
#import "MatrixTestEngine.h"

@interface MatrixTestViewControllerViewController ()

@property (strong, nonatomic) UIButton* runButton;

@property (strong, nonatomic) MatrixTest* cOnlyTest;
@property (strong, nonatomic) MatrixTest* blasTest;

@end

@implementation MatrixTestViewControllerViewController

@synthesize runButton;
@synthesize cOnlyTest;
@synthesize blasTest;

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

    [self setTitle:@"Matrix Test"];
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

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    if (self.blasTest)
        return 3;
    if (self.cOnlyTest)
        return 2;
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    if ((section == 1 && self.cOnlyTest) || (section == 2 && self.blasTest))
        return 5;
    
    return 0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"RootItem1";
    UITableViewCell* ret;
    
    MatrixTest* currentTest = indexPath.section == 1 ? self.cOnlyTest:self.blasTest;
    
    if (indexPath.row < 5)
    {
        ret = [tableView dequeueReusableCellWithIdentifier: CellIdentifier];
        
        if (ret == nil) 
        {
            ret = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleValue1 reuseIdentifier:CellIdentifier];
            ret.SelectionStyle = UITableViewCellSelectionStyleNone;
        }
        
        switch (indexPath.row)
        {
            case 0:
                ret.textLabel.text = @"Matrix Size";
                ret.detailTextLabel.text = [NSString stringWithFormat:@"%d", currentTest.matrixSize];
                break;
            case 1:
                ret.textLabel.text = @"Iterations";
                ret.detailTextLabel.text = [NSString stringWithFormat:@"%d", currentTest.iterations];                    break;
            case 2:
                ret.textLabel.text = @"MFlops";
                ret.detailTextLabel.text = [NSString stringWithFormat:@"%.3f", currentTest.mFlops];
                break;
            case 3:
                ret.textLabel.text = @"Time";
                ret.detailTextLabel.text = [NSString stringWithFormat:@"%.3f", currentTest.seconds];
                break;
            case 4:
                ret.textLabel.text = @"MFlops/Second";
                ret.detailTextLabel.text = [NSString stringWithFormat:@"%.3f", currentTest.mFlopsPerSecond];
                break;
        }
    }

    return ret;
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
{
    switch (section)
    {
        case 1:
            return @"Objective C Result";
        case 2:
            return @"BLAS Result";
    }
    
    return nil;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section
{
    return 44;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section
{
    if (section == 0)
    {
        CGRect rect = {0, 0, 300, 45};
        UIView* view = [[UIView alloc] initWithFrame:rect];
        runButton = [UIButton buttonWithType:UIButtonTypeRoundedRect];
        CGRect rect2 = {10, 10, 100, 35};
        runButton.frame = rect2;        
        runButton.autoresizingMask = UIViewAutoresizingFlexibleRightMargin;
        [runButton setTitle:@"Run" forState:UIControlStateNormal];
        [runButton addTarget:self action:@selector(touchRunButton:) forControlEvents:UIControlEventTouchUpInside];
        
        view.backgroundColor = [UIColor clearColor];
        [view addSubview:runButton];
        
        return view;
    }
    
    return nil;
}

-(IBAction)touchRunButton:(id)sender
{
     if([[runButton titleForState:UIControlStateNormal] isEqualToString:@"Running"])
        return;
    
    [runButton setTitle:@"Running" forState:UIControlStateNormal];
    
    [UIApplication sharedApplication].idleTimerDisabled = YES;
    
    [NSThread detachNewThreadSelector:@selector(runTestMethod:) toTarget:self withObject:nil];
}

-(IBAction)runTestMethod:(id)obj
{
    MatrixTestEngine* engine = [[MatrixTestEngine alloc]init];
    self.cOnlyTest = [engine runCTest:NO];
    self.blasTest = [engine runCTest:YES];
    
    [self performSelectorOnMainThread:@selector(finishRunTestMethod:) withObject:nil waitUntilDone:YES];
}

-(IBAction)finishRunTestMethod:(id)obj
{
    [self.tableView reloadData];
    [runButton setTitle:@"Run" forState:UIControlStateNormal];
    [UIApplication sharedApplication].idleTimerDisabled = NO;
}

@end
