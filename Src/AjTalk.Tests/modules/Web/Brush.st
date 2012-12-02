Object subclass: #Brush
	instanceVariableNames: 'tag canvas'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Brush class methods!

new: tag
	| brush |
	brush := self basicNew.
	brush tag: tag.
	^brush
! !

!Brush methods!

with: content
	canvas render: '<' , tag , '>'.
	content renderOn: canvas.
	canvas render: '</', tag , '>'
!

canvas: aCanvas
	canvas := aCanvas
!

tag: aTag
	tag := aTag
! !

Brush subclass: #Paragraph
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Paragraph class methods!

new
	^self new: 'p'
! !

Brush subclass: #Header
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
! !

!Header class methods!

new
	^self new: 'h1'
! !

!Header methods!

level: aLevel
	tag = 'h' , aLevel
! !

Brush subclass: #Div
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
! !

!Div class methods!

new
	^self new: 'div'
! !

