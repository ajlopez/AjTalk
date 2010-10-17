nil subclass: #Object
!Object methods!
asRemote
	^@AjTalk.Hosting.RemoteObject new: self
! !

Object subclass: #Host nativeType: @AjTalk.Hosting.RemotingHostServer
!

host := Host new: 20001 with: 'Server2001'
!

