
Object subclass: #RemoteHost nativeType: @AjTalk.Hosting.RemotingHostClient!

!RemoteHost methods!
export: aClass
	self execute: (aClass !!toOutputString)
! !

!Object methods!
asRemote
	^@AjTalk.Hosting.RemoteObject new: self with: Machine
! !

Object subclass: #Host nativeType: @AjTalk.Hosting.RemotingHostServer
!

