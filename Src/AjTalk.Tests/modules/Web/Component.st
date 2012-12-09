Object subclass: #Component
	instanceVariableNames: 'children'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Web'
!

!Component methods!

renderOn: canvas
	children ifNotNil: [
		children do: [ :child | canvas render: child ]
	]
! !