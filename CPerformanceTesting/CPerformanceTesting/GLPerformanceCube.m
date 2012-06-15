//
//  GLPerformanceCube.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/14/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "GLPerformanceCube.h"

@interface GLPerformanceCube ()

@end

@implementation GLPerformanceCube

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

@end
