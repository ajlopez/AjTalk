
Module import: #WebSide.

[WebSide isNotNil] assert.
[WebSide.Canvas isNotNil] assert.
[WebSide.Component isNotNil] assert.
[WebSide.Brush isNotNil] assert.
[WebSide.Head isNotNil] assert.
[WebSide.Body isNotNil] assert.
[WebSide.Html isNotNil] assert.
[WebSide.Title isNotNil] assert.
[WebSide.Paragraph isNotNil] assert.
!

| canvas |

canvas := WebSide.Canvas new.

canvas render: 'Hello'.

[canvas asString = 'Hello'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush with: 'Hello'.

[canvas asString = '<h1>Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.

[(brush attribute: 'style') isNil] assert.

brush tag: 'h1'.
brush canvas: canvas.
brush attribute: 'id' value: 'title'.
brush with: 'Hello'.

[canvas asString = '<h1 id="title">Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush attribute: 'selected' value: nil.
brush with: 'Hello'.

[canvas asString = '<h1 selected>Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush attribute: 'class' add: 'title'.
brush with: 'Hello'.

[canvas asString = '<h1 class="title">Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush attribute: 'class' add: 'title'.
brush attribute: 'class' add: 'urgent'.
brush with: 'Hello'.

[canvas asString = '<h1 class="title urgent">Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Brush new.

brush tag: 'h1'.
brush canvas: canvas.
brush width: '100px'.
brush with: 'Hello'.

[canvas asString = '<h1 style="width: 100px;">Hello</h1>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

brush := WebSide.Paragraph new.
brush canvas: canvas.
brush with: 'Hello'.

[canvas asString = '<p>Hello</p>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

canvas paragraph: 'Hello'.

"(@System.Exception new: canvas asString) raise."

[canvas asString = '<p>Hello</p>'] assert.
!

| canvas brush |

canvas := WebSide.Canvas new.

canvas paragraph: 'Hello'.
canvas paragraph: 'World'.

[canvas asString = '<p>Hello</p><p>World</p>'] assert.

!

| canvas brush |

canvas := WebSide.Canvas new.

canvas header: 'Hello, World'.

[canvas asString = '<h1>Hello, World</h1>'] assert.

!

| canvas brush |

canvas := WebSide.Canvas new.

canvas header: 'Hello, World'.
canvas paragraph: 'Great demo'.

[canvas asString = '<h1>Hello, World</h1><p>Great demo</p>'] assert.

!

| canvas brush |

canvas := WebSide.Canvas new.

canvas header: 'Hello, World'.
canvas paragraph: [
    canvas render: 'Great '.
    canvas render: 'demo'
].

[canvas asString = '<h1>Hello, World</h1><p>Great demo</p>'] assert.

!

| canvas brush |

canvas := WebSide.Canvas new.

canvas header: 'Hello, World'.
canvas div: [
    canvas render: 'Great '.
    canvas render: 'demo'
].

[canvas asString = '<h1>Hello, World</h1><div>Great demo</div>'] assert.

!

| canvas |

canvas := WebSide.Canvas new.

canvas html: 'Example'.

[canvas asString = '<html>Example</html>'] assert.

!

| canvas |

canvas := WebSide.Canvas new.

canvas html: [
    canvas head: [
        canvas title: 'My Page'
    ].
    canvas body: [
        canvas header: 'My Page'.
        canvas paragraph: 'Great demo'
    ]
].

[canvas asString = '<html><head><title>My Page</title></head><body><h1>My Page</h1><p>Great demo</p></body></html>'] assert.

!

| canvas |

canvas := WebSide.Canvas new.

canvas break.

[canvas asString = '<br/>'] assert.

!

| canvas |

canvas := WebSide.Canvas new.

canvas unorderedList: [
    canvas listItem: 'item 1'.
    canvas listItem: 'item 2'.
    canvas listItem: 'item 3'.
    ].

[canvas asString = '<ul><li>item 1</li><li>item 2</li><li>item 3</li></ul>'] assert.

!

| canvas component |

canvas := WebSide.Canvas new.
component := WebSide.Component new.

component renderOn: canvas.

[canvas asString = ''] assert.
!

WebSide.Component subclass: #MyComponent
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'WebTests'.

!

!MyComponent methods!

renderOn: canvas
    canvas html: [
        canvas head: [
            canvas title: 'My Page'
        ].
        canvas body: [
            canvas header: 'My Page'.
            self renderChildrenOn: canvas
        ]
    ]

! !

WebSide.Component subclass: #MySubComponent
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'WebTests'.

!

!MySubComponent methods!

renderOn: canvas
    canvas div: 'Subcomponent'.
    
! !

| canvas component |

canvas := WebSide.Canvas new.

component := MyComponent new.

component renderOn: canvas.

[canvas asString = '<html><head><title>My Page</title></head><body><h1>My Page</h1></body></html>'] assert.
!

| canvas component subcomponent |

canvas := WebSide.Canvas new.

component := MyComponent new.
subcomponent := MySubComponent new.

component child: subcomponent.

component renderOn: canvas.

[canvas asString = '<html><head><title>My Page</title></head><body><h1>My Page</h1><div>Subcomponent</div></body></html>'] assert.
!

@System.Console !!WriteLine: 'Done'.

VirtualMachine exit.
