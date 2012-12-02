Object subclass: #Brush
	instanceVariableNames: 'tag canvas'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Brush methods!

with: content
	canvas render: '<' , tag , '>'.
	content isNil ifFalse: [canvas render: content].
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
	| paragraph |
	paragraph := self basicNew.
	paragraph tag: 'p'.
	^paragraph
! !

