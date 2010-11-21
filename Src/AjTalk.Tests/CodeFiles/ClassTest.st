"First tests for Class"

Object subclass: #MyClass.
!

Object subclass: #Rectangle
	instanceVariableNames: 'width height'
	classVariableNames: 'number'
	poolDictionaries: ''
	category: 'Test'.
!

Rectangle methods!

width
	^width.
!

width: newValue
	width := newValue.
!

height
	^height.
!

height: newValue
	height := newValue.

! !

rect := Rectangle new width: 100; height: 50.

!
