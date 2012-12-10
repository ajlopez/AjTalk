Object subclass: #HttpListener nativeType: @System.Net.HttpListener!

!HttpListener methods!

nextContext
	^self !!GetContext
!

addPrefix: prefix
	self !!Prefixes !!Add: prefix.
!

start
	^self !!Start
! !
