Object subclass:#Canvas
	instanceVariableNames: 'builder'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Canvas methods!

initialize
	builder := @System.Text.StringBuilder !!new
!

render: anObject
	builder !!Append: (anObject !!ToString)
!

paragraph
	| brush |
	brush := Paragraph new.
	brush canvas: self.
	^brush
!
	
paragraph: content
	| brush |
	brush := self paragraph.
	brush with: content.
	^brush
!
	
header
	| brush |
	brush := Header new.
	brush canvas: self.
	^brush
!
	
header: content
	| brush |
	brush := self header.
	brush with: content.
	^brush
!

div
	| brush |
	brush := Div new.
	brush canvas: self.
	^brush
!
	
div: content
	| brush |
	brush := self div.
	brush with: content.
	^brush
!

asString
	^builder !!ToString
! !

!Object methods!

renderOn: canvas
	canvas render: self
! !

!String methods!

renderOn: canvas
	canvas render: self
! !

!UndefinedObject methods!

renderOn: canvas
	^nil
! !

!Block methods!

renderOn: canvas
	self value
! !

