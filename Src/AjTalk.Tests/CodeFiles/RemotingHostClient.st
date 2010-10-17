nil subclass: #Object
!

Object subclass: #RemoteHost nativeType: @AjTalk.Hosting.RemotingHostClient
!RemoteHost methods!
export: aClass
	self execute: (aClass !!toOutputString)
! !

remote := RemoteHost new: 'localhost' with: 20000 with: 'Server2000'
!

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

remote export: Rectangle
!
remote execute: 'rect := Rectangle new. rect width: 100. rect height: 20'
!
rect := remote evaluate: 'rect'.
rect width: 200.
rect height: 30
!
rect2 := remote evaluate: 'rect asRemote'.
rect2 width: 300.
rect2 height: 40
!