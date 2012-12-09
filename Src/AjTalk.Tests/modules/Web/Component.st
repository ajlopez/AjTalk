Object subclass: #Component
	instanceVariableNames: 'children'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Component methods!

renderOn: canvas
	self renderChildrenOn: canvas
!

child: child
	children ifNil: [ children := ObjectList new ].
	children add: child.
!

renderChildrenOn: canvas
	children ifNotNil: [
		children do: [ :child | child renderOn: canvas ]
	]
! !