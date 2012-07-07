//
//  TextEditCellCell.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/23/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "TextEditCell.h"
#import "DeviceInfo.h"

@implementation TextEditCell

@synthesize textField;

- (id)initWithReuseIdentifier:(NSString *)identifier
{
    self = [super initWithStyle:UITableViewCellStyleValue1 reuseIdentifier:identifier];
    if (self) {
        self.selectionStyle = UITableViewCellSelectionStyleNone;
        
        CGRect rect = {150, 10, 160, 30};
        textField = [[UITextField alloc]initWithFrame:rect];
        textField.adjustsFontSizeToFitWidth = YES;
        textField.textColor = [UIColor blackColor];
        textField.placeholder = @"enter name";
        textField.keyboardType = UIKeyboardTypeDefault;
        textField.returnKeyType = UIReturnKeyDone;
        
        textField.backgroundColor = [UIColor clearColor];
        textField.autocorrectionType = UITextAutocorrectionTypeNo; // no auto correction support
        textField.autocapitalizationType = UITextAutocapitalizationTypeNone; // no auto capitalization support
        textField.textAlignment = UITextAlignmentRight;
        textField.tag = 0;
        textField.delegate = self;
        textField.autoresizingMask = UIViewAutoresizingFlexibleWidth;
        
        textField.clearButtonMode = UITextFieldViewModeNever; // no clear 'x' button to the right
        textField.enabled= YES;
        textField.font = self.detailTextLabel.font;
        
        [self addSubview: textField];
    }
    return self;
}

-(void) layoutSubviews
{
    [super layoutSubviews];
    UIView* sView = [self.subviews objectAtIndex:0];
    
    float x = sView.frame.origin.x + self.textLabel.frame.origin.x;
    
    CGRect rect = self.textLabel.bounds;
    
    rect.origin.x = x + rect.size.width + 10;
    rect.size.width = self.bounds.size.width - (rect.origin.x + x);
    rect.origin.y = 10; rect.size.height = 30;
    
    textField.frame = rect;
    textField.font = self.detailTextLabel.font;
    textField.textColor = self.detailTextLabel.textColor;
}

- (void)textFieldDidEndEditing:(UITextField *)ltextField
{
    [DeviceInfo current].ownerName = textField.text;
}

- (BOOL)textFieldShouldReturn:(UITextField *)ltextField
{
    [textField resignFirstResponder];
    return NO;
}

@end
