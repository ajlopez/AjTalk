
Module import: #Templates.

[Templates isNotNil] assert.
[Templates.Template isNotNil] assert.
!

| template stream |

template := Templates.Template new: [ :model : stream | stream write: 'Hello' ].

stream := @System.IO.StringWriter new.

template run: nil stream: stream.

[stream toString = 'Hello'] assert.
!

[(Templates.Template compileTemplate: 'Hello') = ':model :stream | stream write: ''Hello''.'] assert.

!

[(Templates.Template compileTemplate: 'Hello <# stream write: 1. #>') = ':model :stream | stream write: ''Hello ''. stream write: 1.  stream write: ''''.'] assert.

!

[(Templates.Template compileTemplate: 'Hello ${1} world') = ':model :stream | stream write: ''Hello ''. stream write: (1). stream write: '' world''.'] assert.

!

| template stream |

template := Templates.Template text: 'Hello'.

[template isNotNil] assert.
[template isMemberOf: Templates.Template] assert.
[template class == Templates.Template] assert.

stream := @System.IO.StringWriter new.

template run: nil stream: stream.

[stream toString = 'Hello'] assert.
!

| template stream |

template := Templates.Template text: 'Hello ${model}'.

[template isNotNil] assert.
[template isMemberOf: Templates.Template] assert.
[template class == Templates.Template] assert.

stream := @System.IO.StringWriter new.

template run: 'World' stream: stream.

[stream toString = 'Hello World'] assert.
!

| template stream |

template := Templates.Template text: 'Hello <# model do: [:item | stream write: item].#>'.

[template isNotNil] assert.
[template isMemberOf: Templates.Template] assert.
[template class == Templates.Template] assert.

stream := @System.IO.StringWriter new.

template run: #(1 2 3) stream: stream.

[stream toString = 'Hello 123'] assert.
!

| template stream |

template := Templates.Template file: 'AssertTests/Hello.tpl'.

stream := @System.IO.StringWriter new.

template run: 'World' stream: stream.

[stream toString = 'Hello World'] assert.
!

| template stream model |


template := Templates.Template text: 'Hello ${model name}'.

stream := @System.IO.StringWriter new.

model := DynamicObject new.
model name: 'World'.

template run: model stream: stream.

[stream toString = 'Hello World'] assert.
!

@System.Console !!WriteLine: 'Done'.

VirtualMachine exit.

