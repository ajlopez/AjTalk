
Module import: #Web.

[Web isNil not] assert.
[Web.Canvas isNil not] assert.
[Web.Component isNil not] assert.
[Web.Brush isNil not] assert.
!

| canvas |

canvas := Web.Canvas new.

canvas render: 'Hello'.

[canvas asString = 'Hello'] assert
!

| canvas brush |

canvas := Web.Canvas new.

brush := Web.Brush new.
brush tag: 'h1'.
brush canvas: canvas.
brush with: 'Hello'.

[canvas asString = '<h1>Hello</h1>'] assert

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

