//
//  ResultCharts.m
//  CPerformanceTesting
//
//  Created by William Holmes on 10/27/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "ResultCharts.h"

@interface ResultCharts ()
{
    UIWebView* _webView;
}
@property (strong, nonatomic) UIWebView* webView;
@end

@implementation ResultCharts

@synthesize webView = _webView;

- (id)init
{
    self = [super init];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
	
    self.webView = [[UIWebView alloc]initWithFrame:self.view.bounds];

    [self.webView loadRequest: [NSURLRequest requestWithURL:[NSURL URLWithString:@"http://apps.slapholmesproductions.com/apps/PerformanceApp/default.aspx"]]];
    self.webView.autoresizingMask = UIViewAutoresizingFlexibleHeight | UIViewAutoresizingFlexibleWidth;
    self.webView.scalesPageToFit = YES;
    self.view.autoresizesSubviews = YES;
    
    [self.view addSubview:self.webView];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)toInterfaceOrientation
{
    return YES;
}

@end
