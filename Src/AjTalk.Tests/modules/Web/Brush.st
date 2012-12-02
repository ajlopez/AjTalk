Object subclass: #Brush
	instanceVariableNames: 'tag canvas'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

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
	| header |
	header := self basicNew.
	header tag: 'p'.
	^header
! !

Brush subclass: #Header
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
! !

!Header class methods!

new
	| header |
	header := self basicNew.
	header tag: 'h1'.
	^header
! !

!Header methods!

level: aLevel
	tag = 'h' , aLevel
! !

