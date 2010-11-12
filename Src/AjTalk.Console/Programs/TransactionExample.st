
Object subclass: #Rectangle instanceVariableNames: 'width height'
!Rectangle methods!
width
	^width
!
height
	^height
!
width: newWidth
	width := newWidth
!
height: newHeight
	height := newHeight
! !

rect := Rectangle new.
rect := rect asTransactional
!

tm := @AjTalk.Machine current transactionManager.
console := @System.Console out
!

rect width: 500!

tm.beginTransaction!

console write: 'rect width is '.
console writeLine: rect width!

console write: 'inner rect width is '.
console writeLine: rect innerObject width!

rect width: 700!

console write: 'rect width now is '.
console writeLine: rect width!

console write: 'inner rect width now is '.
console writeLine: rect innerObject width!

tm.rollbackTransaction!

console write: 'rect width now is '.
console writeLine: rect width!

console write: 'inner rect width now is '.
console writeLine: rect innerObject width!

