"Tests for Class"

Object subclass: #MyClass.
!

Object subclass: #Rectangle
	instanceVariableNames: 'width height'
	classVariableNames: 'number'
	poolDictionaries: ''
	category: 'Test'.
!

!Rectangle methods!

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

Test assert: rect isNotNil.
Test assert: rect width == 100.
Test assert: rect height == 50.

!
