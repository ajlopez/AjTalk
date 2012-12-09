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
	@System.Console !!WriteLine 'new child'.
	children == nil ifTrue: [ children := ObjectList new ].
	children add: child.
!

renderChildrenOn: canvas
	children == nil ifTrue: [@System.Console !!WriteLine: 'children nil']
		ifFalse: [@System.Console !!WriteLine: 'children not nil'].
		
	children == nil ifFalse: [
		@System.Console !!WriteLine 'children'.
		children do: [ :child | child renderOn: canvas ]
	]
! !