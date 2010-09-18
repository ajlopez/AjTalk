nil subclass: #Rectangle instanceVariableNames: 'x y width height'
!Rectangle class methods!
new
	^self basicNew initialize
!Rectangle methods!
x
	^x
!
y
	^y
!
x: newX
	x := newX
!
y: newY
	y := newY
!
initialize
	x := 10.
	y := 20
! !
result := Rectangle new
!
