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
	
asString
	^builder !!ToString
! !

