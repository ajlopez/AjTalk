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
	self scope setCurrent.
	
	newclass := Brush subclass: aSymbol
		instanceVariableNames: ''
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Web'.	
	
	newclass class compile: 'new ^self new: ' , $' , aTag , $'.
	
	self compile: (aSymbol toLower) , '
			| brush |
			brush := ' , aSymbol , ' new.
			brush canvas: self.
			^brush'.			

	self compile: (aSymbol toLower) , ': content
			| brush |
			brush := self ' , (aSymbol toLower) , '.
			brush with: content.
			^brush'.			
	
	currentenv setCurrent.
! !

!Canvas methods!

initialize
	builder := StringBuilder new
!

render: anObject
	builder append: (anObject toString)
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
	^builder toString
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

Canvas define: #Html tag: 'html'.
Canvas define: #Head tag: 'head'.
Canvas define: #Body tag: 'body'.
Canvas define: #Title tag: 'title'.
Canvas define: #UnorderedList tag: 'ul'.
Canvas define: #OrderedList tag: 'ol'.
Canvas define: #ListItem tag: 'li'.

!