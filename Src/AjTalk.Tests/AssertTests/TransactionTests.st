Object subclass: #Rectangle instanceVariableNames: 'width height'!

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
rect width: 500.

[rect width = 500] assert.

rect := rect asTransactional.

[rect width = 500] assert.
[rect innerObject isNotNil] assert.

tm := Machine transactionManager.
!

tm beginTransaction.

[rect width = 500] assert.
[rect innerObject width = 500] assert.

rect width: 700.

[rect width = 700] assert.
[rect innerObject width = 500] assert.

tm rollbackTransaction.

[rect width = 500] assert.
[rect innerObject width = 500] assert.
