
Module import: #Web.

[Web isNotNil] assert.
[Web.Canvas isNotNil] assert.
[Web.Component isNotNil] assert.
[Web.Brush isNotNil] assert.
[Web.Head isNotNil] assert.
[Web.Body isNotNil] assert.
[Web.Html isNotNil] assert.
[Web.Title isNotNil] assert.
[Web.Paragraph isNotNil] assert.
!

| canvas |

canvas := Web.Canvas new.

canvas render: 'Hello'.

[canvas asString = 'Hello'] assert.
!

| canvas brush |

canvas := Web.Canvas new.

brush := Web.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush with: 'Hello'.

[canvas asString = '<h1>Hello</h1>'] assert.
!

| canvas brush |

canvas := Web.Canvas new.

brush := Web.Paragraph new.
brush canvas: canvas.
brush with: 'Hello'.

[canvas asString = '<p>Hello</p>'] assert.
!

| canvas brush |

canvas := Web.Canvas new.

canvas paragraph: 'Hello'.

"(@System.Exception new: canvas asString) raise."

[canvas asString = '<p>Hello</p>'] assert.
!

| canvas brush |

canvas := Web.Canvas new.

canvas paragraph: 'Hello'.
canvas paragraph: 'World'.

[canvas asString = '<p>Hello</p><p>World</p>'] assert.

!

| canvas brush |

canvas := Web.Canvas new.

canvas header: 'Hello, World'.

[canvas asString = '<h1>Hello, World</h1>'] assert.

!

| canvas brush |

canvas := Web.Canvas new.

canvas header: 'Hello, World'.
canvas paragraph: 'Great demo'.

[canvas asString = '<h1>Hello, World</h1><p>Great demo</p>'] assert.

!

| canvas brush |

canvas := Web.Canvas new.

canvas header: 'Hello, World'.
canvas paragraph: [
	canvas render: 'Great '.
	canvas render: 'demo'
].

[canvas asString = '<h1>Hello, World</h1><p>Great demo</p>'] assert.

!

| canvas brush |

canvas := Web.Canvas new.

canvas header: 'Hello, World'.
canvas div: [
	canvas render: 'Great '.
	canvas render: 'demo'
].

[canvas asString = '<h1>Hello, World</h1><div>Great demo</div>'] assert.

!

| canvas |

canvas := Web.Canvas new.

canvas html: 'Example'.

[canvas asString = '<html>Example</html>'] assert.

!

| canvas |

canvas := Web.Canvas new.

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

canvas := Web.Canvas new.

canvas break.

[canvas asString = '<br/>'] assert.

!

| canvas |

canvas := Web.Canvas new.

canvas unorderedList: [
	canvas listItem: 'item 1'.
	canvas listItem: 'item 2'.
	canvas listItem: 'item 3'.
	].

[canvas asString = '<ul><li>item 1</li><li>item 2</li><li>item 3</li></ul>'] assert.

!

| canvas component |

canvas := Web.Canvas new.
component := Web.Component new.

component renderOn: canvas.

[canvas asString = ''] assert.
!

Web.Component subclass: #MyComponent
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

Web.Component subclass: #MySubComponent
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

canvas := Web.Canvas new.

component := MyComponent new.

component renderOn: canvas.

[canvas asString = '<html><head><title>My Page</title></head><body><h1>My Page</h1></body></html>'] assert.
!

| canvas component subcomponent |

canvas := Web.Canvas new.

component := MyComponent new.
subcomponent := MySubComponent new.

"Machine debug: true."
component child: subcomponent.

component renderOn: canvas.

[canvas asString = '<html><head><title>My Page</title></head><body><h1>My Page</h1><div>Subcomponent</div></body></html>'] assert.
!

@System.Console !!WriteLine: 'Done'.

VirtualMachine exit.
