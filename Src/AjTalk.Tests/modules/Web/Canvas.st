Object subclass:#Canvas
	instanceVariableNames: 'builder'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Canvas class methods!

define: aSymbol tag: aTag
	| newclass currentenv |
	currentenv := Environment current.
	self !!Scope setCurrent.
	
	newclass := Brush subclass: aSymbol
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Web'.	
	
	newclass class compile: 'new ^self new: ' , $' , aTag , $'.
	
	self compile: (aSymbol !!ToLower) , '
			| brush |
			brush := ' , aSymbol , ' new.
			brush canvas: self.
			^brush'.			

	self compile: (aSymbol !!ToLower) , ': content
			| brush |
			brush := self ' , (aSymbol !!ToLower) , '.
			brush with: content.
			^brush'.			
	
	currentenv setCurrent.
! !

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

