nil subclass: #Rectangle instanceVariableNames: 'x y width height'!
!Rectangle class methods!
new
	^self basicNew
! !

!Rectangle methods!
x
	^x
!
y
	^y
!
width
	^width
!
height
	^height
!
area
	^width * height
!
x: newX
	x := newX
!
y: newY
	y := newY
!
width: newWidth
	width := newWidth
!
height: newHeight
	height := newHeight
! !

