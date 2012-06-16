//
//  GLPerformanceCube.m
//  CPerformanceTesting
//
//  Created by William Holmes on 6/14/12.
//  Copyright (c) 2012 Slap Holmes Productions. All rights reserved.
//

#import "GLPerformanceCube.h"
#import <GLKit/GLKit.h>
#import <OpenGLES/EAGL.h>
#include <sys/time.h>

@interface GLPerformanceCube ()
{
    int _triangles;
    GLKMatrix4 _modelMatrix; 
    
    GLuint* _vertexBuffers;
    CGPoint _previousLocation;
}

@property (strong, nonatomic) GLKView *glview;
@property (strong, nonatomic) GLKBaseEffect* effect;

@property (strong, nonatomic) UILabel *fpLabel; 
@property (strong, nonatomic) UILabel *numTrisLabel; 
@property (strong, nonatomic) UIStepper *numTrisStepper;

-(void) sizeGLView;

@end

@implementation GLPerformanceCube 


@synthesize glview = _glview;
@synthesize effect = _effect;

@synthesize fpLabel = _fpLabel; 
@synthesize numTrisLabel = _numTrisLabel; 
@synthesize numTrisStepper = _numTrisStepper;

- (id)init
{
    self = [super init];
    if (self) {
        // Custom initialization
        _modelMatrix = GLKMatrix4Identity;
        _vertexBuffers = NULL;
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.title = @"GL Performance Cube";
    
    UIBarButtonItem* testButton = 
    [[UIBarButtonItem alloc] initWithTitle:@"Test" style:UIBarButtonItemStyleBordered target:self action:@selector(testButtonClicked:)];
    
    self.navigationItem.rightBarButtonItem = testButton;
    
    [self setupGLView];
    
    CGRect rect = self.view.bounds;
    rect.origin.x = 10; rect.size.width -= 20;
    rect.origin.y = rect.size.height - 35; rect.size.height = 25;
    
    self.numTrisLabel = [[UILabel alloc]initWithFrame:rect];
    self.numTrisLabel.text = [NSString stringWithFormat:@"triangles = %d", ((_triangles) / 3)];
    self.numTrisLabel.backgroundColor = [UIColor clearColor];
    self.numTrisLabel.textColor = [UIColor whiteColor];
    self.numTrisLabel.autoresizingMask = UIViewAutoresizingFlexibleTopMargin;
    [self.view addSubview:self.numTrisLabel];
    
    self.numTrisStepper = [[UIStepper alloc]initWithFrame:rect];
    self.numTrisStepper.autoresizingMask = UIViewAutoresizingFlexibleTopMargin |
                                            UIViewAutoresizingFlexibleLeftMargin;
    self.numTrisStepper.minimumValue = 0;    
    rect.origin.x = rect.size.width - self.numTrisStepper.bounds.size.width;
    
    self.numTrisStepper.frame = rect;
    [self.numTrisStepper addTarget:self action:@selector(HandleNumTrisStepperChanged:) forControlEvents:UIControlEventValueChanged];
    [self.view addSubview:self.numTrisStepper];
    
    rect.origin.x = 10; rect.origin.y -= 35;
    self.fpLabel = [[UILabel alloc]initWithFrame:rect];
    self.fpLabel.backgroundColor = [UIColor clearColor];
    self.fpLabel.textColor = [UIColor whiteColor];
    self.fpLabel.autoresizingMask = UIViewAutoresizingFlexibleTopMargin;
    [self.view addSubview:self.fpLabel];

}

- (void)viewDidUnload
{
    [super viewDidUnload];
    self.fpLabel = nil;
    self.numTrisLabel = nil;
    self.numTrisStepper = nil;
    self.glview = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (YES);
}
                                   
-(IBAction)testButtonClicked:(id)sender
{
    struct timeval startTime, endTime;
    gettimeofday(&startTime, NULL); 
    int count = 0;
    long elapsed_seconds, elapsed_useconds;
    
    elapsed_seconds = 0;
    
    while (elapsed_seconds < 10)
    {
        _modelMatrix = GLKMatrix4Multiply(GLKMatrix4MakeYRotation(0.05f), _modelMatrix);
        [self.glview display];
        count++;
        gettimeofday(&endTime, NULL);
        
        elapsed_seconds  = endTime.tv_sec  - startTime.tv_sec;
    }
    
    elapsed_useconds = endTime.tv_usec - startTime.tv_usec;
    double totalTime = ((double)elapsed_seconds) + (((double)elapsed_useconds)/1000000);
    double fps = ((double)count)/totalTime;
    self.fpLabel.text = [NSString stringWithFormat:@"fps = %g", fps];
    //self.fpsLabel.text = [NSString stringWithFormat:@"%g fps", fps];
}
     
-(IBAction)HandleNumTrisStepperChanged:(id)sender
{
    int value = (int)self.numTrisStepper.value;
    if (value == 0)
        value = 1;
    else
        value *= 10;
    
    [self createBuffers: value];
    [self.glview display];
}

- (void) setupGLView
{
    // Craete a new context if needed
    if (!EAGLContext.currentContext)
        EAGLContext.currentContext = [[EAGLContext alloc]initWithAPI:kEAGLRenderingAPIOpenGLES2];
    
    self.glview = [[GLKView alloc]initWithFrame:self.view.bounds];
    self.glview.context = EAGLContext.currentContext;
    self.glview.delegate = self;
    [self.view addSubview:self.glview];
    
    self.effect = [[GLKBaseEffect alloc]init];
    self.effect.light0.position =  (GLKVector4){5.0f, 5.0f, 5.0f, 1.0f};
    self.effect.light0.enabled = YES;
    
    glEnable(GL_CULL_FACE);
    
    [self sizeGLView];
    
    _modelMatrix = GLKMatrix4Rotate(GLKMatrix4Identity, M_PI / 5.0f, 1, 0, 0);
    //_modelMatrix = GLKMatrix4Identity;
    self.effect.transform.modelviewMatrix = _modelMatrix;
    
    [self createBuffers:1];
}

- (void)viewDidLayoutSubviews
{
    [super viewDidLayoutSubviews];
    self.glview.frame = self.view.bounds;
    [self sizeGLView ];
}

-(void) sizeGLView
{
    float aspect = self.glview.bounds.size.height / self.glview.bounds.size.width;
    float worldBounds = 2;
    glViewport (0, 0, (int)self.glview.bounds.size.width, (int)self.glview.bounds.size.height);
    
    if (aspect > 1.0f)
    {
        self.effect.transform.projectionMatrix = 
            GLKMatrix4MakeOrtho (-worldBounds, worldBounds, -worldBounds * aspect, worldBounds * aspect, -worldBounds, worldBounds);
    }
    else 
    {
        aspect = 1.0f / aspect;
        self.effect.transform.projectionMatrix = 
            GLKMatrix4MakeOrtho (-worldBounds * aspect, worldBounds * aspect, -worldBounds, worldBounds, -worldBounds, worldBounds);
    }
    
    [self.glview display];
}

void fillNormals (float* normals, float x, float y, float z, int index, int length)
{
    for (int i=0; i<length; i+=3, index+=3)
    {
        normals [index] = x;
        normals [index+1] = y;
        normals [index+2] = z;
    }
}

void transformFace (float* base1, GLKMatrix4 trans, float* target1, int length, int targetstart)
{
    int j = targetstart;
    for (int i=0; i<length; i+=3, j+=3)
    {
        float x = base1[i] * trans.m00 + base1[i+1] * trans.m10 + base1[i+2] * trans.m20 + 1 * trans.m30;
        float y = base1[i] * trans.m01 + base1[i+1] * trans.m11 + base1[i+2] * trans.m21 + 1 * trans.m31;
        float z = base1[i] * trans.m02 + base1[i+1] * trans.m12 + base1[i+2] * trans.m22 + 1 * trans.m32;
        target1[j] = x;
        target1[j+1] = y;
        target1[j+2] = z;
    }
}

- (void)createBuffers:(int)segments
{
    if (!_vertexBuffers)
    {
        _vertexBuffers = (GLuint*)malloc(sizeof(GLuint)*2);
    }
    else
    {
        glDeleteBuffers (2, _vertexBuffers);	
    }
    
    _triangles = segments * segments * 6 * 6;
    int trisPerFace = segments * segments;
    float* verticies = (float*)malloc(sizeof(float) * _triangles * 3);
    float* normals = (float*)malloc(sizeof(float) * _triangles * 3);
    
    verticies[0] = -1; verticies[1] = -1; verticies[2] = 0;
    verticies[3] =  1; verticies[4] = -1; verticies[5] = 0;
    verticies[6] = -1; verticies[7] =  1; verticies[8] = 0;
    
    verticies[ 9] = -1; verticies[10] =  1; verticies[11] = 0;
    verticies[12] =  1; verticies[13] = -1; verticies[14] = 0;
    verticies[15] =  1; verticies[16] =  1; verticies[17] = 0;
    
    float incr = 2.0f / (float)segments;
    float startPt = -1 + (incr / 2.0f);
    int index = 18;
    
    GLKMatrix4 trans = GLKMatrix4MakeTranslation(startPt, startPt, 1);
    trans = GLKMatrix4Multiply (trans, GLKMatrix4MakeScale(1.0f/(float)segments, 1.0f/(float)segments, 1.0f/(float)segments));
    transformFace (verticies, trans, verticies, 18, 0);
    
    trans = GLKMatrix4Identity;
    
    for (int i=1; i<segments; i++)
    {
        trans = GLKMatrix4Multiply (GLKMatrix4MakeTranslation (incr, 0, 0), trans);
        transformFace (verticies, trans, verticies, 18, index);
        index += 18;
    }
    
    trans = GLKMatrix4Identity;
    int rowStride = index;
    
    for (int i=1; i<segments; i++)
    {
        trans = GLKMatrix4Multiply (GLKMatrix4MakeTranslation (0, incr, 0), trans);
        transformFace (verticies, trans, verticies, rowStride, index);
        index += rowStride;
    }
    
    trans = GLKMatrix4MakeRotation(M_PI, 0, 1, 0);
    transformFace (verticies, trans, verticies, trisPerFace*6*3, trisPerFace*6*3);
    
    trans = GLKMatrix4MakeRotation (M_PI / 2.0f, 0, 1, 0);
    transformFace (verticies, trans, verticies, trisPerFace*6*3*2, trisPerFace*6*3*2);
    
    trans = GLKMatrix4MakeRotation (M_PI / 2.0f, 1, 0, 0);
    transformFace (verticies, trans, verticies, trisPerFace*6*3*2, trisPerFace*6*3*2*2);
    
    int normalIndex = 0;
    int normalStride = (_triangles * 3) / 6;
    fillNormals (normals, 0, 0, 1, normalIndex, normalStride);
    
    normalIndex += normalStride;
    fillNormals (normals, 0, 0, -1, normalIndex, normalStride);
    
    normalIndex += normalStride;
    fillNormals (normals, 1, 0, 0, normalIndex, normalStride);
    
    normalIndex += normalStride;
    fillNormals (normals, -1, 0, 0, normalIndex, normalStride);
    
    normalIndex += normalStride;
    fillNormals (normals, 0, -1, 0, normalIndex, normalStride);
    
    normalIndex += normalStride;
    fillNormals (normals, 0, 1, 0, normalIndex, normalStride);
    
    glGenBuffers(2, _vertexBuffers);
    glBindBuffer(GL_ARRAY_BUFFER, _vertexBuffers[0]);
    glBufferData(GL_ARRAY_BUFFER, (_triangles * 3 * sizeof (float)), verticies, GL_STATIC_DRAW);
    
    glBindBuffer(GL_ARRAY_BUFFER, _vertexBuffers[1]);
    glBufferData(GL_ARRAY_BUFFER, (_triangles * 3 * sizeof (float)), normals, GL_STATIC_DRAW);
    
    free (verticies);
    free (normals);
    
    if (self.numTrisLabel)
        self.numTrisLabel.text = [NSString stringWithFormat:@"triangles = %d", ((_triangles) / 3)];
}

- (void)glkView:(GLKView *)view drawInRect:(CGRect)rect
{
    if (!_vertexBuffers)
        return;
    
    glClearColor (0.0f, 0.0f, 0.0f, 1.0f);
    
    // Clear all old bits
    glClear (GL_COLOR_BUFFER_BIT);
    
    self.effect.transform.modelviewMatrix = _modelMatrix;
    
    self.effect.material.ambientColor =  (GLKVector4) {.3f, 0.0f, 0.0f, 1.0f};
    self.effect.material.diffuseColor = (GLKVector4) {.8f, 0.0f, 0.0f, 1.0f};
    self.effect.light0.ambientColor = (GLKVector4) {.6f, .6f, .6f, 1.0f};
    [self.effect prepareToDraw];
    
    glBindBuffer(GL_ARRAY_BUFFER, _vertexBuffers[0]);
    glEnableVertexAttribArray(GLKVertexAttribPosition); 
    glVertexAttribPointer(GLKVertexAttribPosition, 3, GL_FLOAT, false, 0, 0);
    
    glBindBuffer(GL_ARRAY_BUFFER, _vertexBuffers[1]);
    glEnableVertexAttribArray(GLKVertexAttribNormal); 
    glVertexAttribPointer(GLKVertexAttribNormal, 3, GL_FLOAT, false, 0, 0);
    
    glDrawArrays(GL_TRIANGLES, 0, _triangles);
    
    glFlush ();
}

#define DEGREES_TO_RADIANS(angle) ((angle) / 180.0 * M_PI)

-(void) rotateXY:(float) x: (float) y
{
    CGRect rect = self.view.bounds;
    float factor = rect.size.width > rect.size.height ? rect.size.width : rect.size.height;
    factor = 300.0f/factor;
    
    GLKMatrix4 rotMatrix = GLKMatrix4RotateWithVector3 (GLKMatrix4Identity, DEGREES_TO_RADIANS(x * factor),
                                                        (GLKVector3) {_modelMatrix.m01, _modelMatrix.m11, _modelMatrix.m21});

    _modelMatrix = GLKMatrix4Multiply (_modelMatrix, rotMatrix);
    
    rotMatrix = GLKMatrix4RotateWithVector3 (GLKMatrix4Identity, DEGREES_TO_RADIANS(y * factor),
                                             (GLKVector3) {_modelMatrix.m00, _modelMatrix.m10, _modelMatrix.m20});

    _modelMatrix = GLKMatrix4Multiply (_modelMatrix, rotMatrix);
}

- (void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event
{
    [super touchesBegan:touches withEvent:event];
    
    UITouch* touch = touches.anyObject;
    _previousLocation = [touch locationInView:touch.view];
}

- (void)touchesMoved:(NSSet *)touches withEvent:(UIEvent *)event
{
    [super touchesMoved:touches withEvent:event];
    
    UITouch* touch = touches.anyObject;
    CGPoint currentPoint = [touch locationInView:touch.view];
    [self rotateXY: currentPoint.x - _previousLocation.x: currentPoint.y - _previousLocation.y];
    _previousLocation = currentPoint;
    [self.glview display];
}

@end
