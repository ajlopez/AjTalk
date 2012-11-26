nil subclass: #Object!
!Object methods!
asRemote
	^@AjTalk.Hosting.RemoteObject new: self with: Machine
! !

Object subclass: #Host nativeType: @AjTalk.Hosting.RemotingHostServer
!

host := Host new: Machine with: 20000 with: 'Server2000'
!

