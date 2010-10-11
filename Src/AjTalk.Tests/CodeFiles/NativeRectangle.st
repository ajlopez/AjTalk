nil subclass: #Object
!

Object subclass: #Rectangle nativeType: @AjTalk.Tests.NativeObjects.Rectangle
!Rectangle methods!
area
	^self height * self width
! !

rect := Rectangle new.
rect width: 10.
rect height: 20.
result := rect area
!

