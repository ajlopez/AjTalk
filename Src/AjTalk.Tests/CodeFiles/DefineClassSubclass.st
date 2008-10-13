nil subclass: #Figure instanceVariables: 'x y'
!Figure methods!
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
! !

Figure subclass: #Rectangle instanceVariables: 'width height'
!Rectangle methods!
width
	^width
!
height
	^height
!
