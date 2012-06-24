//
//  GLCubeResults.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/24/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "GLCubeResults.h"

@interface GLCubeResults()
@property (retain, nonatomic) NSMutableArray* items;

@end

@implementation GLCubeResults

@synthesize items;

-(id) init
{
    self = [super init];
    if (self)
    {
        self.items = [[NSMutableArray alloc]init];
    }
    
    return self;
}

-(int)count
{
    return self.items.count;
}

-(GLCubeResult*) getItemAt:(int) index
{
    return [self.items objectAtIndex:index];
}
            
-(void) removeAt:(int) index
{
    [self.items removeObjectAtIndex:index]; 
}

-(void) addResult:(GLCubeResult*) result
{
    [self.items addObject:result];
}

-(void) insert:(GLCubeResult*) result at: (int) index
{
    [self.items insertObject:result atIndex:index];
}

@end
