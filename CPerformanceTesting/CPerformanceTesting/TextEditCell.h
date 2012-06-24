//
//  TextEditCellCell.h
//  CPerformanceTesting
//
//  Created by William Holmes on 6/23/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface TextEditCell : UITableViewCell <UITextFieldDelegate>

@property (strong, nonatomic) UITextField* textField;
- (id)initWithReuseIdentifier:(NSString *)identifier;

@end
